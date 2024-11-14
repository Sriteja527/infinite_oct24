using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    public class FileProgram
    {
        void input()
        {
            FileStream fs = new FileStream("MainFile.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            Console.WriteLine("Enter the size of an array:");
            int size = Convert.ToInt32(Console.ReadLine());
            String[] arr = new string[size];
            Console.WriteLine("Enter the array elements:");
            for(int i = 0; i < size; i++)
            {
                arr[i] = Console.ReadLine();
            }
            for(int i = 0; i < size; i++)
            {
                sr.WriteLine(arr[i]);
            }
            Console.WriteLine("Data inserted into a file:");
            sr.Flush();
            sr.Close();
            fs.Close();
            Console.Read();


        }
        public static void Main(String[] args)
        {
            FileProgram f = new FileProgram();
            f.input();
        }
    }
}
