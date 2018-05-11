using System;
using System.Collections.Generic;

namespace FizzBuzzLib
{
    public class FizzBuzzer
    {
        private Dictionary<int, string> _replacements;

        public FizzBuzzer()
        {
            _replacements = new Dictionary<int, string>
            {
                { 3, "Fizz" },
                { 5, "Buzz" }
            };
        }

        public FizzBuzzer(Dictionary<int,string> replacements)
        {
            _replacements = replacements;
        }

        public string ProcessInt(int input)
        {
            var matches = new List<string>();
            foreach(var r in _replacements)
            {
                if (input % r.Key == 0) matches.Add(r.Value);
            }
            if (matches.Count > 0) return string.Join("", matches);
            return input.ToString();
        }

        public IEnumerable<string> FizzBuzz(int min, int max)
        {
            for (int i = min; i <= max; i++)
            {
                yield return ProcessInt(i);
            }
        }
    }
}
