using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_5
{
    public class Books
    {
        String BookName;
        String AuthorName;
        public Books(String bookname, String authorname)
        {
            this.BookName = bookname;
            this.AuthorName = authorname;
        }
        public void Display()
        {
            Console.WriteLine("The Bookname is:" + BookName);
            Console.WriteLine("The Authorname is:" + AuthorName);
        }
    }
    public class BookShelf
    {
        public String[] booknames = new string[5];
        public Object this[int index]
        {
            get
            {
                if(index == 0)
                {
                    return booknames[0];
                }
                else if(index == 1)
                {
                    return booknames[1];
                }
                if (index == 2)
                {
                    return booknames[2];
                }
                else if (index == 3)
                {
                    return booknames[3];
                }
                if (index == 4)
                {
                    return booknames[4];
                }
                return null;
            }
            set
            {
                for(int i = 0; i < 5; i++)
                {
                    booknames[i] = (String)value;
                }
            }
        }
    }
    public class FirstQuestion {
        static String Bookname;
        static String Authorname;
        public static void Main(String[] args) {
            Console.WriteLine("Enter the Bookname:");
            Bookname = Console.ReadLine();
            Console.WriteLine("Enter the Authorname:");
            Authorname = Console.ReadLine();
            Books b = new Books(Bookname, Authorname);
            b.Display();
            BookShelf b1 = new BookShelf();
            Console.WriteLine("Enter the booknames upto 5:");
            for(int i = 0; i < 5; i++)
            {
                b1.booknames[i] = Console.ReadLine();
            }
            Console.WriteLine("The first book is:" + b1[0]);
            Console.WriteLine("The second book is:" + b1[1]);
            Console.WriteLine("The third book is:" + b1[2]);
            Console.WriteLine("The fourth book is:" + b1[3]);
            Console.WriteLine("The fifth book is:" + b1[4]);


            Console.Read();
        }
    }
}
    

