using Sudoku.Nodes;

namespace Sudoku.Groups {
    public abstract class MultiStruct {

        private int quantityGroups;
        public NodeCellsGroup[] Groups;

        public MultiStruct(int quantity) {
            quantityGroups = quantity;
            Groups = new NodeCellsGroup[quantityGroups];

            for (int i = 0; i < quantityGroups; i++) {
                Groups[i] = new NodeCellsGroup(quantityGroups);
            }
        }

        public void Add(NodeCell cell, int indexGroup, int indexCell) {
            Groups[indexGroup].Add(cell, indexCell);
        }

        public void ToString() {
            for (int i = 0; i < quantityGroups; i++) {
                Groups[i].ToString();
            }
        }

    }
}
