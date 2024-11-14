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
        
        public override Boolean IsPassed(bool grade){  // false
            Name = Console.ReadLine();
            Studentid = Convert.ToInt32(Console.ReadLine());
            Grade = Convert.ToDouble(Console.ReadLine());
            if (Grade > 70.0)   // 81.0 > 70.0 -> true
            {
                Console.WriteLine("pass");
                return true;  // true
            }
            else
            {
                Console.WriteLine("fail");
                return false;
            }
        }

    }
    public class Graduate : Student
    {
        public override Boolean IsPassed(bool grade)
        {  // false
            Name = Console.ReadLine();
            Studentid = Convert.ToInt32(Console.ReadLine());
            Grade = Convert.ToDouble(Console.ReadLine());
            if (Grade > 80.0)   // 81.0 > 70.0 -> true
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
