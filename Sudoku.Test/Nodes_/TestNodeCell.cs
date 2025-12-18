namespace Sudoku.Test;
using Sudoku.Nodes;

public class TestNodeCell{
    NodeCell Cell;

    [SetUp]
    public void Setup() {
        Cell = new NodeCell();
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
    public void NodeCell_SetValidity(byte number) {
        Cell.Number = number;

        Assert.That(number, Is.EqualTo(Cell.Number));
    }
}
