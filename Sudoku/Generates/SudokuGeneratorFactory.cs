using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public static class SudokuGeneratorFactory {

        public static ISudokuGenerator Create(int quantity, int ClassicMaxSize) {
            return quantity < ClassicMaxSize ? new ClassicSudokuGenerator(quantity) : new LargeSudokuGenerator(quantity);
        }
    }
}