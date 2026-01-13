using Sudoku.Groups;
using Sudoku.Nodes;

namespace Sudoku.QuadBoard {
    public class Board {
        private readonly int quantity;
        private Lines lines;
        private Columns columns;
        private GroupsStuct groups;
        private readonly int root;

        public Board(int quantity) {
            this.quantity = quantity;
            root = (int)Math.Sqrt(quantity);
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity);
        }

        #region Struct
        public void Clear() {
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity);
        }

        public Board Clone(bool IsFixed = false) {
            Board clone = new Board(quantity);

            for (int line = 0; line < quantity; line++)
                for (int column = 0; column < quantity; column++) {
                    byte number = lines.Groups[line].Cells[column].Number;
                    NodeCell cell = new NodeCell((byte)quantity);

                    if (number != 0) {
                        cell.Number = number;
                        if (IsFixed)
                            cell.IsFixed = true;
                    }

                    clone.AddCell(cell, line, column);
                }
            return clone;
        }

        public void LockedCells() {
            foreach (NodeCellsGroup line in lines.Groups)
                foreach (NodeCell cell in line.Cells)
                    cell.IsFixed = cell.Number != 0;
        }
        internal bool StructIsNotEqual(NodeCellsGroup[] elements) {
            foreach (NodeCellsGroup element in elements)
                foreach (var cells in element.Cells)
                    if (cells.Number == 0)
                        return false;
            return true;
        }

        #endregion

        #region Cell
        public void AddCell(NodeCell cell, int lineIndex, int columnIndex) {
            lines.Add(cell, lineIndex, columnIndex);
            columns.Add(cell, columnIndex, lineIndex);
            groups.Add(cell, LineIndexGroup(lineIndex, columnIndex), ColumnIndexGroup(lineIndex, columnIndex));
        }
        public bool CanAdd(NodeCell cell, int lineIndex, int columnIndex) {
            bool linesCan = lines.CanAdd(cell, lineIndex);
            bool columnsCan = columns.CanAdd(cell, columnIndex);
            bool groupsCan = groups.CanAdd(cell, LineIndexGroup(lineIndex, columnIndex));
            return linesCan && columnsCan && groupsCan;
        }
        public void RemoveCell(int lineIndex, int columnIndex) {
            lines.Remove(lineIndex, columnIndex);
            columns.Remove(columnIndex, lineIndex);
            groups.Remove(LineIndexGroup(lineIndex, columnIndex), ColumnIndexGroup(lineIndex, columnIndex));
        }

        internal int LineIndexGroup(int lineIndex, int columnIndex) => (lineIndex / root) * root + columnIndex / root;
        internal int ColumnIndexGroup(int lineIndex, int columnIndex) => (lineIndex % root) * root + columnIndex % root;
        #endregion

        #region Get Values
        public IReadOnlyList<NodeCellsGroup> GetLines() => lines.Groups;
        public IReadOnlyList<NodeCellsGroup> GetColumns() => columns.Groups;
        public IReadOnlyList<NodeCellsGroup> GetGroups() => groups.Groups;

        public bool IsComplete() => StructIsNotEqual((NodeCellsGroup[])lines.Groups);

        public int GetQuantity() => quantity;
        public int QuantityRemoved() {
            int removed = 0;
            for (int line = 0; line < quantity; line++)
                for (int col = 0; col < quantity; col++)
                    if (lines.Groups[line].Cells[col].Number == 0)
                        removed++;
            return removed;
        }
        #endregion
    }
}
