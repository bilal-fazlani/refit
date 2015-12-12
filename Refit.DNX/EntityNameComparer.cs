using System.Collections.Generic;

namespace System.Web
{
    class EntityNameComparer: IComparer<KeyValuePair<string, char>>
    {
        public int Compare(KeyValuePair<string, char> x, KeyValuePair<string, char> y)
        {
            return String.Compare(x.Key, y.Key, StringComparison.Ordinal);
        }
    }
}