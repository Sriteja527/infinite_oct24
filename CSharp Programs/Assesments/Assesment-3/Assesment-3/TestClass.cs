using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_3
{
    public class Box
    {
        public int Length;
        public int Breadth;
        public void add()
        {
            Box box = new Box();
            Console.WriteLine("Enter the Length:");
            box.Length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Breadth:");
            box.Breadth = Convert.ToInt32(Console.ReadLine());
            int newlength = box.Length + box.Length;
            int newbreadth = box.Breadth + box.Breadth;
            Console.WriteLine("Length is:" + box.Length);
            Console.WriteLine("Breadth is:" + box.Breadth);
            Console.WriteLine("Added the new length is:" + newlength);
            Console.WriteLine("Added the new breadth is:" + newbreadth);
            Console.Read();
        }
    }
        public class TestClass { 
        public static void Main(String[] args)
        {
            Box b = new Box();
            b.add();
        }
    }
}
