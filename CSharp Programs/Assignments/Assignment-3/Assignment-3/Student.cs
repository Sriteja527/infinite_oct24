using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Student
    {
        int rollno;
        String name, Class, semester, branch;
        int[] marks = new int[5];
        public Student(int Rollno, String Name, String class1, String Semester, String Branch)
        {
            rollno = Rollno;
            name = Name;
            Class = class1;
            semester = Semester;
            branch = Branch;
        }
        void GetMarks()
        {

        }

        public static void Main(String[] args)
        {

        }
    }
}
