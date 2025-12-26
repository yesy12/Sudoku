using Sudoku.Nodes;
using Sudoku.QuadBoard;
using System;
using System.Collections.Generic;

namespace Sudoku.Generates {
    public class ClassicSudokuGenerator : ISudokuGenerator{

        private int quantity;
        public ClassicSudokuGenerator(int quantity) => this.quantity = quantity;            

        public void Generate(Board board) {
            GenerateFirstLine(board);            
            
            for(int i = 1; i < quantity; i++) 
                AddOnCell(board, i);
        }

        public void GenerateFirstLine(Board Board) {
            RandomNumberCell.Initialize((byte)quantity);
            for (int column = 0; column < quantity; column++) {
                NodeCell cell = new NodeCell((byte)quantity) { Number = RandomNumberCell.RandomNumber()};
                Board.AddCell(cell, 0, column);
            }
        }

        public bool AddOnCell(Board Board, int row, int column = 0) {
            if (column >= quantity) return true;
            for (byte number = 1; number <= quantity; number++) {
                NodeCell cell = new NodeCell((byte)quantity) { Number = number};                

                if (Board.CanAdd(cell, row, column)) {
                    Board.AddCell(cell, row, column);
                    if (AddOnCell(Board, row, column + 1))
                        return true;
                    Board.RemoveCell(row, column);
                }
            }
            return false;
        }

    }
}
