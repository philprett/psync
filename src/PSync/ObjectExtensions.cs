using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSync
{
    internal static class ObjectExtensions
    {
        public static void SetRandom(this long longValue)
        {
            var random = new Random();
            longValue = (long)random.Next() << 32;
            longValue = longValue | (long)random.Next();
        }

        public static int GetInt(this string strValue)
        {
            return int.Parse(strValue);
        }
    }
}
