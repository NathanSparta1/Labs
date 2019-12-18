using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_20_Northwind_Products;
using Lab_28_Fibonacci;
using Lab_29_SimsonsRuleAreaUnderGraph;

namespace NUnit_Test2
{
    class Program
    {
        
    }
    [TestFixture]
    class NUnit_Test2
    {

        //annotations
        [SetUp]

        public void Setup()
        {
            // eg get data from a database for all tests
        }

        [Test]
        public void RunThisTest()
        {
            // arrange(data)
            // act (run test)
            // assert (true/false ie pass/fail)
            Assert.AreEqual(true, true);
          
        }


        
        //[TestCase(10, 16, 56, 67, 9, -1)]
        //[TestCase(8, 37, 1, 13, 14, -1)]
        [TestCase(1, 2, 3, 4, 5, 280)]
        public void ArrayListDictionaryGetTotal(int a,int b,int c, int d, int e, int expected)
        {
            int actual = Lab_08_Array_List_Dictionary.Lab_08_Aray_List_Dictionary_getTotals(1, 2, 3, 4, 5);
            // call method in OTHER PROJECT
            // get an answer
            // see if we can get a correct answer or not
            Assert.AreEqual(expected, actual);
        }


        [TestCase(3,7,8)]
        public void RabbitGrowthTests(int totalYears,int expectedCumalitiveRabbitAge, int expectedRabbitCount)
        {
            //Arange

            //Act
            (int actualCumalitiveAge,int actualRabbitCount) = Rabbit_Collection.MultipleRabbits(totalYears); // tuple (int Name,int Name)

            //Assert
            Assert.AreEqual(expectedCumalitiveRabbitAge, actualCumalitiveAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);

        }
       // [TestCase(3,-1,-1)]
        public void RabbitGrowthAfter3years(int totalYears, int expectedCumalitiveRabbitAge, int expectedRabbitCount)
        {
            //Arange

            //Act
            (int actualCumalitiveAge, int actualRabbitCount) = Rabbit_Collection.MultipleRabbits(totalYears); // tuple (int Name,int Name)

            //Assert
            Assert.AreEqual(expectedCumalitiveRabbitAge, actualCumalitiveAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }

        [TestCase(null,108)]
        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
            var testInstance = new Lab_14_LINQ.ReadCustomers();

            var actual = testInstance.NumberOfNorthwindCustomers(city);

            Assert.AreEqual(expected, actual);

        }

        #region TestNumberOfProducts
        [TestCase(3)]
        public void TestNumberOfProductsStartingWithP(int expected)
        {
            // arrange (instance)

            //act (method)

            //assert
            var instance = new ProductCount();

            int actual = instance.ProductCounting();


            Assert.AreEqual(expected,actual);

        }

        

        #endregion
        [TestCase(5)]   
        public void TestFibonacci(int expceted)
        {
            Fibonacci fib = new Fibonacci();
            int actual = fib.ReturnFibonacciNthItemInSequence(3);

            Assert.AreEqual(expceted, actual);


        }

        [TestCase(72,6,0,6)]
        [TestCase(1365, 16, 0, 16)]
        public void TestSimonsRule(int expected, int n, int min, int max)
        {
            SimsonsRule SR = new SimsonsRule();

            double actual = SR.GetAreaUnderGraph(n, min,max);

            Assert.AreEqual(expected, actual);
        }
        [TestCase(324, 6, 0, 6)]
        [TestCase(2500, 10, 0, 10)]
        [TestCase(40000, 20, 0, 20)]
        public void TestSimonsRule2(int expected, int n, int min, int max)
        {
            SimsonsRule SR = new SimsonsRule();

            double actual = SR.GetAreaUnderGraph2(n, min, max);

            Assert.AreEqual(expected, actual);
        }

    }
}
