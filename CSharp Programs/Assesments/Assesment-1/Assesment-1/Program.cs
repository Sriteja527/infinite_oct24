using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    public class Program
    {
        void input()
        {
            Console.WriteLine("Enter the string value:");
            String name = Console.ReadLine(); // python
            Console.WriteLine("Enter the position for to remove the character");
            int digit = Convert.ToInt32(Console.ReadLine());  // 1
            String result = "";
            for(int i = 0; i < name.Length; i++)  // 0,1
            {
                if(i == digit)  // 0 == 1 -> False, 1 == 1 -> True
                {
                    
                }
                else
                {
                    result = result + name[i];  //result -> p
                }
            }
            Console.WriteLine("The result is:" + result);
            Console.Read();

        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.input();
        }
    }
}
