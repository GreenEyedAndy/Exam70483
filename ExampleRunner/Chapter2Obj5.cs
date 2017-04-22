using System;
using ConsoleDump;

namespace ExampleRunner
{
    /// <summary>
    /// Seeing whether an attribute is defined
    /// </summary>
    public class Example2_61 : Example
    {
        [Serializable]
        class Person { }

        public override void Run()
        {
            Attribute.IsDefined(typeof(Person), typeof(SerializableAttribute)).Dump();
        }
    }

    /// <summary>
    /// Adding properties to a custom attribute
    /// </summary>
    public class Example2_68 : Example
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
        class CompleteCustomAttribute : Attribute
        {
            public CompleteCustomAttribute(string description)
            {
                Description = description;
            }

            public string Description { get; set; }
        }

        [CompleteCustom("hallo")]
        class Person { }

        public override void Run()
        {
            Attribute.IsDefined(typeof(Person), typeof(CompleteCustomAttribute)).Dump();

        }
    }
}