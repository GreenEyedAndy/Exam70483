using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ExampleRunner
{
    /// <summary>
    /// Using a delegate
    /// </summary>
    public class Example1_75 : Example
    {
        public delegate int Calculate(int x, int y);

        public int Add(int x, int y)
        {
            return x + y;
        }

        public int Multiply(int x, int y)
        {
            return x * y;
        }

        public override void Run()
        {
            Calculate calc = Add;
            Console.WriteLine(calc(3, 4));

            calc = Multiply;
            Console.WriteLine(calc(3, 4));
        }
    }

    /// <summary>
    /// A multicast delegate
    /// </summary>
    public class Example1_76 : Example
    {
        public void MethodOne()
        {
            Console.WriteLine("MethodOne");
        }

        public void MethodTwo()
        {
            Console.WriteLine("MethodTwo");
        }

        public delegate void Del();

        public override void Run()
        {
            Del d = MethodOne;
            d += MethodTwo;

            d();
            Console.WriteLine(d.GetInvocationList().GetLength(0));
        }
    }

    public class Example1_79 : Example
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }
    }
}
