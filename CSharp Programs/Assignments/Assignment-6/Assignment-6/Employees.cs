using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment_6
{
    public class Employees
    {
        // Employee properties
        public int Empid { get; set; }
        public string Empname { get; set; }
        public string Empcity { get; set; }
        public float Empsalary { get; set; }

        // Method to input employee data
        public void Input()
        {
            Console.WriteLine("Enter the number of employees:");
            int size = Convert.ToInt32(Console.ReadLine());

            // List to hold employee objects
            List<Employees> employeeList = new List<Employees>();

            for (int i = 0; i < size; i++)
            {
                Employees emp = new Employees(); // Create a new employee object for each iteration

                Console.WriteLine("Enter the EmpId:");
                emp.Empid = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter the Empname:");
                emp.Empname = Console.ReadLine();

                Console.WriteLine("Enter the Empcity:");
                emp.Empcity = Console.ReadLine();

                Console.WriteLine("Enter the Empsalary:");
                emp.Empsalary = Convert.ToSingle(Console.ReadLine());

                // Add the employee object to the list
                employeeList.Add(emp);
            }

            // Display all employee data
            Console.WriteLine("\nThe Employee Data is:");
            foreach (var emp in employeeList)
            {
                Console.WriteLine($"EmpId: {emp.Empid}, Empname: {emp.Empname}, Empcity: {emp.Empcity}, Empsalary: {emp.Empsalary}");
            }
            var salary_data = employeeList.Where(x => x.Empsalary > 45000);
            foreach (var emp1 in salary_data)
            {
                Console.WriteLine("The salary is greater than 45000:" + emp1.Empid + "" + emp1.Empname + "" + emp1.Empcity + "" + emp1.Empsalary);
            }
            var region = employeeList.Where(x => x.Empcity.ToLower() == "bangloore");
            foreach (var emp2 in region)
            {
                Console.WriteLine("The employees data who belongs to bangloore:" + emp2.Empid + "" + emp2.Empname + "" + emp2.Empcity + "" + emp2.Empsalary);
            }
            var sort = employeeList.OrderBy(x => x.Empname);
            foreach (var emp3 in sort)
            {
                Console.WriteLine("The sorted data according to names:" + emp3.Empid + "" + emp3.Empname + "" + emp3.Empcity + "" + emp3.Empsalary);
            }

            Console.Read(); // Wait for user input to close the console
        }

        public static void Main(string[] args)
        {
            Employees e1 = new Employees();
            e1.Input(); // Call the input method to get and display employee data
        }
    }
}