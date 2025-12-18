using System;
using System.Collections.Generic;


namespace Sudoku.Nodes {
    public class NodeCellsGroup {
        public NodeCell[] Cells;
        private HashSet<byte> usedNumbers;
        private int quantity;

        public NodeCellsGroup(int quantity) {
            this.quantity = quantity;
            Cells = new NodeCell[quantity];
            usedNumbers = new HashSet<byte>();

            for (int i = 0; i < quantity; i++) {
                Cells[i] = new NodeCell();
            }
        }

        public void Add(byte number, int index) {
            if (!usedNumbers.Contains(number)) {                 
                Cells[index].Number = number;
                usedNumbers.Add(number);
            }
        }

    }
}
