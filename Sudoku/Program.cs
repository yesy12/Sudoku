using Sudoku.Nodes;
using System;

namespace Sudoku{
    internal static class Program {

        public static int quantity = 9;
        public static NodeCellsGroup Group = new NodeCellsGroup(quantity);

        private static void Main() {
            RandomNumberCell.Initialize(quantity);

            for (byte i = 1; i < quantity + 1; i++) 
                 Group.Add(RandomNumberCell.RandomNumber(), i - 1);

            foreach (var cell in Group.Cells)
                Console.Write($"{cell.Number} | " );
            
            Console.WriteLine("\nPossible Numbers:");
            RandomNumberCell.Initialize(quantity);

            foreach(byte n in RandomNumberCell.possibleNumbers)
                Console.Write($" {n}");

        }


    }
}