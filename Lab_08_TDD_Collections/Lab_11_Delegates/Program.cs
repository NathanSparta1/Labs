using System;

namespace Lab_11_Delegates
{
    class Program
    {
         public delegate void Delegate01();

        //non trivial delegate
        delegate int Delegate02(int x);


        static void Main(string[] args)
        {
            //delegate can be referenced as a class so we can use NEW keyword
            var delegateInstance = new Delegate01(MyMethod01);
            // call this by...
            delegateInstance();

            //trivial cases can simplify (same result)
            // 1. omit 'new'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2();

            //final trivial case
            //action DELEGATE is void and takes no paramenters
            Action delegateInstance3 = MyMethod01; //same as above

            delegateInstance3();

            // will never work Action delegateInstance4 = MyMethod02;

            Delegate02 delegateInstance4 = (x) => { return x * x * x; };
            // Input Params           { // code body        }

            Delegate02 delegateInstance5 = x =>  x * x * x; ;



        }


        static void MyMethod01()
        {
            Console.WriteLine("Running method01");
        }

        static string MyMethod02()
        {
            return "Running method01";
        }

        static int MyMethod03(int x)
        {
            return x * x;
        }
    }
}
