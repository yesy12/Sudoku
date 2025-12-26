namespace Sudoku.Test.Nodes_.Quantity;
using Sudoku.Nodes;

public class TestNodeCell_25{
    private int quantity;
    private NodeCell Cell;

    [SetUp]
    public void Setup() {
        quantity = 25;
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
    [TestCase(9)]
    [TestCase(10)]
    [TestCase(11)]
    [TestCase(12)]
    [TestCase(13)]
    [TestCase(14)]
    [TestCase(15)]
    [TestCase(16)]
    [TestCase(17)]
    [TestCase(18)]
    [TestCase(19)]
    [TestCase(20)]
    [TestCase(21)]
    [TestCase(22)]
    [TestCase(23)]
    [TestCase(24)]
    [TestCase(25)]
    public void NodeCell_SetValidity(byte number) {
        Cell.Number = number;

        Assert.That(number, Is.EqualTo(Cell.Number));
    }
}
