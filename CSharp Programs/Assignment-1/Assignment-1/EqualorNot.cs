using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class EqualorNot
    {
        void input()
        {
            Console.WriteLine("Enter the number 1:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number 2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if(num1 == num2)
            {
                Console.WriteLine("num1 and num2 is equal:");
            }
            else
            {
                Console.WriteLine("num1 and num2 is not equal:");
            }
            Console.Read();

        }
        public static void Main(string[] args)
        {
            EqualorNot p = new EqualorNot();
            p.input();
        }
    }
}
