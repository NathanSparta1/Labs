using System;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Lab_22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1,"simon","NRDEH32");
            var customer2 = new Customer(2, "Mary", "CB35468");
            var customers = new List<Customer>() { customer, customer2 };

            // serialise customer to XML format

            // create an object for serialiasation
            // SOAP = Simple object access protocol = XML Transmission mechanism
            var formatter = new SoapFormatter();

            // stream customer to file
            using (var stream = new FileStream("data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                // serialise data to xml as a STREAM of data and send to the file stream
                formatter.Serialize(stream, customers);
            }


            //print out file
            Console.WriteLine(File.ReadAllText("data.xml"));
            // reverse

            var customersFromXMLFile = new List<Customer>();
            // stream READ
            using(var reader = File.OpenRead("data.xml"))
            {
                // deserialise XML  => Customer 

                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }

            // print
            customersFromXMLFile.ForEach(c => Console.WriteLine($"{c.CustomerID}  , {c.CustomerName}"));
        }
    }

    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

       [NonSerialized]
        private string NINO;  //opt out

        public Customer(int ID, string Name, string Nino)
        {
            this.CustomerID = ID;
            this.CustomerName = Name;
            this.NINO = Nino;
        }

    }
}
