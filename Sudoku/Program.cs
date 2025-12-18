using Sudoku.Nodes;
using System;

namespace Sudoku
{
    internal static class Program {

        public static NodeCell Cell = new NodeCell();
        private static void Main() {
            Cell.Number = 5;

            Console.WriteLine($"Cell number is: {Cell.Number}");
        }
    }
}