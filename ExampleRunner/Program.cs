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
            Console.WriteLine("Enter example number [x_yz]: ");
            var readLine = Console.ReadLine();
            var exampleToSearch = readLine.TrimEnd();
            if (readLine != null)
            {
                ExampleCaller.RunExample(exampleToSearch);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
