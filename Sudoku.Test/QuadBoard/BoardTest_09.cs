using Sudoku.Generates;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
namespace Sudoku.Test;

public class BoardTest_09 {
    private int quantity;
    private int switchMethodFunctionGenerator;
    private Board board;
    private NodeCell cell;
    private NodeCell cell2;
    private int root;

    [SetUp]
    public void Setup() {
        quantity = 9;
        switchMethodFunctionGenerator = 16;
        root = (int)Math.Sqrt(quantity);
        board = new Board(quantity);
    }

    [Test]
    public void BoardTest_MultiStructQuantitys() {
        Assert.That(board.GetQuantity(), Is.EqualTo(quantity));
    }

    [TestCase(5, 0, 0)]
    [TestCase(7, 4, 2)]
    [TestCase(1, 5, 6)]
    [TestCase(6, 3, 4)]
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

    [TestCase(7, 4, 5)]
    [TestCase(1, 1, 4)]
    [TestCase(4, 8, 7)]
    [TestCase(2, 7, 3)]
    [TestCase(5, 6, 4)]
    [TestCase(6, 2, 8)]
    public void BoardTest_CalculateCorrectGroupIndex(byte number, int lineIndex, int columnIndex) {
        cell = new NodeCell((byte)quantity) { Number = number };
        int expectedGroup = (lineIndex / root) * root + (columnIndex / root);

        board.AddCell(cell, lineIndex, columnIndex);
        Assert.Contains(cell, board.groups.GetGroups[expectedGroup].Cells);
    }


    [TestCase(7, 0, 0, 1, false)]
    [TestCase(7, 0, 0, 2, false)]
    [TestCase(7, 0, 0, 3, false)]
    [TestCase(7, 0, 0, 4, false)]
    [TestCase(7, 0, 0, 5, false)]
    [TestCase(7, 0, 0, 6, false)]
    [TestCase(7, 0, 0, 7, false)]
    [TestCase(7, 0, 0, 8, false)]
    [TestCase(7, 1, 0, 1, false)]
    public void BoardTest_CanAddSameNumbers(byte number, int lineIndex, int columnIndex, int nextColumnIndex, bool expectedBool) {
        cell = new NodeCell((byte)quantity) { Number = number };
        cell2 = new NodeCell((byte)quantity) { Number = number };

        board.AddCell(cell, lineIndex, columnIndex);
        Assert.That(board.CanAdd(cell2, lineIndex, nextColumnIndex), Is.EqualTo(expectedBool));
    }

    [TestCase(5, 0, 0, 0)]
    [TestCase(3, 1, 0, 0)]
    [TestCase(7, 4, 6, 0)]
    [TestCase(2, 2, 1, 0)]
    [TestCase(4, 0, 7, 0)]
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