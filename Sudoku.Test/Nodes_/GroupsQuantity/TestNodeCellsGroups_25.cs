using Sudoku.Groups;
using Sudoku.Nodes;
namespace Sudoku.Test;

public class TestNodeCellsGroups{
    private NodeCellsGroup Group;
    private NodeCell Cell;
    private int quantity = 25;
    private static IEnumerable<TestCaseData> MinMaxAndRemovedNumber() {
        yield return new TestCaseData(
            (byte)1,(byte)25,
            new byte[] { 1, 3, 5 }
        ).SetName("Remove 1,3,5 and generate 1 a 25");

        yield return new TestCaseData(
            (byte) 3, (byte) 7,
            new byte[] {3,5,6}
        ).SetName("Remove 3,5,6 and generate 3 a 7");

        yield return new TestCaseData(
            (byte)1, (byte)5,
            new byte[] {3,2,4}
        ).SetName("Removing 2,3,4 and generate 1 a 5");
    }

    [SetUp]
    public void Setup(){
        Group = new NodeCellsGroup(quantity);
    }

    [Test]
    public void TestAddCellsToGroup() {
        for (byte i = 1; i < quantity + 1; i++) {
            Cell = new NodeCell((byte)quantity);
            Cell.Number = i;
            Group.Add(Cell, i - 1);
        }

        for (int i = 0; i < quantity; i++)
            Assert.That((byte)(i + 1), Is.EqualTo(Group.Cells[i].Number));
    }

    [TestCase(1, false)][TestCase(2, false)][TestCase(3, false)][TestCase(4, false)][TestCase(5, false)]
    [TestCase(6, false)][TestCase(7, false)][TestCase(8, false)][TestCase(9, false)][TestCase(10, false)]
    [TestCase(11, false)][TestCase(12, false)][TestCase(13, false)][TestCase(14, false)][TestCase(15, false)]
    [TestCase(16, false)][TestCase(17, false)][TestCase(18, false)][TestCase(19, false)][TestCase(20, false)]
    [TestCase(21, false)][TestCase(22, false)][TestCase(23, false)][TestCase(24, false)][TestCase(25, false)]

    public void TestNodeCellsGroupsCanAdd_False(byte number, bool expectedReturn) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Group.Add(Cell, 0);
        Assert.That(Group.CanAdd(Cell), Is.EqualTo(expectedReturn));
    }

    [TestCase(1, true)][TestCase(2, true)][TestCase(3, true)][TestCase(4, true)][TestCase(5, true)]
    [TestCase(6, true)][TestCase(7, true)][TestCase(8, true)][TestCase(9, true)][TestCase(10, true)]
    [TestCase(11, true)][TestCase(12, true)][TestCase(13, true)][TestCase(14, true)][TestCase(15, true)]
    [TestCase(16, true)][TestCase(17, true)][TestCase(18, true)][TestCase(19, true)][TestCase(20, true)]
    [TestCase(21, true)][TestCase(22, true)][TestCase(23, true)][TestCase(24, true)][TestCase(25, true)]
    public void TestNodeCellsGroupsCanAdd_True(byte number, bool expectedReturn) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Assert.That(Group.CanAdd(Cell), Is.EqualTo(expectedReturn));
    }

    [TestCase(1)][TestCase(2)][TestCase(3)][TestCase(4)][TestCase(5)]
    [TestCase(6)][TestCase(7)][TestCase(8)][TestCase(9)][TestCase(10)]
    [TestCase(11)][TestCase(12)][TestCase(13)][TestCase(14)][TestCase(15)]
    [TestCase(16)][TestCase(17)][TestCase(18)][TestCase(19)][TestCase(20)]
    [TestCase(21)][TestCase(22)][TestCase(23)][TestCase(24)][TestCase(25)]
    public void TestNodeCellsGroupsRemove(byte number) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Group.Add(Cell, 0);
        Group.Remove(0);
        foreach (var cell in Group.Cells)
            Assert.That(cell.Number, Is.Not.EqualTo(number));
    }

    [TestCaseSource(nameof(MinMaxAndRemovedNumber))]
    public void TestNodeCellsGroupsRemovingNumber(byte minNumber, byte maxNumber, byte[] arrayNumbersRemoved) {
        for (byte i = minNumber; i <= maxNumber; i++){
            Cell = new NodeCell((byte)quantity);
            Cell.Number = i;
            Group.Add(Cell, i-1);
        }

        foreach(byte numberRemoved in arrayNumbersRemoved) 
            Group.Remove(numberRemoved-1);

        foreach(var cell in Group.Cells)
            foreach(byte numberRemoved in arrayNumbersRemoved)
                Assert.That(cell.Number, Is.Not.EqualTo(numberRemoved));
    }

}