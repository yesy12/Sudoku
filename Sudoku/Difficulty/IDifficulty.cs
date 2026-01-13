namespace Sudoku.Difficulty {
    public interface IDifficulty {
        public ushort MinRemovableNumbers(int value);
        public ushort MaxRemovableNumbers(int value);
    }
}
