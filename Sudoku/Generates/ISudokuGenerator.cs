using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public interface ISudokuGenerator {
        public void Generate(Board board);
    }
}