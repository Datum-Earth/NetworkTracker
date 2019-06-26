using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracker.CLI.Helpers
{
    internal static class ConsoleHelper
    {
        public static void WriteCollectionToConsole<T>(IEnumerable<T> elements)
        {
            foreach (var prop in typeof(T).GetProperties())
            {
                Console.Write(prop.Name + "\t");
            }

            Console.WriteLine();

            foreach (var e in elements)
            {
                foreach (var prop in typeof(T).GetProperties())
                {
                    var propVal = prop.GetValue(e);
                    Console.Write((propVal ?? "").ToString() + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}
