using Sudoku.Groups;
using Sudoku.Nodes;
using System;
using System.Text.RegularExpressions;

namespace Sudoku.QuadBoard {
    public class Board {

        private int quantity;
        public Lines lines;
        public Columns columns;
        public GroupsStuct groups;
         
        public Board(int quantity) {
            this.quantity = quantity;
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity);
        }

        public void AddCell(NodeCell cell, int lineIndex, int columnIndex) {
            lines.Add(cell, lineIndex, columnIndex);
            columns.Add(cell, columnIndex, lineIndex);
            groups.Add(cell, (lineIndex / 3) * 3 + columnIndex / 3, (lineIndex % 3) * 3 + columnIndex % 3);
        }

        public bool CanAdd(NodeCell cell, int lineIndex, int columnIndex) {
            bool linesCan = lines.CanAdd(cell, lineIndex);
            bool columnsCan = columns.CanAdd(cell, columnIndex);

            bool groupsCan = groups.CanAdd(cell, (lineIndex / 3) * 3 + columnIndex / 3);
            return linesCan && columnsCan && groupsCan;
        }

        public void RemoveCell(int lineIndex, int columnIndex) {
            lines.Remove(lineIndex, columnIndex);
            columns.Remove(columnIndex, lineIndex);
            groups.Remove( (lineIndex / 3) * 3 + columnIndex / 3, (lineIndex % 3) * 3 + columnIndex % 3);
        }

        public void LineToString() => lines.ToString();
        public void ColumnToString() => columns.ToString();
        public void GroupsToString() => groups.ToString();


    }
}
