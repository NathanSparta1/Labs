using System.IO;
using System;
using Lab_22_Serialization;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lab_24_Serialise_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "simon", "NRDEH32");
            var customer2 = new Customer(2, "Mary", "CB35468");
            var customer3 = new Customer(3, "John", "dhrhe45");
            var customers = new List<Customer>() { customer, customer2, customer3 };

            // formatter : allow us to serialise to binary
            var formatter = new BinaryFormatter();
            // stream to FILE
            using(var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            }
            // read back
            var customersBinary = new List<Customer>();
            using (var reader = File.OpenRead("data.bin"))
            {
                //deserialise
                customersBinary = formatter.Deserialize(reader) as List<Customer>;
            }


            // print
            
            customersBinary.ForEach(c => Console.WriteLine($"{c.CustomerID},{c.CustomerName}"));
            
        }
    }
}
