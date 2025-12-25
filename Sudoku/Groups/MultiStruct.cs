using Sudoku.Nodes;
using System;

namespace Sudoku.Groups {
    public abstract class MultiStruct {
        private int quantityGroups;
        private NodeCellsGroup[] Groups;
        public IReadOnlyList<NodeCellsGroup> GetGroups => this.Groups;

        public MultiStruct(int quantity) {
            quantityGroups = quantity;
            Groups = new NodeCellsGroup[quantityGroups];

            for (int i = 0; i < quantityGroups; i++) 
                Groups[i] = new NodeCellsGroup(quantityGroups);           
        }

        public void Add(NodeCell cell, int indexGroup, int indexCell) => Groups[indexGroup].Add(cell, indexCell);        
        public void Remove(int indexGroup, int indexCell) => Groups[indexGroup].Remove(indexCell);
        public bool CanAdd(NodeCell cell, int indexGroup) => Groups[indexGroup].CanAdd(cell);
        public byte GetQuantity() => (byte)Groups.Length;

        public void ToString() {
            for (int i = 0; i < quantityGroups; i++) {
                Groups[i].ToString();
            }
        }
    }
}
