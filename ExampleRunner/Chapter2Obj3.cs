using System;
using ConsoleDump;

namespace ExampleRunner
{
    /// <summary>
    /// Implicit interface implementation
    /// </summary>
    public class Example2_39 : Example
    {
        interface IInterfaceA
        {
            void MyMethod();
        }

        class Implementation : IInterfaceA
        {
            public void MyMethod()
            {
                Console.WriteLine("Output");
            }
        }

        public override void Run()
        {
            Implementation impl = new Implementation();
            impl.MyMethod();
        }
    }

    /// <summary>
    /// Exolicit interface implementation
    /// </summary>
    public class Example2_39a : Example
    {
        interface IInterfaceA
        {
            void MyMethod();
        }

        class Implementation : IInterfaceA
        {
            void IInterfaceA.MyMethod()
            {
                Console.WriteLine("Output");
            }
        }

        public override void Run()
        {
            Implementation impl = new Implementation();
            ((IInterfaceA)impl).MyMethod();
        }
    }

    public class Example2_40 : Example
    {
        interface ILeft
        {
            void Move();
        }

        interface IRight
        {
            void Move();
        }

        class MovableObject : ILeft, IRight
        {
            public int c;

            void ILeft.Move()
            {
                c--;
            }

            void IRight.Move()
            {
                c++;
            }
        }
        public override void Run()
        {
            MovableObject mo = new MovableObject();
            ((ILeft)mo).Move();
            mo.c.Dump();
            ((IRight)mo).Move();
            mo.c.Dump();
        }
    }
}