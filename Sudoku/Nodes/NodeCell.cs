namespace Sudoku.Nodes {
    public class NodeCell {
        private byte number;
        private readonly byte maxNumber;
        private bool isFixed;

        public NodeCell(byte maxNumber) {
            this.number = 0;
            this.maxNumber = maxNumber;
            this.isFixed = false;
        }

        public byte Number {
            get => this.number;
            set {
                if (value == 0 || value > maxNumber)
                    throw new ArgumentOutOfRangeException(nameof(value), $"Number:{value} must be between 1 and {maxNumber}");
                if (isFixed)
                    throw new ArgumentException("Is Fixed Cells");
                this.number = value;
            }
        }

        public bool IsFixed {
            get => this.isFixed;
            set {
                this.isFixed = value;
            }
        }
    }
}
