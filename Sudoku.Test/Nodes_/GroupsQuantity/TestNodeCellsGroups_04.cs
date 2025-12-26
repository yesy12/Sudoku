using Sudoku.Groups;
using Sudoku.Nodes;
namespace Sudoku.Test.Nodes_.GroupsQuantity;

public class TestNodeCellsGroups_04{
    private NodeCellsGroup Group;
    private NodeCell Cell;
    private int quantity = 4;
    private static IEnumerable<TestCaseData> MinMaxAndRemovedNumber() {
        yield return new TestCaseData(
            (byte)1,(byte)4,
            new byte[] { 1, 3, 2}
        ).SetName("Remove 1,3,2 and generate 1 a 4");

        yield return new TestCaseData(
            (byte) 3, (byte) 4,
            new byte[] {3}
        ).SetName("Remove 3 and generate 3 a 4");

        yield return new TestCaseData(
            (byte)1, (byte)4,
            new byte[] {3,2,4}
        ).SetName("Removing 2,3,4 and generate 1 a 4");
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

    [TestCase(1, false)][TestCase(2, false)][TestCase(3, false)]
    [TestCase(4, false)]
    public void TestNodeCellsGroupsCanAdd_False(byte number, bool expectedReturn) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Group.Add(Cell, 0);
        Assert.That(Group.CanAdd(Cell), Is.EqualTo(expectedReturn));
    }

    [TestCase(1, true)][TestCase(2, true)][TestCase(3, true)]
    [TestCase(4, true)]
    public void TestNodeCellsGroupsCanAdd_True(byte number, bool expectedReturn) {
        Cell = new NodeCell((byte)quantity);
        Cell.Number = number;
        Assert.That(Group.CanAdd(Cell), Is.EqualTo(expectedReturn));
    }

    [TestCase(1)][TestCase(2)][TestCase(3)]
    [TestCase(4)]
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