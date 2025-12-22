namespace Sudoku {
    public static class RandomNumberCell {

        private static int quantity;
        private static List<byte> possibleNumbers = new List<byte>();
        static Random rand = new Random();

        public static void Initialize(int quantityPossibleNumbers) {
            quantity = quantityPossibleNumbers;
            possibleNumbers = new List<byte>();

            for (int i = 0; i < quantity; i++)
                possibleNumbers.Add((byte)(i + 1));
        }

        public static void GetPossibleNumbers() {
            for (int i = 0; i < possibleNumbers.Count; i++)
                Console.Write($"{possibleNumbers[i]}");
            Console.WriteLine();
        }

        public static byte RandomNumber() {
                int index = rand.Next(0, possibleNumbers.Count);
                byte number = possibleNumbers[index];
                possibleNumbers.RemoveAt(index);
                return number;            
        }

        public static void AddNumber(byte number) {
            possibleNumbers.Add(number);
        }

        public static void RemoveNumber(byte number) {
            possibleNumbers.Remove(number);
        }
    }
}
