using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab_29_SimsonsRuleAreaUnderGraph
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 6;
            int min = 0;
            int max = 6;

            int length = n + 1;
            int[] xValues = new int[length];

            for (int i = 0; i < length; i++)
            {
                xValues[i] += i;
            }

            int[] yValues = new int[length];

            for (int i = 0; i < length; i++)
            {
                yValues[i] = xValues[i] * xValues[i];
            }

            int sumOfOdd = 0;
            int sumOfEven = 0;

            for (int i = 0; i <= (length - 1); i++)
            {
                if (xValues[i] % 2 == 0)
                {
                    sumOfEven += yValues[i];
                }
                else sumOfOdd += yValues[i];
            }
            sumOfEven -= yValues[length-1];

            SimsonsRule SR = new SimsonsRule();



            int dx = (max - min) / n;
            //int ans;

            Console.WriteLine(SR.GetAreaUnderGraph(16,0,16));
            Console.WriteLine(@"//////////////////////////");
            Console.WriteLine(SR.GetAreaUnderGraph2(6,0,6));
            Console.WriteLine(SR.GetAreaUnderGraph2(10,0,10));
            Console.WriteLine(SR.GetAreaUnderGraph2(20,0,20));

        }
    }

    public class SimsonsRule
    {
        /*
         * Home work]
         * graph of y=x*x
         * points 0,1,2,3,4,5,6 = N   (number of points)
         * Value of Y is 0,1,4,9,16,25,36
         * Goal: approximate area under graph
         * Simpsons rule
         * Area = (MAX X - MIN X)/ 3*N) * Y(the first one)  + Y(the last one) + 4(odd indexed items for x) + 2(even-indexed items for x i.e n=2,4)
         */

        public double GetAreaUnderGraph(int n, int min, int max)
        {

            int length = n + 1;
            int[] xValues = new int[length];

            for (int i = 0; i < length; i++)
            {
                xValues[i] += i;
            }

            int[] yValues = new int[length];

            for (int i = 0; i < length; i++)
            {
                yValues[i] = xValues[i] * xValues[i];
            }

            int sumOfOdd = 0;
            int sumOfEven = 0;

            for (int i = 0; 
                i <= (length-1); i++)

            {
                if (xValues[i] % 2 == 0)
                {
                    sumOfEven += yValues[i];
                }
                else 
                    sumOfOdd += yValues[i];
            
            }
            sumOfEven -= yValues[length-1];
            
            // n = 6,  min = 0, max=6,  diference = (max-min/n)

           

            
            /*double areaP1 = ((max - min) /   3*n);

            double areaP2 = (min * min) + (max * max);

            double areaP3 = 4 * (sumOfOdd);

            double areaP4 = 2 * (sumOfEven);

            double ans = (areaP1 * areaP2) + (areaP3 + areaP4);*/
            int dx = (max - min) / n;
           
            int ans = ((dx ) * (yValues[min]) + (4 * (sumOfOdd)) + 2 * sumOfEven + yValues[max])/3;


                

            return ans;
        }

        public double GetAreaUnderGraph2(int n, int min, int max)
        {
            int length = n + 1;
            int[] xValues = new int[length];

            for (int i = 0; i < length; i++)
            {
                xValues[i] += i;
            }

            int[] yValues = new int[length];
            for (int i = 0; i < length; i++)
            {
                yValues[i] = xValues[i] * xValues[i] * xValues[i];
            }

            int sumOfOdd = 0;
            int sumOfEven = 0;

            for (int i = 0;
                i <= (length - 1); i++)

            {
                if (xValues[i] % 2 == 0)
                {
                    sumOfEven += yValues[i];
                }
                else
                    sumOfOdd += yValues[i];

            }
            sumOfEven -= yValues[length - 1];

            int dx = (max - min) / n;

            int ans = ((dx) * (yValues[min]) + (4 * (sumOfOdd)) + 2 * sumOfEven + yValues[max]) / 3;
            return ans;
        }

    }
}
