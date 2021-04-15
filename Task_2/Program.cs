using System;
using System.Collections.Generic;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var sb = SimpleBinder.GetInstance() ?? throw new ArgumentNullException("Binder.GetInstance()");

            var gold = (Metal) sb.Bind(typeof(Metal), new Dictionary<string, string>
            {
                {"Name", "Gold"},
                {"Weight", "1000"},
                {"Price", "150.555"}
            });

            Console.WriteLine(gold);
        }
    }
}
