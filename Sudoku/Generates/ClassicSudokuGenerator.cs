using Sudoku.Nodes;
using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public class ClassicSudokuGenerator : ISudokuGenerator{

        private int quantity;
        public ClassicSudokuGenerator(int quantity) => this.quantity = quantity;            

        public void Generate(Board board) {
            board.Clear();

            GenerateFirstLine(board);

            if (!FillFromRow(board, 1))
                throw new Exception("Failed to generate sudoku");
        }

        private void GenerateFirstLine(Board Board) {
            RandomNumberCell.Initialize((byte)quantity);
            for (int column = 0; column < quantity; column++) {
                NodeCell cell = new NodeCell((byte)quantity) { Number = RandomNumberCell.RandomNumber()};
                Board.AddCell(cell, 0, column);
            }
        }

        private bool FillFromRow(Board board, int row) {
            if (row >= quantity)
                return true;
            return AddOnCell(board, row);
        }

        private bool AddOnCell(Board board, int row, int column = 0) {
            if (column >= quantity) return FillFromRow(board, row + 1);

            var numbers = Enumerable.Range(1, quantity).Select(n => (byte)n).OrderBy(_ => Random.Shared.Next());

            foreach (var number in numbers) {
                NodeCell cell = new NodeCell((byte)quantity) { Number = number };

                if (board.CanAdd(cell, row, column)) {
                    board.AddCell(cell, row, column);

                    if (AddOnCell(board, row, column + 1))
                        return true;

                    board.RemoveCell(row, column);
                }
            }
            return false;
        }

    }
}
