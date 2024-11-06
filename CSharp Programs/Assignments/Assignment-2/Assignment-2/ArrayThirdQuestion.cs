using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class ArrayThirdQuestion
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the size of an array:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            int[] arr1 = new int[n];
            for(int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("The first array elements are:" + arr[i]);
                arr1[i] = arr[i];
            }
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine("After copy the array elements are:" + arr1[i]);
            }
            Console.Read();
        }
    }
}
