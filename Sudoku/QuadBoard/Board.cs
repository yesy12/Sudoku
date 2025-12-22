using Sudoku.Groups;
using Sudoku.Nodes;
using System;
using System.Text.RegularExpressions;

namespace Sudoku.QuadBoard {
    public class Board {

        private int quantity;
        public Lines lines;
        public Columns columns;
        public Group group;
         
        public Board(int quantity) {
            this.quantity = quantity;
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            group = new Group(quantity);
        }

        public void AddCell(NodeCell cell, int lineIndex, int columnIndex) {
            lines.Add(cell, lineIndex, columnIndex);
            columns.Add(cell, columnIndex, lineIndex);
            group.Add(cell, (lineIndex / 3) * 3 + columnIndex / 3, (lineIndex % 3) * 3 + columnIndex % 3);
        }

        public void RemoveCell(int lineIndex, int columnIndex) {
            lines.Remove(lineIndex, columnIndex);
            columns.Remove(columnIndex, lineIndex);
            group.Remove( (lineIndex / 3) * 3 + columnIndex / 3, (lineIndex % 3) * 3 + columnIndex % 3);
        }

        public void LineToString() => lines.ToString();
        public void ColumnToString() => columns.ToString();
        public void GroupToString() => group.ToString();

    }
}
