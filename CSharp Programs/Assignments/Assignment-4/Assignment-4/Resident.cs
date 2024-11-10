using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    interface IStudent
    {
        int studentId { get; set; }
        String Name { get; set; }
        void ShowDetails();

    }
    class Dayscholar : IStudent
    {
        public int studentId { get; set; }
        public String Name { get; set; }
        public int Lime1
        {
            get
            {
                return studentId;
            }
            set
            {
                studentId = value;
            }
        }
        public String Lime2
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }

        }
        public void ShowDetails()
        {
            Console.WriteLine("Dayscholar class:");
            Console.WriteLine("The Student id is:" + studentId);
            Console.WriteLine("The Student name is:" + Name);
        }
    }
    public class Resident : IStudent
    {
        public int studentId { get; set; }
        public String Name { get; set; }
        public int Lime1
        {
            get
            {
                return studentId;
            }
            set
            {
                studentId = value;
            }
        }
        public String Lime2
        {
            get
            {
                return Name;
            }
            set
            {
                Name = value;
            }
        }
        public void ShowDetails()
        {
            Console.WriteLine("Resident class:");
            Console.WriteLine("The student id is:" + studentId);
            Console.WriteLine("The Name is:" + Name);

        }
        public static void Main(String[] args)
        {

            Resident r = new Resident();
            Console.WriteLine("Enter the studentId for Resident class");
            r.Lime1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student name for Resident class:");
            r.Lime2 = (Console.ReadLine());
            r.ShowDetails();
            Dayscholar d = new Dayscholar();
            Console.WriteLine("Enter the Studentid for dayscholar class:");
            d.Lime1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Studentid for dayscholar class:");
            d.Lime2 = (Console.ReadLine());
            d.ShowDetails();
            Console.Read();



        }
    }
}

