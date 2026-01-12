using Sudoku.Generates;
using Sudoku.Groups;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
using Sudoku.Difficulty.group;
using Sudoku.Difficulty;
using System;
using Sudoku.Solvers;

namespace Sudoku{
    internal static class Program {

        public static byte quantity = 9;
        private static byte switchMethodFunctionGenerator = 16;
        public static Board Board = new Board(quantity);
        private static ISudokuSolver solver = new SudokuSolver(quantity);
        private static SudokuPuzzleGenerator spg = new SudokuPuzzleGenerator(solver, quantity);
        private static IDifficulty Difficulty;

        private static void Main() {
            DifficultyLevel difficultyLevel = DifficultyLevel.Hard;
            Difficulty = DifficultyFactory.Create(difficultyLevel);

            var generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
            generator.Generate(Board);

            spg.RemoveNumbers(Board, Difficulty);

            Console.WriteLine();
            Board.LineToString();
       
        }
    }
}