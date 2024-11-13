using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    class Class1
    {
        public static void Check(int number)
        {
            if(number < 0)
            {
                throw new ArgumentOutOfRangeException("number cannot be negative:");
            }
            else
            {
                Console.WriteLine("The number is:"+ number);
            }
        }
        public static void Main(String[] args)
        {
            try
            {
                Console.WriteLine("enter a number:");
                int number = Convert.ToInt32(Console.ReadLine());
                Check(number);
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(FormatException f)
            {
                Console.WriteLine(f.Message);
            }
            Console.Read();
        }
    }
}
