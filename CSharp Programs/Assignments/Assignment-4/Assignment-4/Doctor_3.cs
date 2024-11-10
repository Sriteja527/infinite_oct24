using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    //Properties task
    class Doctor
    {
          int RegnNo;
          String Name;
          int FeesCharged;
        public int Lime1
        {
            
            get
            {
                return RegnNo;
            }
            set
            {
                RegnNo = value;

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
        
        public int Lime3
        {
            get
            {
                return FeesCharged;
            }
            set
            {
                FeesCharged = value;
            }
        }
        public String input()
        {
            return "RegnNo is:" + RegnNo + "Name is:" + Name + "FeesCharged is:" + FeesCharged; 
        }
    }
    // initializing using constructor and displaying the values.
    public class Books
    {
        public  String BookName;
        public  String AuthorName;
        public Books(String bookname, String authorname)
        {
            this.BookName = bookname;
            this.AuthorName = authorname;
        }
        public void display()
        {
            
            Console.WriteLine("The Bookname is:" + BookName);
            Console.WriteLine("The AuthorName is:" + AuthorName);
        }
    }
    // Indexers.
    public class BookShelf
    {
        public String[] arr = new String[5];
        public Object this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return arr[0];
                }
                else if(index == 1)
                {
                    return arr[1];
                }
                else if(index == 2)
                {
                    return arr[2];
                }
                else if(index == 3)
                {
                    return arr[3];
                }
                else if(index == 4)
                {
                    return arr[4]; 
                }
                return "Completed";
            }
        }

    }
    public class Doctor_3 {
        public static string bookname;
        public static string authorname;


        public static void Main(String[] args)
        {
            Doctor d1 = new Doctor();
            Console.WriteLine("Enter the RegnNo:");
            d1.Lime1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Name:");
            d1.Lime2 = Console.ReadLine();
            Console.WriteLine("Enter the Feescharged:");
            d1.Lime3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(d1.input());
            Console.WriteLine("Enter the bookname:");
            bookname = Console.ReadLine();
            Console.WriteLine("Enter the authorname:");
            authorname = Console.ReadLine();
            Books b = new Books(bookname, authorname);
            b.display();
            BookShelf b1 = new BookShelf();
            Console.WriteLine("Enter the 5 book names:");
            for(int i = 0; i < 5; i++)
            {
                b1.arr[i] = Console.ReadLine();
            }
            Console.WriteLine("Book1 is:" + b1[0]);
            Console.WriteLine("Book2 is:" + b1[1]);
            Console.WriteLine("Book3 is:" + b1[2]);
            Console.WriteLine("Book4 is:" + b1[3]);
            Console.WriteLine("Book5 is:" + b1[4]);






            Console.Read();

        }

    }
}
