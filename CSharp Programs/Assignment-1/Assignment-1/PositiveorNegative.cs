using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class PositiveorNegative
    {
        void input()
        {
            Console.WriteLine("Enter the number:");
            int number = Convert.ToInt32(Console.ReadLine());
            if(number >= 0)
            {
                Console.WriteLine("Given number is a positive:");
            }
            else
            {
                if(number < 0)
                {
                    Console.WriteLine("Given number is negative:");
                }
                
            }
            Console.Read();
        }
        public static void Main(String[] args)
        {
            PositiveorNegative p = new PositiveorNegative();
            p.input();

        }
    }
}
