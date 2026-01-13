using Sudoku.Generates;
using Sudoku.QuadBoard;
using Sudoku.Difficulty;
using System;
using Sudoku.Solvers;

namespace Sudoku{
    internal static class Program {

        public static byte quantity = 9;
        private static byte switchMethodFunctionGenerator = 16;
        public static Board Board = new Board(quantity);
        private static Benchmark benchmark = new Benchmark(quantity);
        private static ISudokuSolver solver = new SudokuSolver(quantity);
        private static SudokuPuzzleGenerator spg = new SudokuPuzzleGenerator(solver, quantity);
        private static ISudokuGenerator generator = SudokuGeneratorFactory.Create(quantity,194, switchMethodFunctionGenerator);
        private static IDifficulty Difficulty;

        private static void Main() {
            DifficultyLevel difficultyLevel = DifficultyLevel.VeryEasy;
            Difficulty = DifficultyFactory.Create(difficultyLevel);

            generator.Generate(Board);
            //benchmark.SetAll(Board);

            //spg.RemoveNumbers(Board, Difficulty);
            //Console.WriteLine(benchmark.Compare());

            Console.WriteLine();

            foreach (var group in Board.GetLines()) { 
                foreach (var line in group.Cells) 
                    Console.Write($"{line.Number.ToString()}|");
                Console.WriteLine();
            }
            Console.WriteLine();

            foreach (var group in Board.GetColumns()) {
                foreach (var columns in group.Cells)
                    Console.Write($"{columns.Number.ToString()}|");
                Console.WriteLine();
            }

            Console.WriteLine();
            foreach (var group in Board.GetGroups()) {
                foreach (var groups in group.Cells)
                    Console.Write($"{groups.Number.ToString()}|");
                Console.WriteLine();
            }

        }
    }
}