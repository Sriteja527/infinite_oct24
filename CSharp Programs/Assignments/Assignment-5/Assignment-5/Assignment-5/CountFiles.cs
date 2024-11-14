using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment_5
{
    public class CountFiles
    {
        void input()
        {
            FileStream fs = new FileStream("InputFile.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            String s = sr.ReadLine();
            int count = File.ReadAllLines("InputFile.txt").Length;
            Console.WriteLine("The no.of lines in the file:" + count);
            Console.Read();
        }
        public static void Main(String[] args)
        {
            CountFiles cf = new CountFiles();
            cf.input();
        }
    }
}
