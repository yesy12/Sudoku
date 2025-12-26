using Sudoku.Generates;
using Sudoku.Groups;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Sudoku{
    internal static class Program {

        public static byte quantity = 4;
        private static byte switchMethodFunctionGenerator = 16;
        public static Board Board = new Board(quantity);

        private static void Main() {
            var generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
            generator.Generate(Board);

            Console.WriteLine();
            Board.LineToString();
            Console.WriteLine();
            Board.ColumnToString();
            Console.WriteLine();
            Board.GroupsToString();
            Console.WriteLine();
        }
    }
}