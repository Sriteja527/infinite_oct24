using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    public class Exchange
    {
        void input()
        {
            Console.WriteLine("Enter the String:");
            String name = Console.ReadLine();  // abcd
            String first = "";
            String last = "";
            String[] arr = new string[name.Length];
            String result = "";
            for(int i = 0; i < name.Length; i++)
            {
                arr[i] =  arr[i] + name[i];     // abcd
            }
            for(int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(arr[i]);
                if(i < 1 && i >= 0)
                {
                    first = arr[i];
                }
                else
                {
                    if(i == name.Length - 1)
                    {
                        last = arr[i];
                    }
                }
                Console.WriteLine("The last is:" + last);
                Console.WriteLine("The first is:"+first);
                

            }
            for (int i = 0; i < name.Length; i++)
            {
                if (i < 1 && i >= 0)
                {
                    arr[i] = last;
                }
                else
                {
                    if(i == name.Length - 1)
                    {
                        arr[i] = first;
                    }
                }
            }
            for(int i = 0; i < name.Length; i++)
            {
                result = result + arr[i];
            }
            Console.WriteLine("The result is:" + result);
            Console.Read();

        }
        public static void Main(String[] args)
        {
            Exchange e = new Exchange();
            e.input();
        }
    }
}
