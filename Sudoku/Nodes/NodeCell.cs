namespace Sudoku.Nodes {
    public class NodeCell {
        private byte number;
        private byte maxNumber;

        public NodeCell(byte maxNumber) {
            this.number = 0;
            this.maxNumber = maxNumber;
        }

        public byte Number {
            get => this.number;
            set {
                if (value == 0 || value > maxNumber) 
                    throw new ArgumentOutOfRangeException(nameof(value), $"Number:{value} must be between 1 and {maxNumber}");
                this.number = value;
            }
        }
    }
}
