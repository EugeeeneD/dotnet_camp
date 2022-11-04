using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    public class Wrapper
    {
        private List<int> _arr;
        private Dictionary<int, int> _frequencyTable;
        private int _arrLength;
        private int _lowerBracket;
        private int _UpperBracket;

        public Wrapper()
        {
        }

        public Wrapper(int arrLength, int lowerBracket, int UpperBracket)
        {
            _arr = new List<int>();
            _frequencyTable = new Dictionary<int, int>();
            ArrLength = arrLength;
            LowerBracket = lowerBracket;
            this.UpperBracket = UpperBracket;
        }

        public Dictionary<int, int> FrequencyTable { get => _frequencyTable; }

        public int LowerBracket { get => _lowerBracket; set => _lowerBracket = value; }
        public int UpperBracket { get => _UpperBracket; set => _UpperBracket = value; }
        public int ArrLength 
        { 
            get => _arrLength; 
            set
            {
                if (value < 0) { throw new ArgumentOutOfRangeException("Array length cannot be negative."); }
                _arrLength = value;
            }
        }

        public int this[int index]
        {
            get { return _arr[index]; }
            set 
            {
                if (value < LowerBracket || value > UpperBracket) { throw new ArgumentOutOfRangeException("Value out of range."); }
                _arr[index] = value; 
            }
        }

        public bool FillAnArr()
        {
            Random random = new Random();

            for (int i = 0; i < ArrLength; i++)
            {
                _arr.Add(random.Next(LowerBracket, UpperBracket + 1));
            }

            return true;
        }

        public bool GetFrequencyTable()
        {
            foreach (int item in _arr.Distinct())
            {
                _frequencyTable.Add(item, _arr.FindAll(x => x == item).Count);
            }

            return true;
        }

        public void PrintFrequencyTable()
        {
            Console.WriteLine($"Number - Amount of time its appears:");
            foreach (var item in _frequencyTable.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        public bool IsPrime(int n)
        {
            bool isPrime = true;

            if (n < 2) { return false; }

            for (int i = 2; i < n; i++)
            {
                if(n % i == 0) { isPrime = false; }
            }
            return isPrime;
        }

        public Dictionary<int, List<int>> GetSequenceOfPrimeNumbers()
        {
            Dictionary<int, List<int>> res = new Dictionary<int, List<int>>();

            int start = 0;
            bool started = false;

            for (int i = 0; i < ArrLength; i++)
            {
                if (IsPrime(_arr[i]))
                {
                    if (started)
                    {
                        res[start].Add(_arr[i]);
                    }
                    else
                    {
                        start = i;
                        res.Add(start, new List<int>() { _arr[i] });

                        started = true;
                    }
                }
                else
                {
                    started = false;
                }
            }

            res.OrderByDescending(x => x.Value.Count);

            return res;
        }

        public bool PrintSequencesOfPrimeNumbers(Dictionary<int, List<int>> dict)
        {
            var temp = GetSequenceOfPrimeNumbers();

            Console.WriteLine("\nSequences:");

            for (int i = 0; i < 2; i++)
            {
                temp.ElementAt(i).Value.ForEach(x => Console.Write($"{x} "));
                Console.WriteLine();
            }
            return true;
        }

        public override string ToString()
        {
            string res = "";

            foreach (var item in _arr)
            {
                res += $"{item} ";
            }

            return res;
        }
    }
}
