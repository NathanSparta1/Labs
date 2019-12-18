using System;
using System.Collections.Generic;



namespace Lab_08_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
           //Lab_08_Array_List_Dictionary lab = new Lab_08_Array_List_Dictionary();

            Console.WriteLine(Lab_08_Array_List_Dictionary.Lab_08_Aray_List_Dictionary_getTotals(1,2,3,4,5));
            
        }
        
    }

    public class Lab_08_Array_List_Dictionary
    {
       // List<int> myList = new List<int>();
        
        public static int Lab_08_Aray_List_Dictionary_getTotals(int a,int b, int c,int d, int e)
        {
            int[] myArray = new int[5];
            List<int> myList = new List<int>();

            myArray[0] = a + 5;
            myArray[1] = b + 5;
            myArray[2] = c + 5;
            myArray[3] = d + 5;
            myArray[4] = e + 5;


            myList.Add(myArray[0] * myArray[0]);
            myList.Add(myArray[1] * myArray[1]);
            myList.Add(myArray[2] * myArray[2]);
            myList.Add(myArray[3] * myArray[3]);
            myList.Add(myArray[4] * myArray[4]);

            Dictionary<int, int> myDict = new Dictionary<int, int>()
            {
                [0] = myList[0] - 10,
                [1] = myList[1] - 10,
                [2] = myList[2] - 10,
                [3] = myList[3] - 10,
                [4] = myList[4] - 10,
            };


            int sum = myDict[0] + myDict[1] + myDict[2] + myDict[3] + myDict[4];


            return sum;

            

        }


    }
}
