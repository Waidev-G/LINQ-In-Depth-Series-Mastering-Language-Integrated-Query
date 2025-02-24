using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaidevEpisodes
{
    public static class LinqExtentions
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
        public static void Display<T>(this IEnumerable<T> items, Func<T, object> selector)
        {
            LinqExtentionsHelpers.warmup();

            var properties = selector(items.First()).GetType().GetProperties();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;
            LinqExtentionsHelpers.PrintRow(properties.Select(p =>p.Name).ToArray());
            
            Console.ResetColor();
            LinqExtentionsHelpers.PrintLine();

            foreach (var item in items)
            {
                var values = properties.Select(p => p.GetValue(selector(item))?.ToString() ?? string.Empty).ToArray();
                LinqExtentionsHelpers.PrintRow(values);
            }

            LinqExtentionsHelpers.PrintLine();
            //PrintRow(properties.Select(p => BoldText(p.Name)).ToArray());

        }
        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            foreach(var item in source)
            {
                yield return selector(item);
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource,int, TResult> selector)
        {
            var index = 0;
            foreach (var item in source)
            {
                yield return selector(item,index);
                index++;
            }
        }





    }
    internal static class LinqExtentionsHelpers
    {
        private const int TableWidth = 100;

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
        public static string BoldText(string text)
        {
            // ANSI escape code for bold text
            return "\x1b[1m" + text + "\x1b[0m";
        }

        public static void PrintLine()
        {
            Console.WriteLine(new string('-', TableWidth));
        }

        public static void PrintRow(params string[] columns)
        {


            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);

        }

        public static void warmup()
        {
            Console.Clear();
            PrintLine();
        }
    }
}
