using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_1
{
    public class Occurences
    {
        void input()
        {
            Console.WriteLine("Enter the String:");
            String name = Console.ReadLine();  //aamar
            String[] arr = new string[name.Length];
            String var = "";
            int count = 1;
            for(int i = 0; i < name.Length; i++)
            {
                arr[i] = arr[i] + name[i];
            }
            for(int i = 0; i < name.Length; i++)
            {
                for(int j = 1; j < name.Length; j++)
                {
                    if(arr[i] == arr[j])  //0 -> a, 1 -> a
                    {
                        var = arr[i];
                        
                    }
                }
            }
            for(int i = 0; i < name.Length; i++)
            {
                if(var == arr[i])
                {
                    count = count + 1;
                }
            }
            Console.WriteLine("The number of occurences of:" + var + "is" + count);
            Console.Read();
        }
        public static void Main(String[] args)
        {
            Occurences o = new Occurences();
            o.input();
        }
    }
}
