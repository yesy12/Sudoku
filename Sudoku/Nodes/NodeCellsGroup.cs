using System;
using System.Collections.Generic;

namespace Sudoku.Nodes {
    public class NodeCellsGroup {
        public NodeCell[] Cells;
        private HashSet<byte> usedNumbers;
        private int quantity;

        public NodeCellsGroup(int quantityCells) {
            quantity = quantityCells;
            Cells = new NodeCell[quantity];
            usedNumbers = new HashSet<byte>();

            for (int i = 0; i < quantity; i++) {
                Cells[i] = new NodeCell();
            }
        }

        public void Add(NodeCell cell, int index) {
            if (!usedNumbers.Contains(cell.Number)) {
                Cells[index] = cell;
                usedNumbers.Add(cell.Number);
            }
        }

        public void Remove(int index) {
            if (Cells[index].Number != 0) {
                usedNumbers.Remove(Cells[index].Number);
                Cells[index] = new NodeCell(); 
            }
        }


        public void ToString() {
            for (int i = 0; i < quantity; i++) {
                Console.Write($"{Cells[i].Number} | ");
            }
            Console.Write(usedNumbers.Sum(a => a));
            Console.WriteLine();
        }
    }
}
