using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        // Make sure to add *prerelease* nuget package System.ValueTuple - not included by default
        // in preview 4

        static void Main(string[] args)
        {
            var name1 = GetName();
            Console.WriteLine($"Name is {name1.Item1} {name1.Item2}");

            var name2 = GetName_();
            Console.WriteLine($"Name is {name2.first} {name2.last}");


            // Deconstructing tuple values
            (var first, var last) = GetName();
            
            // alternatively, 'var' can be outside the parens
            var (first_, last_) = GetName();
            
            // turns out a static type can *not* be outside the parens
            // -- on purpose?
            //string (first__, last__) = GetName();

            Console.WriteLine($"Name is {first} {last}");

            // Deconstructing my own type
            var person = new Person { Name = "Oli", Age = 32 };
            var (name, age) = person;

            Console.WriteLine($"{name} is {age} years old");

            // Wildcards may become an option in the future:
            // (*, var age_) = person;
        }

        static (string,string) GetName()
        {
            return ("Oliver", "Sturm");
        }

        static (string first, string last) GetName_()
        {
            // note that I'm using the wrong names for the return values
            // this works in preview 4, I expect it shouldn't really work...
            return (firstName: "Oliver", lastName: "Sturm");
        }

        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public void Deconstruct(out string name, out int age)
            {
                name = Name;
                age = Age;
            }
        }
    }
}
