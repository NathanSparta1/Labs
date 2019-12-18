using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var James = new Child("James");
            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();
            James.Grow();
        }
    }

   public  class Child
    {
        //Trivial event annual birthday!
       delegate void BirthdayDelegate();
       event BirthdayDelegate HaveABirthday;
        public string Name { get; set; }
        public int Age { get; set; }
        public void HaveAParty()
        {
            //this refers to the instance of the class
            Age++;
            Console.WriteLine("Hey, celebrating another year!" + $"Age is now {this.Age}");
        }

        public Child(string Name)
        {
            this.Name = Name;
            this.Age = 0;
            HaveABirthday += HaveAParty; // placeholder
        }

        public void Grow()
        {
            HaveABirthday(); // call the event
        }

    }
}
