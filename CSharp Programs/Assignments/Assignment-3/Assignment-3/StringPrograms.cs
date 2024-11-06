using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class StringPrograms
    {
        void input()
        {
            String reverse = null;
            //Word Length
            Console.WriteLine("Enter the String:");
            String word = Console.ReadLine();
            Console.WriteLine("The length of string is:" + word.Length);
            // String Reverse.
            for (int i = word.Length - 1; i >= 0; i--)
            {
                reverse = reverse + word[i];
            }
            Console.WriteLine("The String reverse is:" + reverse);
            Console.WriteLine("Enter the String1 to check equal or not:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the String2 to check equal or not:");
            String word2 = Console.ReadLine();
            if (Equals(word1, word2))
            {
                Console.WriteLine("The two strings are same:");
            }
            else
            {
                Console.WriteLine("The two strings are different:");
            }



            Console.Read();
        }

        public static void Main(string[] args)
        {
            StringPrograms s1 = new StringPrograms();
            s1.input();
        }
    }
}
