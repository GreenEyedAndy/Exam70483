using System;
using System.Collections.Generic;
using System.Linq;

namespace ExampleRunner
{
    public static class ExampleCaller
    {
        private static IEnumerable<Type> allExamples;

        static ExampleCaller()
        {
            allExamples = GetAllExamples();
        }

        private static IEnumerable<Type> GetAllExamples()
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => p.IsClass && typeof(Example).IsAssignableFrom(p));
        }

        public static void RunExample(string name)
        {
            var type = allExamples.FirstOrDefault(e => e.Name.EndsWith(name));
            if (type != null)
            {
                var example = Activator.CreateInstance(type) as Example;
                if (example != null)
                {
                    example.Run();
                }
            }
            else
            {
                Console.WriteLine($"Example {name} not found!");
            }
        }
    }
}