using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ArrayFirstQuestion
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the size of an array:");
            int n = Convert.ToInt32(Console.ReadLine()); // n = 5
            int[] arr = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine()); // 1,2,3,4,5
            }
            int sum = 0;
            for(int i = 0; i < n; i++)
            {
                sum = sum + arr[i];  // 0 + 1 -> 1, 1 + 2 -> 3, 3 + 3 -> 6, 6 + 4 -> 10, 10 + 5 -> 15
            }
            //Console.WriteLine("The sum of array elements are:" + sum);
            //Finding Average value.
            int average = sum / arr.Length;
            Console.WriteLine("The average of array elements are:" + average);
            //Finding Minimum and Maximum elements
            for(int i = 0; i < arr.Length; i++)
            {
                for(int j = i+1; j < arr.Length; j++)
                {
                    if(arr[i] > arr[j])
                    {
                        int swap = arr[i];
                        arr[i] = arr[j];
                        arr[j] = swap;
                    }
                }
            }
            
                Console.WriteLine("The Minimum value of an array is:" + arr[0]);
                Console.WriteLine("The Maximum value of an array is:" + arr[n - 1]);
            



            Console.Read();
        }
    }
}
