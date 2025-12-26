using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public class LargeSudokuGenerator : ISudokuGenerator {

        private int quantity;
        public LargeSudokuGenerator(int quantity) => this.quantity = quantity;          

        public void Generate(Board board) {
            throw new NotImplementedException();
        }
    }
}
