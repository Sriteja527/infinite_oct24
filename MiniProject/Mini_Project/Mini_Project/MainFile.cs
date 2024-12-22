using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project
{
    public class MainFile
    {
        void ChooseModule()
        {
            while (true) { 
                Console.WriteLine("1) Admin");
                Console.WriteLine("2) User");
                Console.WriteLine("3) Exit");
                Console.WriteLine("Please select 1 if you are admin (It is not for users)");
                Console.WriteLine("Please select 2 if you are User");
                Console.WriteLine("Please select 3 if you want to exit the application:");
                Console.WriteLine("**************************");
                Console.WriteLine("Enter the number: (1 or 2 or 3)");
                Console.WriteLine("**************************");
                int number = 0;

                number = Convert.ToInt32(Console.ReadLine());


                switch (number)
                {
                    case 1:
                        AdminFinal a = new AdminFinal();
                        a.TrainOperations();
                        break;
                    case 2:
                        User u = new User();
                        u.useroperations();
                        break;
                    case 3:
                        Console.WriteLine("Thank you:");
                        break;
                    default:
                        Console.WriteLine("Enter the numbers 1 or 2 or 3 don't enter the number beyond that:");
                        break;



                }
                if(number == 3)
                {
                    break;
                }
            }
        }
        public static void Main(string[] args)
        {
            MainFile f = new MainFile();
            f.ChooseModule();
            Console.Read();
        }
    }
}
