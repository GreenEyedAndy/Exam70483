using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

    /// <summary>
    /// Covariance with delegates
    /// </summary>
    public class Example1_77 : Example
    {
        public delegate TextWriter CovarianceDel();

        public StreamWriter MethodStream()
        {
            return null;
        }

        public StringWriter MethodString()
        {
            return null;
        }

        public override void Run()
        {
            CovarianceDel del;
            del = MethodStream;
            del = MethodString;
        }
    }

    /// <summary>
    /// Contravariance with delegates
    /// </summary>
    public class Example1_78 : Example
    {
        void DoSomething(TextWriter tw) { }

        public delegate void ContraVarianceDel(StreamWriter tw);

        public override void Run()
        {
            ContraVarianceDel del = DoSomething;
        }
    }

    /// <summary>
    /// Lambda expression to create a delegate
    /// </summary>
    public class Example1_79 : Example
    {
        public delegate int Calculate(int x, int y);

        public override void Run()
        {
            Calculate calc = (x, y) => x + y;
            Console.WriteLine(calc(3, 4));

            calc = (x, y) => x * y;
            Console.WriteLine(calc(3, 4));
        }
    }

    /// <summary>
    /// Creating a lambda expression with multiple statements
    /// </summary>
    public class Example1_80 : Example
    {
        public delegate int Calculate(int x, int y);

        public override void Run()
        {
            Calculate calc = (x, y) =>
            {
                Console.WriteLine("Adding numbers");
                return x + y;
            };

            Console.WriteLine(calc(3, 4));
        }
    }

    /// <summary>
    /// Using the Action delegate
    /// </summary>
    public class Example1_81 : Example
    {
        public override void Run()
        {
            Action<int, int> calc = (x, y) =>
            {
                Console.WriteLine(x + y);
            };

            calc(3, 4);
        }
    }
}
