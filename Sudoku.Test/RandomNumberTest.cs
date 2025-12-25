namespace Sudoku.Test;

public class RandomNumberTest{
    private byte[] possibleNumbers;

    [TestCase(9)]
    [TestCase(8)]
    [TestCase(7)]
    [TestCase(6)]
    [TestCase(5)]
    [TestCase(4)]
    [TestCase(3)]
    [TestCase(2)]
    [TestCase(1)]
    public void RandomNumberTest_Initialize(byte numberMax) {
        RandomNumberCell.Initialize(numberMax);
        possibleNumbers = RandomNumberCell.GetPossibleNumbers();
        for (byte i = 1; i <= numberMax; i++)
            Assert.That(possibleNumbers[i-1], Is.EqualTo(i));        
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
    public void RandomNumberTest_AddNumber(byte numberAdd) {
        RandomNumberCell.AddNumber(numberAdd);
        possibleNumbers = RandomNumberCell.GetPossibleNumbers();
        for (byte i = 1; i <= numberAdd; i++)
            Assert.That(possibleNumbers[i - 1], Is.EqualTo(i));
    }

    [TestCase(0)]
    [TestCase(1)]
    [TestCase(2)]
    [TestCase(3)]
    [TestCase(4)]
    [TestCase(5)]
    [TestCase(6)]
    [TestCase(7)]
    [TestCase(8)]
    [TestCase(9)]
    public void RandomNumberTest_RemoveNumber(byte numberRemoved) {
        RandomNumberCell.Initialize(9);
        RandomNumberCell.RemoveNumber(numberRemoved);
        possibleNumbers = RandomNumberCell.GetPossibleNumbers();
        for (byte i = 0; i < possibleNumbers.Length; i++)
            Assert.That(possibleNumbers[i], Is.Not.EqualTo(numberRemoved));
    }

    [Test]
    public void RandomNumberTest_RandomUnique() {
        RandomNumberCell.Initialize(9);
        byte random = RandomNumberCell.RandomNumber();
        possibleNumbers = RandomNumberCell.GetPossibleNumbers();
        for (byte i = 0; i < possibleNumbers.Length; i++)
            Assert.That(possibleNumbers[i], Is.Not.EqualTo(random));
    }

    [Test]
    public void RandomNumberTest_RandomAll() {
        int maxNumber = 9;
        RandomNumberCell.Initialize((byte)maxNumber);
        byte[] random = new byte[maxNumber];
        for (int i = 0; i < maxNumber; i++) 
            random[i] = RandomNumberCell.RandomNumber();
        
        possibleNumbers = RandomNumberCell.GetPossibleNumbers();        
        for (byte i = 0; i < possibleNumbers.Length; i++)
            Assert.That(possibleNumbers[i], Is.Not.EqualTo(random[i]));
    }

}