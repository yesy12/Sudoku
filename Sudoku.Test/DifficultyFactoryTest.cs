using Sudoku.Difficulty;

namespace Sudoku.Test {
    internal class DifficultyFactoryTest {

        [TestCase(DifficultyLevel.VeryEasy)]
        [TestCase(DifficultyLevel.Easy)]
        [TestCase(DifficultyLevel.Medium)]
        [TestCase(DifficultyLevel.Hard)]
        [TestCase(DifficultyLevel.Expert)]
        public void DifficultyFactory_Test(DifficultyLevel level) {
            IDifficulty diff = DifficultyFactory.Create(level);
            Assert.That(diff, Is.Not.Null);
        }

    }
}
