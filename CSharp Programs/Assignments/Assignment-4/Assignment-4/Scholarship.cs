using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Scholarship
    {
        
        public double Merit()
        {
            double scholarship = 0;
            Console.WriteLine("Enter the marks:");
            int marks = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the fee:");
            int fee = Convert.ToInt32(Console.ReadLine());
            if(marks >= 70 && marks <= 80)
            {
                Console.WriteLine("The scholarship is:");
                return (scholarship = fee * 0.20);
                
            }
            else if(marks > 80 && marks <= 90)
            {
                Console.WriteLine("The scholarship is:");
                return (scholarship = fee * 0.30);
               
            }
            else if(marks > 90)
            {
                Console.WriteLine("The scholarship is:");
                return (scholarship = fee * 0.50);
                


            }
            else
            {
                Console.WriteLine("You are not elgible for scholarship:");
            }
            return scholarship;
            
            

        }
        public static void Main(String[] args)
        {
            Scholarship m = new Scholarship();
            Console.WriteLine(m.Merit());
            Console.Read();
        }
    }
}
