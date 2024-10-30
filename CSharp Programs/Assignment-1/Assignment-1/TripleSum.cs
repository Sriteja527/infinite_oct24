using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class TripleSum
    {
        void input()
        {
            Console.WriteLine("Enter the number1:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            int sum = num1 + num2;
            if(num1 == num2)
            {
                int triplesum = 3 * sum;
                Console.WriteLine("The triple of their sum is:" + triplesum);
            }
            else
            {
                Console.WriteLine("The two numbers are not same and the sum of two numbers is:" + sum);
            }
            Console.Read();
        }
        public static void Main(String[] args)
        {
            TripleSum t = new TripleSum();
            t.input();
        }
    }
}
