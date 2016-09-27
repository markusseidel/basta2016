using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternMatching
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        static void DoMagic(object val)
        {
            // Using 'is' with the pattern 'null'
            if (val is null)
                return;

            if (!(val is Wand w))
                return;

            // It will be possible to do this in the future, but not yet
            // in preview 4 - the scoping isn't right yet, similar to
            // out variables.
            //w.Simsalabim();
        }

        static void DoMagic_(object val) { 
            // note that none of the type matching patterns accept null as a value
            // so the null case can be reached
            // Important: the first matching case is used, so the order matters!
            // 'default' is always evaluated last.
            switch (val) {
                case Wand w:
                    w.Simsalabim();
                    break;
                case MagicBall b:
                    b.Look();
                    break;
                case Potion p:
                    p.Drink();
                    break;
                case null:
                    throw new ArgumentNullException(nameof(val));
                default:
                    Console.WriteLine("Not sure how to do magic with this object");
                    break;
            }
        }

        public class Wand {
            public void Simsalabim() { }
        }

        public class MagicBall {
            public void Look() { }
        }

        public class Potion
        {
            public void Drink() { }
        }
    }
}
