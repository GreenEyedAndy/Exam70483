using System;
using ConsoleDump;

namespace ExampleRunner
{
    public class Example2_1 : Example
    {
        [Flags]
        public enum Days
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        public override void Run()
        {
            Days readingDays = Days.Monday | Days.Saturday;
            readingDays.Dump();
        }
    }

    /// <summary>
    /// Constructor chaining
    /// </summary>
    public class Example2_12 : Example
    {
        public class ConstructorChaining
        {
            private int p;

            public ConstructorChaining() : this(3) { }

            public ConstructorChaining(int p)
            {
                this.p = p;
            }

            public int P => p;
        }

        public override void Run()
        {
            var constructorChaining = new ConstructorChaining();
            constructorChaining.P.Dump("Standard Constructor");

            constructorChaining = new ConstructorChaining(5);
            constructorChaining.P.Dump("Special Constructor");
        }
    }

    /// <summary>
    /// Overriding virtual method
    /// </summary>
    public class Example2_17 : Example
    {
        public class Base
        {
            public virtual int MyMethod()
            {
                return 42;
            }
        }

        public class Derived : Base
        {
            public override int MyMethod()
            {
                return base.MyMethod() * 2;
            }
        }

        public override void Run()
        {
            Base b = new Derived();
            b.MyMethod().Dump();
        }
    }

}