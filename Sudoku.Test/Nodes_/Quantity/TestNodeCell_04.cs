namespace Sudoku.Test.Nodes_.Quantity;
using Sudoku.Nodes;

public class TestNodeCell_04 {
    private int quantity;
    private NodeCell Cell;

    [SetUp]
    public void Setup() {
        quantity = 4;
        Cell = new NodeCell((byte)quantity);
    }
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    public void NodeCell_SetValidity(byte number) {
        Cell.Number = number;

        Assert.That(number, Is.EqualTo(Cell.Number));
    }

    [Test]
    public void NodeCell_IsFixed_Update() {
        Cell.Number = 1;
        Cell.IsFixed = true;

        Assert.That(Cell.IsFixed, Is.True);
    }

    [Test]
    public void NodeCell_IsFixed_UpdateValue() {
        Cell.Number = 1;
        Cell.IsFixed = true;

        Assert.Throws<ArgumentException>(() => {
            Cell.Number = 2;
        });
    }
}
