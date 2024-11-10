using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    public class Employee
    {
        int Empid;
        String Empname;
        float Salary;
        public Employee(int empid, String empname, float salary){
            this.Empid = empid;
            this.Empname = empname;
            this.Salary = salary;
            Console.WriteLine("Parent class constructor:");
            Console.WriteLine("The Empid is:" + Empid);
            Console.WriteLine("The Empname is:" + Empname);
            Console.WriteLine("The Salary is:" + Salary);
            Console.WriteLine("========================");
        }


    }
    public class ParttimeEmployee : Employee
    {
        int Wages;
        //Instantiating base class through the derived class Constructor.
        public ParttimeEmployee(int empid, String empname, float salary) : base(empid, empname, salary)
        {
            Console.WriteLine("Derived class constructor:");
        }
        public static void Main(String[] args) {
            int empid;
            String empname;
            float salary;
            Console.WriteLine("Enter the employee id:");
            empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the employee name:");
            empname = (Console.ReadLine());
            Console.WriteLine("Enter the employee salary:");
            salary = Convert.ToSingle(Console.ReadLine());
            ParttimeEmployee p = new ParttimeEmployee(empid, empname, salary);
            Console.Read();




        }
}
    }

