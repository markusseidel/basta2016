using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutVariables
{
    class Program
    {
        static void Main(string[] args)
        {
            // This doesn't work yet in preview 4, but should later, when the 
            // variable is scoped to the local method
            //ReturnValue(out int val);
            //Console.WriteLine($"Value is {val}");

            // This one works even now because the value is only used in the scope
            // of the same if statement where it is created
            if (int.TryParse("42", out int val))
            {
                Console.WriteLine($"Parsed value {val}");
            }

            // Wildcards might become possible in the future - perhaps 
            // I don't care about one of the values. 
            //GetValues(out string important, out string *);


        }

        static void ReturnValue(out int x)
        {
            x = 42;
        }
    }
}
