using System;

namespace testQuestionRework
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        static string Cat(int width, int height, int length, int mass)
        {
            int volume = height * length * width;
            

            if (volume > 1000000 && mass >= 20 ) 
            {
                return "REJECTED";
            }

            else if(volume > 1000000 || width >150 || height > 150 || length > 150 || mass >= 20)
            {
                return "SPECIAL";
            }

             else   return "STANDARD";
        }
    }
}
