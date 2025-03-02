using System;
using System.Collections.Generic;
using System.IO.Pipelines;
using System.Linq;
using System.Runtime.InteropServices;
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
        public static void Display<T,R>(this IEnumerable<T> items, Func<T, R> selector)
        {
            WindowsUtility.MaximizeConsoleWindow();
            Thread.Sleep(1000);
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
            //WindowsUtility.NavigateToStartOfTable();
            //PrintRow(properties.Select(p => BoldText(p.Name)).ToArray());

        }
        public static void DisplayAll<T>(this IEnumerable<T> items)
        {
            WindowsUtility.MaximizeConsoleWindow();
            Thread.Sleep(1000);
            LinqExtentionsHelpers.warmup();

            var properties = (items.First()).GetType().GetProperties();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.BackgroundColor = ConsoleColor.White;
            LinqExtentionsHelpers.PrintRow(properties?.Select(p => p.Name).ToArray()!);

            Console.ResetColor();
            LinqExtentionsHelpers.PrintLine();

            foreach (var item in items)
            {
                var values = properties.Select(p => p.GetValue(item).ToString() ?? string.Empty).ToArray();
                LinqExtentionsHelpers.PrintRow(values);
            }

            LinqExtentionsHelpers.PrintLine();
           // WindowsUtility.NavigateToStartOfTable();
            //PrintRow(properties.Select(p => BoldText(p.Name)).ToArray());

        }
        //public static void DisplayExcept<T, R>(this IEnumerable<T> items, Func<T, R> selector)
        //{
            

        //}
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
        private static readonly int TableWidth = Console.WindowWidth;

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


            int width = (TableWidth - columns.Length-1) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }
            Console.WriteLine();
            Console.WriteLine(row);

        }

        public static void warmup()
        {
            Console.Clear();
            PrintLine();
        }
    }
    

internal class WindowsUtility
    {
        // Import necessary Windows API functions
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // Constants for ShowWindow
        private const int SW_MAXIMIZE = 3;

        // Constants for SetWindowPos
        private static readonly IntPtr HWND_TOP = IntPtr.Zero;
        private const uint SWP_NOSIZE = 0x0001;
        private const uint SWP_NOMOVE = 0x0002;
        private const uint SWP_SHOWWINDOW = 0x0040;

        
        public static void MaximizeConsoleWindow()
        {
            // Get the handle to the console window
            IntPtr consoleWindow = GetConsoleWindow();

            if (consoleWindow != IntPtr.Zero)
            {
                // Maximize the console window
                ShowWindow(consoleWindow, SW_MAXIMIZE);

                // Optionally, set the console window to the topmost position
                SetWindowPos(consoleWindow, HWND_TOP, 0, 0, 0, 0, SWP_NOSIZE | SWP_NOMOVE | SWP_SHOWWINDOW);
            }
        }
        /// <summary>
        /// Automatically navigates to the start of the table.
        /// </summary>
        public static void NavigateToStartOfTable()
        {
            //Console.WriteLine("\nPress any key to navigate to the start of the table...");
            //Console.ReadKey(intercept: true);

            // Reset the cursor position to the top of the console
            Console.SetCursorPosition(0, 0);

            // Optionally, re-display the table headers
           // LinqExtentionsHelpers.PrintRow("ID", "Name", "Email", "City", "Country", "Salary", "Active");
            LinqExtentionsHelpers.PrintLine();
        }
    }
}
