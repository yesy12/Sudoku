using System;

namespace Sudoku.Difficulty.group {
    public class DifficultyMedium : DifficultBase {
        public DifficultyMedium() : base(
            min4: 9, max4: 10,
            min9: 47, max9: 53
        ) { }
    }
}
