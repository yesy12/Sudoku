namespace Sudoku.Test.Nodes_.Quantity;
using Sudoku.Nodes;

public class TestNodeCell_16{
    private int quantity;
    private NodeCell Cell;

    [SetUp]
    public void Setup() {
        quantity = 16;
        Cell = new NodeCell((byte)quantity);
    }
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(10)]
    [TestCase(11)]
    [TestCase(12)]
    [TestCase(13)]
    [TestCase(14)]
    [TestCase(15)]
    [TestCase(16)]
    public void NodeCell_SetValidity(byte number) {
        Cell.Number = number;

        Assert.That(number, Is.EqualTo(Cell.Number));
    }
}
