using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ExampleCaller.RunExample("1_76");


            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
