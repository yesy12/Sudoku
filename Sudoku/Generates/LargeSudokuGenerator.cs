using Sudoku.QuadBoard;
using System;
namespace Sudoku.Generates {
    public class LargeSudokuGenerator : ISudokuGenerator {
        public ushort? seed { get; }
        private readonly int quantity;
        private readonly Random random;

        public LargeSudokuGenerator(int quantity) {
            this.quantity = quantity;
            random = new Random();
            seed = null;
        }

        public LargeSudokuGenerator(int quantity, ushort seed) {
            this.seed = seed;
            this.quantity = quantity;
            this.random = new Random(seed);
        }

        public void Generate(Board board) {
            throw new NotImplementedException();
        }
    }
}
