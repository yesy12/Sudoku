using Sudoku.Nodes;
namespace Sudoku.Test;

public class TestNodeCellsGroups{
    private NodeCellsGroup Group;
    private NodeCell Cell;
    private int quantity = 9;
    [SetUp]
    public void Setup(){
        Group = new NodeCellsGroup(quantity);
    }

    [Test]
    public void TestAddCellsToGroup() {
        for (byte i = 1; i < quantity + 1; i++) { 
            Cell = new NodeCell();
            Cell.Number = i;
            Group.Add(Cell, i - 1);
        }

        for (int i = 0; i < quantity; i++)
            Assert.That((byte)(i + 1), Is.EqualTo(Group.Cells[i].Number));
        
    }


}