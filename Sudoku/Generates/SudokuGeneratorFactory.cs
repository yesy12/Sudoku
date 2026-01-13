using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public static class SudokuGeneratorFactory {

        public static ISudokuGenerator Create(int quantity, int ClassicMaxSize) =>
            quantity < ClassicMaxSize ? new ClassicSudokuGenerator(quantity) : new LargeSudokuGenerator(quantity);        

        public static ISudokuGenerator Create(int quantity, ushort seed, int ClassicMaxSize) =>
            quantity < ClassicMaxSize ? new ClassicSudokuGenerator(quantity, seed) : new LargeSudokuGenerator(quantity, seed);
    }
}