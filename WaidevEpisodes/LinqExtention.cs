using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes
{
    public static class LinqExtention
    {
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> list, Func<T, bool> condition)
        {
            foreach (var item in list)
            {
                if (condition(item))
                {
                    yield return item;
                }
            }
        }
    }
}
