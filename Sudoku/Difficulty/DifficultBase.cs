using System;

namespace Sudoku.Difficulty {
    public abstract class DifficultBase : IDifficulty {

        protected readonly Dictionary<int, (ushort Min, ushort Max)> ranges;

        public DifficultBase(ushort min4, ushort max4, ushort min9, ushort max9) {
            ranges = new Dictionary<int, (ushort Min, ushort Max)> {
                { 4, (min4, max4)},
                { 9, (min9, max9)},
            };
        }

        public ushort MinRemovableNumbers(int value) => ranges[value].Min;
        public ushort MaxRemovableNumbers(int value) => ranges[value].Max;

    }
}
