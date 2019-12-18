using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // inside here can go a delegate or anonymous method using lambda syntax
            var task01 = new Task(
                () => { }
                );

            var task02= new Task(
               () =>
               {
                   Console.WriteLine("In task 2");
               }
               );

            task02.Start();

           


            var task03 = Task.Run(
                () =>
                {
                    Console.WriteLine("In task03");
                }
                );

            var task04 = Task.Run(
                () =>
                {
                    Console.WriteLine("In task04");
                }
                );

            var task05= Task.Run(
               () =>
               {
                   Console.WriteLine("In task05");
               }
               );



           

            Console.WriteLine(stopwatch.ElapsedMilliseconds);

            Console.ReadLine();
            //stopwatch
            //array of tasks
        }
    }
}
