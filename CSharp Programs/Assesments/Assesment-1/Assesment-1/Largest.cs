using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    public class Largest
    {
        void input()
        {
            Console.WriteLine("Enter the integer1:");
            int a = Convert.ToInt32(Console.ReadLine());  // 1
            Console.WriteLine("Enter the integer2:");
            int b = Convert.ToInt32(Console.ReadLine());  // 2
            Console.WriteLine("Enter the integer3:");
            int c = Convert.ToInt32(Console.ReadLine());  // 3
            if(a>b && a>c)  // 1 > 2 && 1 > c
            {
                Console.WriteLine("The largest number is:"+a);
            }
            else
            {
                if(b>a && b > c)
                {
                    Console.WriteLine("The Largest number is:" + b);
                }
                else
                {
                    if(c>a && c > b)
                    {
                        Console.WriteLine("The Largest number is:" + c);
                    }
                }
            }
            Console.Read();

        }
        public static void Main(String[] args)
        {
            Largest l = new Largest();
            l.input();
            
        }
    }
}
