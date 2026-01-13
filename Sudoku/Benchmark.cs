using Sudoku.Groups;
using Sudoku.Nodes;
using Sudoku.QuadBoard;

namespace Sudoku {
    public class Benchmark {
        private Lines lines;
        private Columns columns;
        private GroupsStuct groups;

        private const int SCORE_CORRECT = 1;
        private const int SCORE_NOT_GENERATED = -1; 
        private const int SCORE_CONFLICT = -2;
        private byte quantity;
        private byte root;

        public Benchmark(int quantity) {
            this.quantity = (byte)quantity;
            root = (byte)Math.Sqrt(quantity);
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity); 
        }

        public void SetAll(Board board) {
            lines.setGroup(board.GetLines());
            columns.setGroup(board.GetColumns());
            groups.setGroup(board.GetGroups());
        }

        public int Compare() {
            int score_Quantity = 0;
            NodeCellsGroup lineGroup = new NodeCellsGroup(quantity);
            NodeCellsGroup columnGroup = new NodeCellsGroup(quantity);
            NodeCellsGroup groupGroup = new NodeCellsGroup(quantity);

            for (int i = 0; i < quantity; i++) {
                lineGroup = lines.GetGroups[i];                

                for (int k = 0; k < quantity; k++) { 
                    int groupIndex = (i / root) * root + (k / root);
                    int cellInGroupIndex = (i % root) * root + (k % root);

                    byte lineCellVal = lineGroup.Cells[k].Number;
                    byte columnCellVal = columns.GetGroups[k].Cells[i].Number;                    
                    byte groupColumnCellVal = groups.GetGroups[groupIndex].Cells[cellInGroupIndex].Number;

                    if (lineCellVal == 0)
                        score_Quantity += SCORE_NOT_GENERATED;
                    else if (lineCellVal == columnCellVal && lineCellVal == groupColumnCellVal)
                        score_Quantity += SCORE_CORRECT;
                    else 
                        score_Quantity += SCORE_CONFLICT;                    
                }

            }

            return score_Quantity;
        }
    }
}
