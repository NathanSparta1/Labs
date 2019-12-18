using System;
using System.IO;  // Input Output
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace Lab_18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            // System.io writing files
            File.WriteAllText("data.txt", "this some data");

            var myArray = new string[] { "Hello", "this", "is", "some", "data" };
            File.WriteAllLines("ArrayData.txt", myArray);

            Console.WriteLine(File.ReadAllText("data.txt"));


           
           

            
            // Append data
            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", $"\nAdding line {i} at {DateTime.Now}");

            }

            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", Environment.NewLine + $"Adding line {i} at {DateTime.Now}");

            }

            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here is a folder");
            File.Create("Here is a folder\\myfile.txt");
            File.Create(@"Here is a folder\myfile2.txt");


            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));



            // Stream some data to a file
            //System can cope with large files: breaks them down into blocks and sends them
            var numberOfLines = 50_000;
            var s = new Stopwatch();
            s.Start();

            using (var stream01 = new StreamWriter("output.dat"))
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    stream01.WriteLine($"Logging {numberOfLines} at {DateTime.Now}");
                }
              
            }
            var writetime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");
            //read the data

            string nextline;

            using(var reader = new StreamReader("output.dat"))
            {
                // reader does not know how big the file is
                // read until reader.Readline is null
                while((nextline = reader.ReadLine()) != null)
                {
                    //Console.WriteLine(nextline);
                }
                reader.Close();
            }
            
            Console.WriteLine($"It took {s.ElapsedMilliseconds-writetime} to read {numberOfLines} lines");


            // building a string
            // regular string building with +     --- it will generate a new instance every time
            // t ==> th ==> thi ===> this
            // strings are immutable (cannot change them)
            s.Restart();
            var longString = " ";
            using (var reader = new StreamReader("output.dat"))
            {
                
                while ((nextline = reader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                reader.Close();
            }

            Console.WriteLine($"It took {s.ElapsedMilliseconds} to concatinate these lines together");


            s.Restart();
            longString = " ";
            var stb = new StringBuilder();
            using (var reader = new StreamReader("output.dat"))
            {

                while ((nextline = reader.ReadLine()) != null)
                {
                    stb.Append(nextline);
                }
                reader.Close();
            }

            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} together using stringbuilder");

        }

    }
}
