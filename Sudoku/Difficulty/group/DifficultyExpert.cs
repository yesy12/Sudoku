using System;

namespace Sudoku.Difficulty.group {
    public class DifficultyExpert : DifficultBase {
        public DifficultyExpert() : base(
            min4: 13, max4: 13,
            min9: 59, max9: 64
        ) { }
    }
}