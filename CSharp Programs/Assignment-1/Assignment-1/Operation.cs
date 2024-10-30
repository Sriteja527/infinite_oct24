using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Operation
    {
        void input()
        {
            Console.WriteLine("Enter the first number:");
            int num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the operation:");
            String operation = Console.ReadLine();
            Console.WriteLine("Enter the second number:");
            int num2 = Convert.ToInt32(Console.ReadLine());
            if(operation == "+")
            {
                int sum = num1 + num2;
                Console.WriteLine("The add operation is:"+sum);
            }
            else
            {
                if(operation == "-")
                {
                    int difference = num1 - num2;
                    Console.WriteLine("The difference is:" + difference);
                }
                else
                {
                    if(operation == "*")
                    {
                        int multiply = num1 * num2;
                        Console.WriteLine("The multiply is:"+multiply);
                    }
                    else
                    {
                        if(operation == "/")
                        {
                            int div = num1 / num2;
                            Console.WriteLine("The div is:" + div);
                        }
                    }
                }
            }
            Console.Read();

        }
        public static void Main(String[] args)
        {
            Operation o = new Operation();
            o.input();
        }
    }
}
