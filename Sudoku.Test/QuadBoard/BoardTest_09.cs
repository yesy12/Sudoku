using Sudoku.Difficulty;
using Sudoku.Difficulty.group;
using Sudoku.Generates;
using Sudoku.Nodes;
using Sudoku.QuadBoard;
using Sudoku.Solvers;
namespace Sudoku.Test;

public class BoardTest_09 {
    private int quantity;
    private int switchMethodFunctionGenerator;
    private Board board;
    private NodeCell cell;
    private NodeCell cell2;
    private int root;
    private static ISudokuSolver solver;
    private static IDifficulty difficulty;
    private static SudokuPuzzleGenerator spg;

    [SetUp]
    public void Setup() {
        quantity = 9;
        switchMethodFunctionGenerator = 16;
        root = (int)Math.Sqrt(quantity);
        board = new Board(quantity);
        solver = new SudokuSolver(quantity);
        spg = new SudokuPuzzleGenerator(solver, quantity);
        difficulty = new DifficultyEasy();
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

        Assert.That(board.GetLines()[lineIndex].Cells[columnIndex], Is.SameAs(cell));
        Assert.That(board.GetColumns()[columnIndex].Cells[lineIndex], Is.SameAs(cell));
        Assert.That(board.GetGroups()[groupIndex].Cells[groupCellIndex], Is.SameAs(cell));
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
        Assert.Contains(cell, board.GetGroups()[expectedGroup].Cells);
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
        cell = new NodeCell((byte)quantity) { Number = number };

        board.AddCell(cell, lineIndex, columnIndex);
        board.RemoveCell(lineIndex, columnIndex);
        Assert.That(board.GetLines()[lineIndex].Cells[columnIndex].Number, Is.EqualTo(expectedNumber));
        Assert.That(board.CanAdd(cell, lineIndex, columnIndex), Is.True);
    }

    [Test]
    public void BoardTest_SudokuGenerator() {
        var Generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
        Generator.Generate(board);

        Assert.That(board.IsComplete(), Is.EqualTo(true));
    }

    [Test]
    public void BoardTest_Clone() {
        var Generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
        Generator.Generate(board);
        Board clone = board.Clone();
        Assert.That(clone.GetQuantity(), Is.EqualTo(quantity));

        for (int line = 0; line < quantity; line++)
            for (int col = 0; col < quantity; col++)
                Assert.That(clone.GetLines()[line].Cells[col].Number, Is.EqualTo(board.GetLines()[line].Cells[col].Number));
    }

    [Test]
    public void BoardTest_Clone_Removed() {
        var Generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
        Generator.Generate(board);

        ushort MinRemovableNumbers = difficulty.MinRemovableNumbers(quantity);
        ushort MaxRemovableNumbers = difficulty.MaxRemovableNumbers(quantity);
        ushort removed = 0;

        spg.RemoveNumbers(board, difficulty);

        for (int line = 0; line < quantity; line++)
            for (int col = 0; col < quantity; col++)
                if (board.GetLines()[line].Cells[col].Number == 0)
                    removed++;

        Assert.That(removed, Is.InRange(MinRemovableNumbers, MaxRemovableNumbers));
    }

    [Test]
    public void BoardTest_UniqueSolution_AfterRemove() {
        var Generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
        Generator.Generate(board);

        spg.RemoveNumbers(board, difficulty);

        Board clone = board.Clone();
        Assert.That(solver.HasUniqueSolution(clone), Is.True);
    }

    [TestCase(typeof(DifficultyVeryEasy))]
    [TestCase(typeof(DifficultyEasy))]
    [TestCase(typeof(DifficultyMedium))]
    [TestCase(typeof(DifficultyHard))]
    [TestCase(typeof(DifficultyExpert))]
    public void BoardTest_TestRemovedNumber(Type difficult_) {
        var Generator = SudokuGeneratorFactory.Create(quantity, switchMethodFunctionGenerator);
        Generator.Generate(board);

        ushort MinRemovableNumbers = difficulty.MinRemovableNumbers(quantity);
        ushort MaxRemovableNumbers = difficulty.MaxRemovableNumbers(quantity);

        spg.RemoveNumbers(board, difficulty);
        Assert.That(board.QuantityRemoved(), Is.InRange(MinRemovableNumbers, MaxRemovableNumbers));
    }
}