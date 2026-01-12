using System;
using Sudoku.QuadBoard;
namespace Sudoku.Solvers {
    public interface ISudokuSolver {
        bool HasUniqueSolution(Board board);
    }
}
