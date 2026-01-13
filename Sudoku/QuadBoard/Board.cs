using Sudoku.Groups;
using Sudoku.Nodes;
using System;
using System.Text.RegularExpressions;

namespace Sudoku.QuadBoard {
    public class Board {
        private int quantity;
        private Lines lines;
        private Columns columns;
        private GroupsStuct groups;
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

        public Board Clone() {
            Board clone = new Board(quantity);

            for (int line = 0; line < quantity; line++)
                for (int column = 0; column < quantity; column++) {
                    byte number = (byte)lines.Groups[line].Cells[column].Number;
                    NodeCell cell = new NodeCell((byte)quantity);

                    if (number != 0)
                        cell.Number = number;                                         

                    clone.AddCell(cell, line, column);
                }
            return clone;
        }

        public int QuantityRemoved() {
            int removed = 0;
            for (int line = 0; line < quantity; line++)
                for (int col = 0; col < quantity; col++)
                    if (lines.Groups[line].Cells[col].Number == 0)
                        removed++;
            return removed;
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

        public IReadOnlyList<NodeCellsGroup> GetLines() => lines.Groups;
        public IReadOnlyList<NodeCellsGroup> GetColumns() => columns.Groups;
        public IReadOnlyList<NodeCellsGroup> GetGroups() => groups.Groups;

        public int GetQuantity() => quantity;

        public bool IsComplete() => structIsNotEqual((NodeCellsGroup[])lines.Groups);

        internal bool structIsNotEqual(NodeCellsGroup[] elements) {
            foreach (NodeCellsGroup element in elements)
                foreach (var cells in element.Cells)
                    if (cells.Number == 0)
                        return false;
            return true;
        }
    }
}
