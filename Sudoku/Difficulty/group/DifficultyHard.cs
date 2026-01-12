using System;

namespace Sudoku.Difficulty.group {
    public class DifficultyHard : DifficultBase {
        public DifficultyHard() : base(
            min4: 11, max4: 12,
            min9: 54, max9: 58
        ) { }
    }
}
