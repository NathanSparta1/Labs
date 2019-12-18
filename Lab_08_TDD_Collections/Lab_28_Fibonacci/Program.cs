using System;

namespace Lab_28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fib = new Fibonacci();
            Console.WriteLine(fib.ReturnFibonacciNthItemInSequence(14));
        }
    }

    public class Fibonacci
    {
        public int ReturnFibonacciNthItemInSequence(int n)
        {
            n = n + (n - 1);
            return n;
        }
    }
}
