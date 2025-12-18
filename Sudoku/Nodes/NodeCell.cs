namespace Sudoku.Nodes {
    public class NodeCell {
        private byte number;

        public NodeCell() {
            this.number = 0;
        }

        public byte Number {
            get => this.number;
            set {
                if (value == 0 || value > 9) 
                    throw new ArgumentOutOfRangeException(nameof(value), "Number must be between 1 and 9.");
                this.number = value;
            }
        }
    }
}
