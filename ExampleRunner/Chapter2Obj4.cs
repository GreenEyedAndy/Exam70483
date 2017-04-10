using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ConsoleDump;

namespace ExampleRunner
{
    /// <summary>
    /// Creating and implementing an interface
    /// </summary>
    public class Example2_41 : Example
    {
        interface IExample
        {
            string GetResult();
            int Value { get; set; }
            event EventHandler ResultRetrieved;
            int this[string index] { get; set; }
        }

        public class ExampleImplementation : IExample
        {
            public string GetResult()
            {
                return "result";
            }

            public int Value { get; set; }

            public event EventHandler ResultRetrieved;

            public int this[string index]
            {
                get { return 42; }
                set { }
            }
        }

        public override void Run()
        {
            var ex = new ExampleImplementation();
            ex["Test"].Dump();
        }
    }

    /// <summary>
    /// Instantiating a concrete type that implements an interface
    /// </summary>
    public class Example2_44 : Example
    {
        interface IAnimal
        {
            void Move();
        }

        public class Dog : IAnimal
        {
            public void Move()
            {
              
            }

            public void Bark()
            {
                
            }
        }

        public override void Run()
        {
            IAnimal animal = new Dog();
            animal.Move();  // OK
            //animal.Bark();  // Error
        }
    }

    /// <summary>
    /// Creating a base class
    /// </summary>
    public class Example2_45 : Example
    {
        interface IEntity
        {
            int Id { get; }
        }

        class Repository<T> where T : IEntity
        {
            protected IEnumerable<T> elements;

            public Repository(IEnumerable<T> elements)
            {
                this.elements = elements;
            }

            public T FindById(int id)
            {
                return elements.SingleOrDefault(e => e.Id == id);
            }
        }

        class Order : IEntity {
            public int Id { get; }
        }

        class OrderRepository : Repository<Order>
        {
            public OrderRepository(IEnumerable<Order> orders) : base(orders)
            {
            }

            public IEnumerable<Order> FilterOrdersOnAmount(decimal amount)
            {
                List<Order> result = null;
                // Some filtering code
                return result;
            }
        }

        public override void Run()
        {
            "Please look at the code".Dump("No output");
        }
    }

    /// <summary>
    /// Overriding a virtual method
    /// </summary>
    public class Example2_47 : Example
    {
        class Base
        {
            public virtual void Execute()
            {
                "Execute".Dump();
            }
        }

        class Derived : Base
        {
            public override void Execute()
            {
                Log("Before executing");
                base.Execute();
                Log("After executing");
            }

            private void Log(string afterExecuting)
            {
                afterExecuting.Dump();
            }
        }

        public override void Run()
        {
            Base test = new Derived();
            test.Execute();
        }
    }

    /// <summary>
    /// Hiding a method with the new keyword
    /// </summary>
    public class Example2_48 : Example
    {
        class Base
        {
            public virtual void Execute()
            {
                "Base.Execute".Dump();
            }
        }

        class Derived : Base
        {
            public new void Execute()
            {
                "Derived.Execute".Dump();
            }
        }

        public override void Run()
        {
            Base b = new Base();
            b.Execute();
            b = new Derived();
            b.Execute();
        }
    }

    public class Example2_56 : Example
    {
        class Person
        {
            public Person(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string LastName { get; set; }

            public string FirstName { get; set; }

            public override string ToString()
            {
                return FirstName + " " + LastName;
            }
        }

        class People : IEnumerable<Person>
        {
            private Person[] people;

            public People(Person[] people)
            {
                this.people = people;
            }

            public IEnumerator<Person> GetEnumerator()
            {
                for (int index = 0; index < people.Length; index++)
                {
                    yield return people[index];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        public override void Run()
        {
            Person[] people = new Person[] {new Person("Andreas", "Patock"), new Person("Mohsen", "Amini"),};
            var myPeople = new People(people);
            foreach (var person in myPeople)
            {
                person.Dump();
            }
        }
    }
}