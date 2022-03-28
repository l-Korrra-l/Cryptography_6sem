using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class CharNum
    {
        private char _ch;
        private int _numberInWord;

        public char Ch
        {
            get { return _ch; }
            set
            {
                if (_ch == value)
                    return;
                _ch = value;
            }
        }
        public int NumberInWord
        {
            get { return _numberInWord; }
            set
            {
                if (_numberInWord == value)
                    return;
                _numberInWord = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string firstKey = "Мергель".ToUpper();
            string secondKey = "КАРАЛІНА";
            string stringUser = "НАД ШЭРАЙ КУЧАЙ ЗЯМЛI ПАД ПЛОТАМ ПЕРАСТАЛI ЎЗЛЯТАЦЬ УГОРУ ДРОБНЫЯ КАМЯКI I ПАКАЗАЛАСЯ АБЛЕЗЛАЯ ПIЛОТКА I КIРПАТЫ, АПЕЧАНЫ СОНЦАМ ТВАР";
            char[,] matrix = new char[secondKey.Length, firstKey.Length];
            int countSymbols = 0;
            char[] charsFirstKey = firstKey.ToCharArray();
            char[] charsSecondKey = secondKey.ToCharArray();
            char[] charStringUser = stringUser.ToCharArray();
            List<CharNum> listCharNumFirst =
                new List<CharNum>(firstKey.Length);

            List<CharNum> listCharNumSecond =
                new List<CharNum>(secondKey.Length);

            listCharNumFirst = FillListKey(charsFirstKey);
            listCharNumSecond = FillListKey(charsSecondKey);

            listCharNumFirst = FillingSerialsNumber(listCharNumFirst);
            listCharNumSecond = FillingSerialsNumber(listCharNumSecond);

            ShowKey(listCharNumFirst, "Первый ключ: ");
            ShowKey(listCharNumSecond, "Второй ключ: ");

            for (int i = 0; i < listCharNumSecond.Count; i++)
            {
                for (int j = 0; j < listCharNumFirst.Count; j++)
                {
                    matrix[i, j] = charStringUser[countSymbols++];
                }
            }

            ShowMatrix(matrix, "Первоначальное значение: ");

            countSymbols = 0;
            for (int i = 0; i < listCharNumSecond.Count; i++)
            {
                for (int j = 0; j < listCharNumFirst.Count; j++)
                {
                    matrix[listCharNumSecond[i].NumberInWord,
                       listCharNumFirst[j].NumberInWord] = charStringUser[countSymbols++];
                }
            }

            ShowMatrix(matrix, "Зашифрованное значение: ");

            Console.ReadKey();
        }

        #region Methods
        public static int GetNumberInThealphabet(char s)
        {
            string str = @"АБВГДЕЁЖЗІЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯ";

            int number = str.IndexOf(s);

            return number;
        }

        public static List<CharNum> FillListKey(char[] chars)
        {
            List<CharNum> listKey = new List<CharNum>(chars.Length);

            for (int i = 0; i < chars.Length; i++)
            {
                CharNum charNum = new CharNum()
                {
                    Ch = chars[i],
                    NumberInWord = GetNumberInThealphabet(chars[i])
                };

                listKey.Add(charNum);
            }
            return listKey;
        }
        public static void ShowKey(List<CharNum> listCharNum, string message)
        {
            Console.WriteLine(message);

            foreach (var i in listCharNum)
            {
                Console.Write(i.Ch + " ");
            }
            Console.WriteLine();

            foreach (var i in listCharNum)
            {
                Console.Write(i.NumberInWord + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
        public static List<CharNum> FillingSerialsNumber(
            List<CharNum> listCharNum)
        {
            int count = 0;

            var result = listCharNum.OrderBy(a =>
                a.NumberInWord);

            foreach (var i in result)
            {
                i.NumberInWord = count++;
            }

            return listCharNum;
        }
        public static void ShowMatrix(char[,] matrix, string message)
        {
            Console.WriteLine(message);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        #endregion Methods
    }

}