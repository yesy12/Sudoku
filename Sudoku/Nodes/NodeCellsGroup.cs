using System;
using System.Collections.Generic;

namespace Sudoku.Nodes {
    public class NodeCellsGroup {
        public NodeCell[] Cells;
        private HashSet<byte> usedNumbers;
        private int quantity;

        public NodeCellsGroup(int quantityCells) {
            this.quantity = quantityCells;
            Cells = new NodeCell[quantityCells];
            usedNumbers = new HashSet<byte>();
            for (int i = 0; i < quantityCells; i++)
                Cells[i] = new NodeCell((byte)quantityCells);
        }
        public void Add(NodeCell cell, int index) {
            if (!usedNumbers.Contains(cell.Number)) {
                Cells[index] = cell;
                usedNumbers.Add(cell.Number);
            }
        }
        public bool CanAdd(NodeCell cell) => !usedNumbers.Contains(cell.Number);
        public void Remove(int index) {
            if (Cells[index].Number != 0) {
                usedNumbers.Remove(Cells[index].Number);
                Cells[index] = new NodeCell((byte)quantity); 
            }
        }
        public void ToString() {
            for (int i = 0; i < Cells.Length; i++) {
                Console.Write($"{Cells[i].Number} | ");
            }
            Console.Write(usedNumbers.Sum(a => a));
            Console.WriteLine();
        }
    }
}
