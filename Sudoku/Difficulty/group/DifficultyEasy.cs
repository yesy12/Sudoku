using System;

namespace Sudoku.Difficulty.group {
    public class DifficultyEasy : DifficultBase {
        public DifficultyEasy() : base(
            min4: 7, max4: 8,
            min9: 41, max9: 46
        ) { }
    }
}