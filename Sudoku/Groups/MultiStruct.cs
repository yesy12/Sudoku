using Sudoku.Nodes;
using System;

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

        public void Remove(int indexGroup, int indexCells) {
            Groups[indexGroup].Remove(indexCells);
        }

        public void ToString() {
            for (int i = 0; i < quantityGroups; i++) {
                Groups[i].ToString();
            }
        }
    }
}
