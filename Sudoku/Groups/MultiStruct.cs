using Sudoku.Nodes;

namespace Sudoku.Groups {
    public abstract class MultiStruct {
        private NodeCellsGroup[] groups;
        public IReadOnlyList<NodeCellsGroup> Groups => this.groups;

        public MultiStruct(int quantity) {
            groups = new NodeCellsGroup[quantity];

            for (int i = 0; i < quantity; i++)
                groups[i] = new NodeCellsGroup(quantity);
        }

        public void setGroup(NodeCellsGroup[] group) {
            groups = group;
        }

        public void Add(NodeCell cell, int indexGroup, int indexCell) => Groups[indexGroup].Add(cell, indexCell);
        public void Remove(int indexGroup, int indexCell) => Groups[indexGroup].Remove(indexCell);
        public bool CanAdd(NodeCell cell, int indexGroup) => Groups[indexGroup].CanAdd(cell);
        public ushort SumUsedNumbersCount(int indexGroup) => Groups[indexGroup].SumUsedNumbersCount();
        public byte GetQuantity() => (byte)groups.Length;
    }
}
