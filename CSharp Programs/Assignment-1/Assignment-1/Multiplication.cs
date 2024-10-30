using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Multiplication
    {
        void input()
        {
            Console.WriteLine("Enter the number:");
            int number = Convert.ToInt32(Console.ReadLine()); // 5
            for(int i=0; i<=10; i++)  // 0
            {
                int multiply = number * i; // 5 * 0 = 0
                Console.WriteLine(number + " " + "*" + " " + i + " " + "=" + " " + multiply);
            }
            Console.Read();
        }
        public static void Main(String[] args)
        {
            Multiplication m = new Multiplication();
            m.input();
        }
    }
}
