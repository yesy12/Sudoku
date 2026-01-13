using Sudoku.Difficulty;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
using System;

namespace Sudoku.Solvers {
    public class SudokuPuzzleGenerator {
        private ISudokuSolver solver;
        private readonly Random random = new Random();
        private int quantity;

        public SudokuPuzzleGenerator(ISudokuSolver solver, int quantity) {
            this.solver = solver;
            this.quantity = quantity;
        }

        public void RemoveNumbers(Board board, IDifficulty difficulty) {
            ushort min = difficulty.MinRemovableNumbers(quantity);
            ushort max = difficulty.MaxRemovableNumbers(quantity);
            ushort toRemove = (ushort)random.Next(min,max+1);
            ushort removed = 0;
            ushort attempts = 0;
            ushort maxAttempts = (ushort)(quantity * quantity * 5);

            while (removed < toRemove && attempts < maxAttempts) {
                int line = random.Next(0, quantity);
                int col = random.Next(0, quantity); 
                NodeCell cell = board.GetLines()[line].Cells[col];

                if (cell.Number == 0)
                    continue;

                byte backup = cell.Number;
                board.RemoveCell(line, col);
                Board clone = board.Clone();

                if (!solver.HasUniqueSolution(clone))
                    board.AddCell(new NodeCell((byte)quantity) { Number = backup }, line, col);
                else
                    removed++;

                attempts++;
            }
        }
    }
}
