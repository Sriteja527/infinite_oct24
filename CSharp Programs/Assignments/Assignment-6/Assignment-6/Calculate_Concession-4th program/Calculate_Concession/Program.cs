using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Concession
{
    public class Program
    {
        public const int totalfare = 500;

        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the name:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Class1 c1 = new Class1();
            c1.CalculateConcession(age);
            Console.Read();


        }

    }
}
