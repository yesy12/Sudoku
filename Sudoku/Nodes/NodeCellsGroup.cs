using System.Collections.Generic;
using System.Linq;
namespace Sudoku.Nodes {
    public class NodeCellsGroup {
        public NodeCell[] Cells;
        private readonly HashSet<byte> usedNumbers;
        private readonly int quantity;

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
        public bool CanAdd(byte number) => !usedNumbers.Contains(number);
        public void Remove(int index) {
            if (Cells[index].Number != 0) {
                usedNumbers.Remove(Cells[index].Number);
                Cells[index] = new NodeCell((byte)quantity);
            }
        }
        public ushort SumUsedNumbersCount() => (ushort)usedNumbers.Sum(value => value);
    }
}
