using Sudoku.Groups;
using Sudoku.Nodes;

namespace Sudoku.Test.Groups;

public class ColumnGroupsTest{
    private int quantity;
    private Columns columns;
    private NodeCell Cell;
    private static IEnumerable<TestCaseData> GenerateMin_Max_RemovingNumbers() {
        yield return new TestCaseData(
            (byte)1, (byte)9,
            new byte[] { 1, 2, 3, 4 }
        ).SetName("Generate 1 to 9, Removing 1,2,3,4");

        yield return new TestCaseData(
            (byte)3, (byte)7,
            new byte[] { 3, 4,5, 6 }
        ).SetName("Generate 3 to 7, Removing 3,4,5,6");

        yield return new TestCaseData(
            (byte)1, (byte)7,
            new byte[] { 1, 2, 3, 4 }
        ).SetName("Generate 1 to 7, Removing 1,2,3,4");

        yield return new TestCaseData(
            (byte)3, (byte)9,
            new byte[] {  3, 4 }
        ).SetName("Generate 3 to 9, Removing 3,4");
    }

    [SetUp]
    public void Setup() {
        quantity = 9;
        columns = new Columns(quantity);        
    }

    [Test]
    public void ColumnsTestQuantity(){
        Assert.That(columns.GetQuantity(), Is.EqualTo(quantity));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    public void ColumnsTestAdd(int index) {
        for (int i = 0; i < columns.GetQuantity(); i++) {
            Cell = new NodeCell(columns.GetQuantity());
            Cell.Number = (byte)(i+1);
            columns.Add(Cell, index, i);            
        }
        NodeCell[] Cells = columns.GetGroups[index].Cells; 
        for (byte i = 0; i < quantity; i++) {
            Assert.That(Cells[i].Number, Is.EqualTo(i + 1));
        }
    }

    [TestCaseSource(nameof(GenerateMin_Max_RemovingNumbers))]
    public void ColumnsTestRemove(byte minNumber, byte maxNumber, byte[] arrayNumberRemoved) {
        for (byte i = minNumber; i <= maxNumber; i++) {
            Cell = new NodeCell((byte)quantity);
            Cell.Number = i;
            columns.Add(Cell, 0, i - 1);
        }

        foreach (byte numberRemoved in arrayNumberRemoved)
            columns.Remove(0, numberRemoved - 1);

        for (int i = 0; i < columns.GetGroups[0].Cells.Length; i++)
            foreach (byte numberRemoved in arrayNumberRemoved)                
                Assert.That(columns.GetGroups[0].Cells[i].Number, Is.Not.EqualTo(numberRemoved));                 
    }

    [TestCase(1, false)]
    [TestCase(2, false)]
    [TestCase(3, false)]
    [TestCase(4, false)]
    [TestCase(5, false)]
    [TestCase(6, false)]
    [TestCase(7, false)]
    [TestCase(8, false)]
    [TestCase(9, false)]    
    public void ColumnTestCanAdd_FALSE(byte number, bool expectedBool) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        columns.Add(Cell, 0, number - 1);
        Assert.That(columns.CanAdd(Cell,0), Is.EqualTo(expectedBool));
    }

    [TestCase(1, true)]
    [TestCase(2, true)]
    [TestCase(3, true)]
    [TestCase(4, true)]
    [TestCase(5, true)]
    [TestCase(6, true)]
    [TestCase(7, true)]
    [TestCase(8, true)]
    [TestCase(9, true)]
    public void ColumnTestCanAdd_True(byte number, bool expectedBool) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Assert.That(columns.CanAdd(Cell, 0), Is.EqualTo(expectedBool));
    }
}