using Sudoku.Groups;
using Sudoku.QuadBoard;
using Sudoku.Nodes;
using System;

namespace Sudoku{
    internal static class Program {

        public static int quantity = 9;
        public static Board board = new Board(quantity);
        private static void Main() {

            for (int i = 0; i < quantity; i++) {
                for (int j = 0; j < quantity; j++) {
                    var cell = new NodeCell();
                    byte value = (byte)((i * 3 + i / 3 + j) % (quantity) + 1);
                    
                    cell.Number = value;
                    board.AddCell(cell,  i, j);

                }
            }

            board.LineToString();
            Console.WriteLine();
            board.ColumnToString();
            Console.WriteLine();
            board.GroupToString();

        }


    }
}