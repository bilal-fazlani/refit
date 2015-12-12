using System.Collections.Generic;
using System.Linq;

namespace System.Web
{
    static class Uri
    {
        static readonly Dictionary<char, int> hexDigits;

        static Uri()
        {
            hexDigits = new[] {
                '0', '1', '2', '3', '4', '5', '6', '7',
                '8', '9', 'a', 'b', 'c', 'd', 'e', 'f'
            }.Zip(Enumerable.Range(0, 0xf), (c, i) => new { c, i })
                .ToDictionary(k => k.c, v => v.i);
        }

        public static bool IsHexDigit(char c)
        {
            return hexDigits.ContainsKey(Char.ToLowerInvariant(c));
        }

        public static int FromHex(char digit)
        {
            if(!IsHexDigit(digit))
                throw new ArgumentOutOfRangeException("digit");

            return hexDigits[digit];
        }
    }
}