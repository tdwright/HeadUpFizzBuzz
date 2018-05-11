using FizzBuzzLib;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace HeadUpFizzBuzzFunction
{
    public static class Shared
    {
        internal static string HandleRequest(string num)
        {
            var fb = GetFizzBuzzer();
            string json;
            if (num != null && int.TryParse(num, out int n))
            {
                json = JsonConvert.SerializeObject(fb.ProcessInt(n));
            }
            else
            {
                var seq = fb.FizzBuzz(1, 100).ToArray();
                json = JsonConvert.SerializeObject(seq);
            }

            return json;
        }

        internal static FizzBuzzer GetFizzBuzzer()
        {
            var replacements = new Dictionary<int, string>
            {
                { 3, "Head" },
                { 5, "Up" }
            };
            var fb = new FizzBuzzer(replacements);
            return fb;
        }
    }
}
