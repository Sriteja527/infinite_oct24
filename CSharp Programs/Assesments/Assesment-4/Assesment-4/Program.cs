﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Assesment_4 {
    public class Employee {
        public int EmployeeID; 
        public string FirstName; 
        public string LastName; 
        public string Title; 
        public DateTime DOB; 
        public DateTime DOJ; 
        public string City; 
    } 
    public class Program {
        public static void Main() { 
           List<Employee> employeeList = new List<Employee> 
           { new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = new DateTime(1984, 11, 16), DOJ = new DateTime(2011, 6, 8), City = "Mumbai" }, 
             new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = new DateTime(1994, 8, 20), DOJ = new DateTime(2012, 7, 7), City = "Mumbai" }, 
               new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = new DateTime(1987, 11, 14), DOJ = new DateTime(2015, 4, 12), City = "Pune" }, 
               new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1990, 6, 3), DOJ = new DateTime(2016, 2, 2), City = "Pune" }, 
               new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = new DateTime(1991, 3, 8), DOJ = new DateTime(2016, 2, 2), City = "Mumbai" }, 
               new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = new DateTime(1989, 11, 7), DOJ = new DateTime(2014, 8, 8), City = "Chennai" }, 
               new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = new DateTime(1989, 12, 2), DOJ = new DateTime(2015, 6, 1), City = "Mumbai" }, 
               new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = new DateTime(1993, 11, 11), DOJ = new DateTime(2014, 11, 6), City = "Chennai" }, 
               new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = new DateTime(1992, 8, 12), DOJ = new DateTime(2014, 12, 3), City = "Chennai" }, 
               new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = new DateTime(1991, 4, 12), DOJ = new DateTime(2016, 1, 2), City = "Pune" } }; 
            var AllEmployees = employeeList; Console.WriteLine("All Employee Details:"); 
            foreach (var emp in AllEmployees) { 
                Console.WriteLine("The Employee details are:"+emp.EmployeeID+""+emp.FirstName+""+emp.LastName+""+emp.Title+emp.DOB+emp.DOJ+emp.City); 
            }
            var nonMumbaiEmployees = employeeList.Where(e => e.City != "Mumbai");
            Console.WriteLine("\nEmployees Not in Mumbai:"); 
            foreach (var employee in nonMumbaiEmployees) {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.City}"); } 
            var AsstManagers = employeeList.Where(e => e.Title == "AsstManager"); 
            Console.WriteLine("\nAsstManagers:"); 
            foreach (var employee in AsstManagers) { 
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName} {employee.Title}"); } 
            var employeesWithS = employeeList.Where(e => e.LastName.StartsWith("S")); 
            Console.WriteLine("\nEmployees Whose Last Name Starts with 'S':"); 
            foreach (var employee in employeesWithS) {
                Console.WriteLine($"{employee.EmployeeID} {employee.FirstName} {employee.LastName}"); }
            Console.Read();
        } 
    }
}