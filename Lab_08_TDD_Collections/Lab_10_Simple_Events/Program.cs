using System;

namespace Lab_10_Simple_Events
{
    class Program
    {

        // create delegate type
        delegate void MyDelegate();
        delegate int MyDelegate02(int x);

        //create event(empty at the moment)
        static event MyDelegate MyEvent;
        static event MyDelegate02 MyEvent02;
        static void Main(string[] args)
        {
            // add method to event

            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent -= Method02;
            MyEvent += Method02;
            MyEvent += Method02;
            MyEvent += Method02;

            MyEvent02 += Method03;


            //Trigger event

            MyEvent();
            MyEvent02(12);
            Console.WriteLine("MyEvent02 return "+ MyEvent02(12));
            
        }

        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }

        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }

        static int Method03(int x)
        {

            return x * x;
        }
    }
}
