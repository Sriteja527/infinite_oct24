using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_6
{
    public class ReturnLetters
    {
        void input()
        {
            Console.WriteLine("Enter the size of an list:");
            int size = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the data into list:");
            List<String> l1 = new List<String>();
            for(int i = 0; i < size; i++)
            {
                l1.Add(Console.ReadLine());   // mum, amsterdam, bloom
            }
            var result = l1.Where(x => x.StartsWith("a") && x.EndsWith("m"));
            foreach(var x in result)
            {
                Console.WriteLine("The result is:" + x);

            }
            


            Console.Read();
        }
        public static void Main(String[] args)
        {
            ReturnLetters r1 = new ReturnLetters();
            r1.input();
        }
    }
}
