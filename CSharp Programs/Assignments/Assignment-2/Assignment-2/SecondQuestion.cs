using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class SecondQuestion
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter a digit:");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("{0} {0} {0} {0}", number);
            Console.WriteLine("{0}{0}{0}{0}", number);
            Console.WriteLine("{0} {0} {0} {0}", number);
            Console.WriteLine("{0}{0}{0}{0}", number);


            Console.Read();
        }
    }
}
