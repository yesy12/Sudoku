using Sudoku.Nodes;
using Sudoku.QuadBoard;

namespace Sudoku.Solvers {
    public class SudokuSolver : ISudokuSolver {
        private int solution;
        private readonly int quantity;

        public SudokuSolver(int quantity) {
            this.quantity = quantity;
        }

        public bool HasUniqueSolution(Board board) {
            solution = 0;
            Solve(board);
            return solution == 1;
        }

        internal void Solve(Board board) {
            if (solution > 1)
                return;

            for (int line = 0; line < quantity; line++)
                for (int col = 0; col < quantity; col++)

                    if (board.GetLines()[line].Cells[col].Number == 0) {
                        for (byte num = 1; num <= quantity; num++) {
                            NodeCell cell = new NodeCell((byte)quantity) { Number = num };

                            if (board.CanAdd(cell, line, col)) {
                                board.AddCell(cell, line, col);
                                Solve(board);
                                board.RemoveCell(line, col);

                                if (solution > 1)
                                    return;
                            }
                        }
                        return;
                    }

            solution++;
        }


    }
}