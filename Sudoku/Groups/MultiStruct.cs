using Sudoku.Nodes;
using System;

namespace Sudoku.Groups {
    public abstract class MultiStruct {
        private NodeCellsGroup[] Groups;
        public IReadOnlyList<NodeCellsGroup> GetGroups => this.Groups;

        public MultiStruct(int quantity) {
            Groups = new NodeCellsGroup[quantity];

            for (int i = 0; i < quantity; i++) 
                Groups[i] = new NodeCellsGroup(quantity);           
        }

        public void Add(NodeCell cell, int indexGroup, int indexCell) => Groups[indexGroup].Add(cell, indexCell);        
        public void Remove(int indexGroup, int indexCell) => Groups[indexGroup].Remove(indexCell);
        public bool CanAdd(NodeCell cell, int indexGroup) => Groups[indexGroup].CanAdd(cell);
        public byte GetQuantity() => (byte)Groups.Length;

        public void ToString() {
            for (int i = 0; i < GetQuantity(); i++) {
                Groups[i].ToString();
            }
        }
    }
}
