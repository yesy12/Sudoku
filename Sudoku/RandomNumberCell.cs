namespace Sudoku {
    public static class RandomNumberCell {
        private static List<byte> possibleNumbers = new List<byte>();
        private static readonly Random rand = new Random();

        public static void Initialize(byte quantityPossibleNumbers) {
            possibleNumbers = new List<byte>();
            for (byte i = 1; i <= quantityPossibleNumbers; i++)
                possibleNumbers.Add(i);
        }

        public static byte[] GetPossibleNumbers() => possibleNumbers.ToArray();

        public static byte RandomNumber() {
            int index = rand.Next(0, possibleNumbers.Count);
            byte number = possibleNumbers[index];
            possibleNumbers.RemoveAt(index);
            return number;
        }

        public static void AddNumber(byte number) => possibleNumbers.Add(number);
        public static void RemoveNumber(byte number) => possibleNumbers.Remove(number);
    }
}
