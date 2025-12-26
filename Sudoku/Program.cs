using Sudoku.Groups;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
using System;
using System.Data.Common;
using System.Security.Cryptography.X509Certificates;

namespace Sudoku{
    internal static class Program {

        public static byte quantity = 16;
        public static Board Board = new Board(quantity);
        
        private static void Main() {

            GenerateFirstLine();
            for (int row = 1; row < quantity; row++)
                AddOnCell(row);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Board.LineToString();
            Console.WriteLine();
            Board.ColumnToString();
            Console.WriteLine();
            Board.GroupsToString();
            Console.WriteLine();
        }

        public static void GenerateFirstLine() {
            RandomNumberCell.Initialize(quantity);
            for (int column = 0; column < quantity; column++) {
                NodeCell cell = new NodeCell((byte)quantity);
                cell.Number = RandomNumberCell.RandomNumber();

                Board.AddCell(cell,0, column);
            }
        }
        public static bool AddOnCell(int row, int column = 0) {
            if (column >= quantity) return true;

            for (byte number = 1; number <= quantity; number++) {
                NodeCell cell = new NodeCell((byte)quantity);
                cell.Number = number;

                if (Board.CanAdd(cell, row, column)) {
                    Board.AddCell(cell, row, column);

                    if (AddOnCell(row, column + 1))
                        return true;

                    Board.RemoveCell(row, column);
                }
            }
            return false;
        }


    }
}