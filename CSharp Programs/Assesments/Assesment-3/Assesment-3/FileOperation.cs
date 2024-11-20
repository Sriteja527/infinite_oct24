using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assesment_3
{
    public class FileOperation
    {
        void input()
        {
            Console.WriteLine("Enter the file name to add the content or to create the file:");
            String filename = Console.ReadLine();
            FileStream fs = new FileStream(filename, FileMode.Append , FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            Console.WriteLine("Enter the text to be inserted in file:");
            String text = Console.ReadLine();
            if (File.Exists(filename))
            {
                sr.Write(text);
                sr.Flush();
                Console.WriteLine("The data is appended sucessfully into" + filename);
            }
            else
            {
                Console.WriteLine("File is successfully created:");
                sr.Write(text);
                sr.Flush();
                Console.WriteLine("The data is appended sucessfully into" + filename);

            }
            sr.Close();
            fs.Close();
            Console.Read();
        }
        public static void Main(String[] args)
        {
            FileOperation f1 = new FileOperation();
            f1.input();
        }
    }
}
