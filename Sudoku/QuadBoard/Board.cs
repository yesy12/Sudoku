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
        private int root;
         
        public Board(int quantity) {
            this.quantity = quantity;
            root = (int)Math.Sqrt(quantity);
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity);
        }

        public void Clear() {
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity);
        }

        public void AddCell(NodeCell cell, int lineIndex, int columnIndex) {
            lines.Add(cell, lineIndex, columnIndex);
            columns.Add(cell, columnIndex, lineIndex);
            groups.Add(cell, lineIndexGroup(lineIndex, columnIndex), columnIndexGroup(lineIndex, columnIndex));
        }
        public bool CanAdd(NodeCell cell, int lineIndex, int columnIndex) {
            bool linesCan = lines.CanAdd(cell, lineIndex);
            bool columnsCan = columns.CanAdd(cell, columnIndex);
            bool groupsCan = groups.CanAdd(cell, lineIndexGroup(lineIndex, columnIndex));
            return linesCan && columnsCan && groupsCan;
        }

        public void RemoveCell(int lineIndex, int columnIndex) {
            lines.Remove(lineIndex, columnIndex);
            columns.Remove(columnIndex, lineIndex);
            groups.Remove( lineIndexGroup(lineIndex,columnIndex), columnIndexGroup(lineIndex,columnIndex) );
        }

        internal int lineIndexGroup(int lineIndex, int columnIndex) => (lineIndex / root) * root + columnIndex / root;
        internal int columnIndexGroup(int lineIndex, int columnIndex) => (lineIndex % root) * root + columnIndex % root;

        public void LineToString() => lines.ToString();
        public void ColumnToString() => columns.ToString();
        public void GroupsToString() => groups.ToString();
        public int GetQuantity() => quantity;

        public bool IsComplete() {                        
            return structIsNotEqual((NodeCellsGroup[])lines.GetGroups);
        }

        internal bool structIsNotEqual(NodeCellsGroup[] elements) {
            foreach (NodeCellsGroup element in elements)
                foreach (var cells in element.Cells)
                    if (cells.Number == 0)
                        return false;
            return true;
        }
    }
}
