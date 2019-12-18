using System;
using System.Collections.Generic;

namespace Lab_09_Rabbit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Rabbit_Collection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();

        /* input total years to run the sytem 
         Output will be list of rabbits produced
         Every year will be list of rabbits produced
         Every year, increment age also of every rabbit
         Test data
         Year 0  1 rabbit age 0
         Year 1  2            1,0
              2  4            2,1,0,0
              3  8            3,2,1,1,0,0,0,0  ---> total age = 7 length 8
         */

        public static (int CumalativeRabbitAge,int RabbitCount) MultipleRabbits(int totalYears)
        {
            // coder to build

            var rabbit0 = new Rabbit
            {
                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0,
            };

            rabbits.Add(rabbit0);
            for (int year = 0; year < totalYears; year++)
            {
                foreach (var rabbit in rabbits.ToArray())
                {
                    var newRabbit = new Rabbit();
                    rabbits.Add(newRabbit);
                    rabbit.Age++;
                }
            }
                int CumalativeRabbitAge = 0;
                rabbits.ForEach(r => CumalativeRabbitAge += r.Age);

                return (CumalativeRabbitAge, rabbits.Count);

            
           
            
        }

        /* can we change the test or create a second one which only starts to add new rabbits if their age is >= 3 */
        public static (int CumalativeRabbitAge, int RabbitCount) MultipleRabbits3(int totalYears)
        {
            var rabbit0 = new Rabbit
            {
                RabbitId = 0,
                RabbitName = "Rabbit0",
                Age = 0,
            };

            rabbits.Add(rabbit0);
            for (int year = 0; year < totalYears; year++)
            {
                foreach (var rabbit in rabbits.ToArray())
                {
                    if (rabbit.Age >= 3)
                    {
                        var newRabbit = new Rabbit();
                        rabbits.Add(newRabbit);
                        rabbit.Age++;
                    }
                }
            }
            int CumalativeRabbitAge = 0;
            rabbits.ForEach(r => CumalativeRabbitAge += r.Age);

            return (CumalativeRabbitAge, rabbits.Count);

        }
    }

    public class Rabbit
    {
        public int RabbitId { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }

        public Rabbit()
        {
            this.RabbitId = Rabbit_Collection.rabbits.Count+1;
            RabbitName = "Rabbit" + RabbitId;
            Age = 0;

        }
    }
}
