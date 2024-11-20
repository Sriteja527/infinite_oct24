using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_3
{
    public delegate void Calculator(int num1, int num2);
    public class DelegateProgram
    {
        public void Addition(int num1, int num2)
        {
            Console.WriteLine("Enter the num1 for addition:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the num2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            int result = num1 + num2;
            Console.WriteLine("The addition is:");
            Console.WriteLine(result);
        }
        public void Subtraction(int num1, int num2)
        {
            Console.WriteLine("Enter the num1 for subtraction:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the num2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The subtraction is:");
            int result = num1 - num2;
            Console.WriteLine(result);
        }
        public void Mulitplication(int num1, int num2)
        {
            Console.WriteLine("Enter the num1 for multiplication:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the num2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("The multiplication is:");
            int result = num1 * num2;
            Console.WriteLine(result);
            Console.Read();
        }
        public static void Main(String[] args)
        {
            DelegateProgram p = new DelegateProgram();
            Calculator c1 = new Calculator(p.Addition);
            c1 += p.Subtraction;
            c1 += p.Mulitplication;
            Console.WriteLine("Enter the number1:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number2:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            c1(num1, num2);
            
        }
    }
}
