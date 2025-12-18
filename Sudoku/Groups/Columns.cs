using Sudoku.Nodes;

namespace Sudoku.Groups {
    public class Columns : MultiStruct{
        
        public NodeCellsGroup[] ColumnsGroup;

        public Columns(int quantityColumns) : base(quantityColumns) {
        }

    }
}
