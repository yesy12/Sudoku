using Sudoku.Difficulty.group;

namespace Sudoku.Difficulty {
    public static class DifficultyFactory {

        internal static readonly Dictionary<DifficultyLevel, Func<IDifficulty>> map =
            new() {
                { DifficultyLevel.VeryEasy,  () => new DifficultyVeryEasy() },
                { DifficultyLevel.Easy,      () => new DifficultyEasy() },
                { DifficultyLevel.Medium,    () => new DifficultyMedium() },
                { DifficultyLevel.Hard,      () => new DifficultyHard() },
                { DifficultyLevel.Expert,    () => new DifficultyExpert() }
            };

        public static IDifficulty Create(DifficultyLevel level) {
            return map[level]();
        }
    }

}
