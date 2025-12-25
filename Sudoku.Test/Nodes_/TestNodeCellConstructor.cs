using Sudoku.Nodes;
namespace Sudoku.Test;

public class TestNodeCellConstructor{
    private NodeCell Cell;
    private byte maxNumber;

    [SetUp]
    public void Setup(){
        maxNumber = 5;
        Cell = new NodeCell(maxNumber);
    }

    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    public void Test1(byte number) {
        Cell.Number = number;
        Assert.That(Cell.Number, Is.EqualTo(number));
    }
}