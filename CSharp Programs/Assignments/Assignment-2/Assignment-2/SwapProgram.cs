using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class SwapProgram
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter the first number:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Before swapping the numbers is:");
            Console.WriteLine("The first number is:" + a);
            Console.WriteLine("The second number is:" + b);
            int temp;
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("After swapping the numbers is:");
            Console.WriteLine("The first number is:" + a);
            Console.WriteLine("The second number is:" + b);
            Console.Read();
        }
    }
}
