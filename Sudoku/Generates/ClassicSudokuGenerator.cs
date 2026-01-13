using Sudoku.Nodes;
using Sudoku.QuadBoard;

namespace Sudoku.Generates {
    public class ClassicSudokuGenerator : ISudokuGenerator {
        public ushort? seed { get; }
        private readonly int quantity;
        private readonly Random random;

        public ClassicSudokuGenerator(int quantity) {
            this.quantity = quantity;
            random = new Random();
            seed = null;
        }

        public ClassicSudokuGenerator(int quantity, ushort seed) {
            this.seed = seed;
            this.quantity = quantity;
            this.random = new Random(seed);
        }


        public void Generate(Board board) {
            board.Clear();

            GenerateFirstLine(board);

            if (!FillFromRow(board, 1))
                throw new Exception("Failed to generate sudoku");
        }

        private void GenerateFirstLine(Board Board) {
            byte[] numbers = Enumerable.Range(1, quantity)
                .Select(n => (byte)n)
                .OrderBy(_ => random.Next())
                .ToArray();

            for (int column = 0; column < quantity; column++) {
                NodeCell cell = new NodeCell((byte)quantity) { Number = numbers[column] };
                Board.AddCell(cell, 0, column);
            }
        }

        private bool FillFromRow(Board board, int row) {
            if (row >= quantity)
                return true;
            return AddOnCell(board, row, 0);
        }

        private bool AddOnCell(Board board, int row, int column) {
            if (column >= quantity)
                return FillFromRow(board, row + 1);

            var numbers = Enumerable.Range(1, quantity)
                .Select(n => (byte)n)
                .OrderBy(_ => random.Next());

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