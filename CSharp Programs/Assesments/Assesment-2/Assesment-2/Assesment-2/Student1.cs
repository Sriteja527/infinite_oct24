using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    public abstract class Student
    {
        public String Name;
        public int Studentid;
        public double Grade;
        public abstract Boolean IsPassed(bool grade);
    }
    public class Undergraduate : Student
    {
        Student s;
        
        public override Boolean IsPassed(bool grade){  // false
            s.Name = Console.ReadLine();
            s.Studentid = Convert.ToInt32(Console.ReadLine());
            s.Grade = Convert.ToDouble(Console.ReadLine());
            if (s.Grade > 70.0)   // 81.0 > 70.0 -> true
            {
                return true;  // true
            }
            else
            {
                return false;
            }
        }

    }

    public class Student1 {
        public static String name;
        public static int studentid;
        public static double grade;
        public static void Main(string[] args)
        {
            
            Undergraduate u = new Undergraduate();
            Console.WriteLine(u.IsPassed(false));
            Console.Read();
        }
    }

}
