using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
namespace Lab_23_Serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "simon", "NRDEH32");
            var customer2 = new Customer(2, "Mary", "CB35468");
            var customer3 = new Customer(3, "John", "dhrhe45");
            var customers = new List<Customer>() { customer, customer2,customer3};

            // serialise
            var JSONCustomerList = JsonConvert.SerializeObject(customers);


            //Alternative serialise

            //var JSONCustomer

            //peek at the object
            Console.WriteLine(JSONCustomerList);

            // save to file (JSON)
            File.WriteAllText("data.json", JSONCustomerList);

            //read
            var JSONstring = File.ReadAllText("data.json");

            //deserialise
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(JSONstring);

            // print

            customersFromJSON.ForEach(c => Console.WriteLine($"{c.CustomerID} ,  {c.CustomerName}"));
        }
    }

    [Serializable]
    class Customer
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
