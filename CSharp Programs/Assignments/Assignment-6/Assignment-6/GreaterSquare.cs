using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public class GreaterSquare
    {
        void input()
        {
            int a = 0;
            Console.WriteLine("Enter the size of an list:");
            int size = Convert.ToInt32(Console.ReadLine());
            List<int> l1 = new List<int>();
            Console.WriteLine("Enter the data into list:");
            for(int i=0; i < size; i++)
            {
                l1.Add(Convert.ToInt32(Console.ReadLine()));
            }
            foreach(var i in l1)
            {
                Console.WriteLine("The list elements are:" + i);
            }
            //var result = l1.Where(n => n * n > 20).Select(n => new { Number = n, Square = n * n });
            var result = l1.Where(x => x * x > 20).Select(x => new { number = x, Square = x * x });
            foreach(var i in result)
            {
                Console.WriteLine($"The squares of the numbers is greater than 20 is:{i.number} - {i.Square}");
            }
            
            Console.Read();

        }
        public static void Main(string[] args)
        {
            GreaterSquare gs = new GreaterSquare();
            gs.input();
        }
    }
}
