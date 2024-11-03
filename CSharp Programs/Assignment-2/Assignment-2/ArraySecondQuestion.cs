using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ArraySecondQuestion
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the 10 marks:");
            int[] arr = new int[10];
            for(int i=0;i < arr.Length; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            //Total Marks
            int total = 0;
            for(int i = 0; i < arr.Length; i++)
            {
                total = total + arr[i];
            }
            Console.WriteLine("The Total Marks is:" + total);
            Console.WriteLine("****************************");
            //Average Marks
            int average = total / arr.Length;
            Console.WriteLine("The average marks is:" + average);
            Console.WriteLine("****************************");
            //Minimum Marks
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
                Console.WriteLine("The minimum marks is:" + arr[0]);
                Console.WriteLine("The maximum marks is:" + arr[arr.Length - 1]);
                Console.WriteLine("****************************");
            //Ascending order.
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        int swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
            for(int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("The Ascending order is:" + arr[i]);
            }
            Console.WriteLine("****************************");
            //Descending order.
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] < arr[j])
                    {
                        int swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine("The Descending order is:" + arr[i]);
            }


            Console.Read();
        }
    }
}
