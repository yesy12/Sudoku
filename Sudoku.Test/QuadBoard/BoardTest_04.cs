using Sudoku.Generates;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
namespace Sudoku.Test;

public class BoardTest_04 {
    private int quantity;
    private int switchMethodFunctionGenerator;
    private Board board;
    private NodeCell cell;
    private NodeCell cell2;
    private int root;

    [SetUp]
    public void Setup() {
        quantity = 4;
        switchMethodFunctionGenerator = 16;
        root = (int)Math.Sqrt(quantity);
        board = new Board(quantity);
    }

    [Test]
    public void BoardTest_MultiStructQuantitys() {
        Assert.That(board.GetQuantity(), Is.EqualTo(quantity));
    }

    [TestCase(1, 0, 0)]
    [TestCase(2, 3, 2)]
    [TestCase(3, 3, 2)]
    [TestCase(4, 3, 0)]
    [TestCase(3, 1, 1)]
    public void BoardTest_InsertSameNodeCellInstance(byte number, int lineIndex, int columnIndex) {
        cell = new NodeCell((byte)quantity) { Number = number };
        board.AddCell(cell, lineIndex, columnIndex);

        int groupIndex = (lineIndex / root) * root + (columnIndex / root);
        int groupCellIndex = (lineIndex % root) * root + (columnIndex % root);

        Assert.That(board.lines.GetGroups[lineIndex].Cells[columnIndex], Is.SameAs(cell));
        Assert.That(board.columns.GetGroups[columnIndex].Cells[lineIndex], Is.SameAs(cell));
        Assert.That(board.groups.GetGroups[groupIndex].Cells[groupCellIndex], Is.SameAs(cell));
    }

    [TestCase(4, 2, 1)]
    [TestCase(1, 1, 3)]
    [TestCase(4, 0, 2)]
    [TestCase(1, 2, 3)]
    [TestCase(2, 3, 2)]
    [TestCase(4, 2, 1)]
    public void BoardTest_CalculateCorrectGroupIndex(byte number, int lineIndex, int columnIndex) {
        cell = new NodeCell((byte)quantity) { Number = number };
        int expectedGroup = (lineIndex / root) * root + (columnIndex / root);

        board.AddCell(cell, lineIndex, columnIndex);
        Assert.Contains(cell, board.groups.GetGroups[expectedGroup].Cells);
    }


    [TestCase(3, 0, 0, 1, false)]
    [TestCase(3, 0, 0, 2, false)]
    [TestCase(3, 0, 0, 3, false)]
    [TestCase(3, 0, 0, 3, false)]
    [TestCase(4, 0, 0, 2, false)]
    [TestCase(2, 0, 0, 1, false)]
    [TestCase(3, 0, 0, 2, false)]
    [TestCase(1, 0, 0, 3, false)]
    [TestCase(1, 1, 0, 1, false)]
    public void BoardTest_CanAddSameNumbers(byte number, int lineIndex, int columnIndex, int nextColumnIndex, bool expectedBool) {
        cell = new NodeCell((byte)quantity) { Number = number };
        cell2 = new NodeCell((byte)quantity) { Number = number };

        board.AddCell(cell, lineIndex, columnIndex);
        Assert.That(board.CanAdd(cell2, lineIndex, nextColumnIndex), Is.EqualTo(expectedBool));
    }

    [TestCase(4, 0, 0, 0)]
    [TestCase(3, 1, 0, 0)]
    [TestCase(3, 3, 0, 0)]
    [TestCase(2, 2, 1, 0)]
    [TestCase(4, 0, 1, 0)]
    public void BoardTest_RemoveNumbers(byte number, int lineIndex, int columnIndex, byte expectedNumber) {
        cell = new NodeCell((byte)quantity) { Number = number};

        board.AddCell(cell, lineIndex, columnIndex);
        board.RemoveCell(lineIndex, columnIndex);
        Assert.That(board.lines.GetGroups[lineIndex].Cells[columnIndex].Number, Is.EqualTo(expectedNumber));
        Assert.That(board.CanAdd(cell, lineIndex, columnIndex), Is.True);
    }

    [Test]
    public void BoardTest_SudokuGenerator() {
        var Generator = SudokuGeneratorFactory.Create(quantity,switchMethodFunctionGenerator);
        Generator.Generate(board);

        Assert.That(board.IsComplete(), Is.EqualTo(true));        
    }
}