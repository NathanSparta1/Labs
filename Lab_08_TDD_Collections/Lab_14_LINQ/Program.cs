using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace Lab_14_LINQ
{
    class Program
    {
       
        

        static void Main(string[] args)
        {
            #region explanation
            /* 1) read northwind core using entity core 2.1.1
             * 2) basic LINQ
             * 3) More advance LINQ with Lambda
             */
            #endregion

            List<Customer> customers = new List<Customer>();
            List<Customer> selectedCustomersDB;
            List<ModifiedCustomer> modifiedcustomers = new List<ModifiedCustomer>();
            List<Product> products = new List<Product>();
            List<Category> categories = new List<Category>();
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();


                //simple LINQ from local query
                // whole dataset is returned (more data)
                //Ienumerable array

                var selectedCustomers = from customer in customers
                                        select customer;

                //same query over database directly
                //only return actual data we need
                //lazy loading - query is not actually executed!!
                //data has not actually arrived yet!
                 selectedCustomersDB =
                    (from customer in db.Customers
                     where customer.City =="London" || customer.City =="Berlin"
                     orderby customer.ContactName
                    select customer).ToList();

             //printCustomers(selectedCustomersDB);


                var SelectedCustomers3 =
                    (from customer in db.Customers
                    select new
                    {
                        Name = customer.ContactName,
                        Location = customer.City + " " + customer.Country
                    }).Take(10).ToList();

                foreach (var c in SelectedCustomers3)
                {
                    Console.WriteLine($"{c.Name,-20}{c.Location}");
                }


                var selectedCustomer4 =
                    (from c in db.Customers
                     select new ModifiedCustomer(c.ContactName, c.City + " " + c.Country)).ToList();

                var selectedCustomers5 =
                from cust in db.Customers
                group cust by cust.City into Cities
                where Cities.Count() > 1
                orderby Cities.Count() descending
                select new
                {
                    City = Cities.Key,
                    Count = Cities.Count()

                };

                foreach (var c in selectedCustomers5.ToList())
                {
                    Console.WriteLine($"{c.City,-15}{c.Count}");
                }

                // Join
                // products with categoryid where we can then get the product name
                Console.WriteLine("\n\nList of Products Inner Join Category Showing Name\n" +
                    "===================================================================\n");
               var listOfproducts =
                        (from p in db.Products
                         join c in db.Categories
                     on p.CategoryID equals c.CategoryID
                         select new
                         {
                             ID = p.ProductID,
                             Name = p.ProductName,
                             Category = c.CategoryName

                         }).ToList();
                listOfproducts.ForEach(p => Console.WriteLine($"{p.ID,-15}{p.Name,-30}{p.Category}"));

                Console.WriteLine("\n\nNow print of the same list but much smarter\n"+
                    "'dot' Notation to join tables\n");

                // read from db

                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p =>
                Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-30}{p.Category.CategoryName}"));

                Console.WriteLine("\n\nList Categories with Count of Products and Sub-List of Product Names\n");
                categories.ForEach(c =>
                {
                    Console.WriteLine($"{c.CategoryID,-5}{c.CategoryName,-15} has {c.Products.Count}products");
                    foreach(var p in c.Products)
                    {
                        Console.WriteLine($"\t\t\t\t{p.ProductID,-5}{p.ProductName}");
                    }
                }
                
                );
                Console.WriteLine($"\n\nLINQ Lambda Notation\n");
                customers = db.Customers.ToList();
                Console.WriteLine($"Count is {db.Customers.Count()}");


                //Distinct
                Console.WriteLine("\n\nList of Cities Distinct\n");
                Console.WriteLine("Using Select to select one column\n");
                var cityList = db.Customers.Select(c => c.City).Distinct()
                   .OrderBy(c => c).ToList();

                cityList.ForEach(city => Console.WriteLine(city));

                Console.WriteLine("\n\nContains(same as SQL Like)\n");
                var cityListFiltered =
                    db.Customers.Select(c => c.City)
                    .Where(city => city.Contains("o"))
                    .Distinct()
                    .OrderBy(c => c)
                    .ToList();
                cityListFiltered.ForEach(city => Console.WriteLine(city));

            }

            // force data by pushing to a list ie .ToList() or by taking aggregate e.g. Sum, Count

           
            // Grouping
            // Group and list all customers by CITY
            //CITY... COUNT(CUSTOMER)

            



        }

        static void printCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}" + 
                $"{c.ContactName,-30}{c.CompanyName,-40}{c.City,-30}"));
        }
    }

    #region DatabaseContextAndClasses
    // connect to database

    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }
    #endregion

    public class ModifiedCustomer
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public ModifiedCustomer(string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
    }

    public class ReadCustomers
    {
       

        public int NumberOfNorthwindCustomers(string city)
        {
            using (var db = new Northwind())

                if (city == null || city == " ")
                {
                    return db.Customers.Count();
                }
                else return db.Customers.Where(c => c.City == city).Count();



        }
    }

}
