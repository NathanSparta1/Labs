using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;


namespace Lab_16_Tasks
{
    class Program
    {
        static Stopwatch s = new Stopwatch();
        static Stopwatch st = new Stopwatch();
        static Stopwatch se= new Stopwatch();
        static void Main(string[] args)
        {

            s.Start();

            var task01 = Task.Run(() =>
            {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 completed at time {s.ElapsedMilliseconds}");
            }
            );

            var actionDelegate = new Action(SpecialActionMethod); // pass in a method as an argument
            var task02 = new Task(actionDelegate);
            task02.Start();


            //array of anonymous tasks
            Task[] taskArray = new Task[]
            {
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} ),
              new Task( ()=>{} )
            };

            foreach (var task in taskArray)
            {
                task.Start();
            }

            // second way

            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine($" taskArray 0 completing at {s.ElapsedMilliseconds}");
            });

            taskArray2[1] = Task.Run(() =>
            {
                Thread.Sleep(300);
                Console.WriteLine($" taskArray 1 completing at {s.ElapsedMilliseconds}");
            });
            taskArray2[2] = Task.Run(() =>
            {
                Thread.Sleep(100);
                Console.WriteLine($" taskArray 2 completing at {s.ElapsedMilliseconds}");
            });


            // wait for all array tasks to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"waiting for first array task to complete at {s.ElapsedMilliseconds}");

            // wait for all tasks to complete

            Task.WaitAll(taskArray2);

            Console.WriteLine($"Waiting for all array tasks completed at {s.ElapsedMilliseconds}");


            // Parallel foreach loop
            int[] myCollection = new int[] {10,20,30,40,50,60,70,80,90,100 };

            //regular foreach loop is in order
            //Parrallel foreach just kicks off x jobs at the same time, wait for answers


            se.Start();
            Parallel.ForEach(myCollection, (item) =>
            {
                Thread.Sleep(item * 100); Console.WriteLine($"Foreach Loop item {item}" +
                    $" finishing at time {s.ElapsedMilliseconds}");
            });
            se.Stop();
            Console.WriteLine($"async took {se.ElapsedMilliseconds}");

            //contrast with sync loop 
            Console.WriteLine("\n\nNow run as Sync loop\n");

           
            st.Start();
            foreach (var item in myCollection)  
            {
              //Thread.Sleep(item * 100);
                Console.WriteLine($"syncForeach Loop item {item}" +
                   $" finishing at time {s.ElapsedMilliseconds}");
            }
            st.Stop();

            Console.WriteLine($"sync took {st.ElapsedMilliseconds}");

            //Also is powerful is parallel linq: database queries in parallel
            // Fake it here: use local collection
            var databaseOutput =
               (from item in myCollection 
                select item).AsParallel().ToList();

            var taskWithoutReturingData = new Task(() => { });
            var taskWithReturingData = new Task<int>(() =>
            {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += i;
                }

                return total;
            });

            taskWithReturingData.Start();
                Console.WriteLine($"I have counted to 100 using background task so i dont have" +
                    $"to hang the main thread while i wait. the answer is {taskWithReturingData.Result}");

            Console.WriteLine("Changing this thing back to symchronous");

         // Console.WriteLine();

            Console.WriteLine($"MainMethodhas finished at time {s.ElapsedMilliseconds}");
          //Console.WriteLine($"Application has finished at time {s.ElapsedTicks}");

            Console.ReadLine();
        }
        
        static void SpecialActionMethod()
        {
            Console.WriteLine("This action method takes no parameters, returns nothing, but just" +
                "performs an action, in this case print out...");
            var total = 0;
            for (int i = 0; i < 100_000_000; i++)
            {
                total += i;
            }
            Console.WriteLine($"Special Action Method completing at time {s.ElapsedMilliseconds}");
        }
    }
}
