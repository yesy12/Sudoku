using Sudoku.Difficulty.group;

namespace Sudoku.Difficulty {
    public static class DifficultyFactory {

        public static IDifficulty Create(DifficultyLevel level) {
            return level switch {
                DifficultyLevel.VeryEasy => new DifficultyVeryEasy(),
                DifficultyLevel.Easy => new DifficultyEasy(),
                DifficultyLevel.Medium => new DifficultyMedium(),
                DifficultyLevel.Hard => new DifficultyHard(),
                DifficultyLevel.Expert => new DifficultyExpert(),
            };
        }
    }

}
