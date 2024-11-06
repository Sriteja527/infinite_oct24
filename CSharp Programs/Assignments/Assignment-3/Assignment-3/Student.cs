using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class Student
    {
        static int rollno;
        static String name, Class, semester, branch;
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
            Console.WriteLine("Enter the 5 marks:");
            for(int i = 0; i < marks.Length; i++)
            {
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
            
        }
        int all_subjects = 0;
        int average = 0;
        void displayresult()
        {
            
            for(int i = 0; i < marks.Length; i++)
            {
                all_subjects = all_subjects + marks[i];  // 0 + 45 -> 45
                average = all_subjects / marks.Length; // calculating average.

            }
            int mark = 0, allsubjects = 0, Average = 0;
            for(int i = 0; i < marks.Length; i++)
            {
                if (marks[i] < 35)
                {
                    mark = mark + 1;
                }
                else
                {
                    if (all_subjects > 35 && average < 50)
                    {
                        allsubjects = allsubjects + 1;
                    }
                    if (average > 50)
                    {
                        Average = Average + 1;
                        
                    }
                }
            }
            if(mark > 1)
            {
                Console.WriteLine("The result is:: Fail");
            }
            else
            {
                if(allsubjects > 1)
                {
                    Console.WriteLine("The result is:: Fail");
                }
                else
                {
                    if(Average > 1)
                    Console.WriteLine("The result is:: Pass");
                }
            }

        }
        void DisplayData()
        {
            Console.WriteLine("The roll no is:" + rollno);
            Console.WriteLine("The name is:" + name);
            Console.WriteLine("The class is:" + Class);
            Console.WriteLine("The semester is:" + semester);
            Console.WriteLine("The branch is:" + branch);
            displayresult();
            Console.WriteLine("The average marks is:" + average);
            Console.WriteLine("The total marks is:" + all_subjects);

        }
        

        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the rollnumber:");
            rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name:");
            name = Console.ReadLine();
            Console.WriteLine("Enter the class:");
            Class = Console.ReadLine();
            Console.WriteLine("Enter the Semester:");
            semester = Console.ReadLine();
            Console.WriteLine("Enter the Branch:");
            branch = Console.ReadLine();
            Student s = new Student(rollno, name, Class, semester, branch);
            s.GetMarks();
            s.DisplayData();
            Console.Read();
        }
    }
}
