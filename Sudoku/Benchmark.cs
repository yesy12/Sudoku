using Sudoku.Groups;
using Sudoku.Nodes;

namespace Sudoku {
    public class Benchmark {

        public Lines lines;
        public Columns columns;
        public GroupsStuct groups;

        private const int SCORE_CORRECT = 1;
        private const int SCORE_NOT_GENERATED = -1; 
        private const int SCORE_CONFLICT = -2;     

        public Benchmark(int quantity) {
            lines = new Lines(quantity);
            columns = new Columns(quantity);
            groups = new GroupsStuct(quantity); 
        }

        public void SetAll(Lines lines, Columns colomuns, GroupsStuct groups) {
            this.groups = groups;
            this.lines = lines;
            this.columns = colomuns;
        }

        public int Compare() {
            int score_Quantity = 0;
            NodeCellsGroup lineGroup = new NodeCellsGroup(lines.Groups.Length);
            NodeCellsGroup columnGroup = new NodeCellsGroup(columns.Groups.Length);
            NodeCellsGroup groupGroup = new NodeCellsGroup(groups.Groups.Length);

            for (int i = 0; i < lines.Groups.Length; i++) {
                lineGroup = lines.Groups[i];

                for (int k = 0; k < columns.Groups.Length; k++) { 
                    int groupIndex = (i / 3) * 3 + (k / 3);
                    int cellInGroupIndex = (i % 3) * 3 + (k % 3);

                    byte lineCellVal = lineGroup.Cells[k].Number;
                    byte columnCellVal = columns.Groups[k].Cells[i].Number;
                    byte groupColumnCellVal = groups.Groups[groupIndex].Cells[cellInGroupIndex].Number;

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
