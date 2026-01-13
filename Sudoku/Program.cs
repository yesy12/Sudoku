using Sudoku.Difficulty;
using Sudoku.Generates;
using Sudoku.QuadBoard;
using Sudoku.Solvers;

namespace Sudoku {
    internal static class Program {

        public static byte quantity = 9;
        private static readonly byte switchMethodFunctionGenerator = 16;
        public static Board Board = new Board(quantity);
        public static Board BoardComplete = new Board(quantity);
        private static readonly Benchmark benchmark = new Benchmark(quantity);
        private static readonly ISudokuSolver solver = new SudokuSolver(quantity);
        private static readonly SudokuPuzzleGenerator spg = new SudokuPuzzleGenerator(solver, quantity);
        private static readonly ISudokuGenerator generator = SudokuGeneratorFactory.Create(quantity, 194, switchMethodFunctionGenerator);
        private static IDifficulty Difficulty;

        private static void Main() {
            DifficultyLevel difficultyLevel = DifficultyLevel.VeryEasy;
            Difficulty = DifficultyFactory.Create(difficultyLevel);

            generator.Generate(Board);
            BoardComplete = Board.Clone(true);

            spg.RemoveNumbers(Board, Difficulty);
            Board.LockedCells();

        }
    }
}