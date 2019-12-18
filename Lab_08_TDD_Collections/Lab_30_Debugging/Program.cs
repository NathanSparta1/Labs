#define NATHSTESTCODE
using System;
using System.Diagnostics;
using System.IO;


namespace Lab_30_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                doThis();
                var j = $"Your number doubled is {i * 2}";
                Console.WriteLine($"{i}");
            }

#if DEBUG
            Console.WriteLine("\n\nYour program is in debug mode");

#endif
#if NATHSTESTCODE
            Console.WriteLine("\n\n nathan's code is running");
#endif

            Debug.Write("We are in debug mode");

            int z = 100;
            Debug.WriteLineIf(z == 100,"z is 100");

            Trace.WriteLineIf(z == 100, "z is 100 on trace WriteLine");

            File.AppendAllText("Events.log", $"z has a value {z} at {DateTime.Now}");

            // Real hacking right here


        }

        static void doThis()
        {
            Console.WriteLine("I am doing something!");
        }
    }
}
