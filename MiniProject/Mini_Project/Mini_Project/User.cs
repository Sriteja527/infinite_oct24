using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
namespace Mini_Project
{
    public class User
    {
        public static SqlConnection sqlconn = null;
        public static SqlCommand sqlCommand = null;
        public static IDataReader reader = null;
        public static string loginusername;
        
        public string username = null;
        public string password = null;
        public  string gender = null;
        public void useroperations()
        {
            Console.WriteLine("Welcome to User:");
            Console.WriteLine("1) Login");
            Console.WriteLine("2) Register");
            Console.WriteLine("Please select 1 if you want to login");
            Console.WriteLine("Please select 2 if you want to register");
            Console.WriteLine("Enter the number either 1 or 2:");
            int number = Convert.ToInt32(Console.ReadLine());
            switch (number)
            {
                case 1: User u = new User();
                    u.comparision();
                    break;
                case 2: User u1 = new User();
                    u1.Registration();
                    break;
                default:
                    Console.WriteLine("Enter the number either 1 or 2 don't enter other than these:");
                    break;
            }
        }
        public void Registration()
        {
            sqlconn = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
            sqlconn.Open();
            sqlCommand = new SqlCommand("sp_Registrationtable", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter the username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter the password:"); 
            password = Console.ReadLine();
            String re_password = null;
            String firstname = null; ;
            String lastname = null ;
            
        
                Console.WriteLine("Re-enter the password:");
                re_password = Console.ReadLine();
            
            if(password == re_password) { 
                Console.WriteLine("Enter the firstname:");
                firstname = Console.ReadLine();
                Console.WriteLine("Enter the lastname:");
                lastname = Console.ReadLine();
                Console.WriteLine("Enter the gender:");
                gender = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("re-enter password must be same as password:");
                
            }
            sqlCommand.Parameters.Add("@username", SqlDbType.VarChar, 40).Value = username;
            sqlCommand.Parameters.Add("@password", SqlDbType.VarChar, 40).Value = password;
            sqlCommand.Parameters.Add("@re_enterpassword", SqlDbType.VarChar, 40).Value = re_password;
            sqlCommand.Parameters.Add("@firstname", SqlDbType.VarChar, 40).Value = firstname;
            sqlCommand.Parameters.Add("@lastname", SqlDbType.VarChar, 40).Value = lastname;
            sqlCommand.Parameters.Add("@gender", SqlDbType.VarChar, 40).Value = gender;
            int result = sqlCommand.ExecuteNonQuery();
            if(result > 0)
            {
                Console.WriteLine("Registered Successfully:");
            }
            else
            {
                Console.WriteLine("Registration Failed:");
            }
            User u = new User();
            u.comparision();
            sqlconn.Close();

        }
        int correctpassword = 0;
        int passwordcounter = 0;
        int usernamecounter = 0;
        public void comparision()
        {
            sqlconn = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
            Console.WriteLine("connected successfully:");
            sqlconn.Open();
            sqlCommand = new SqlCommand("sp_registrationtable1", sqlconn);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            reader = sqlCommand.ExecuteReader();
            int count = reader.FieldCount;
            ArrayList list = new ArrayList();
            
            while (reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add(reader[i]);
                }
            }
        logindetails:
            {
                Console.WriteLine("Enter login credentials:");
                Console.WriteLine("******************");
                Console.WriteLine("Enter the username");
                Console.WriteLine("******************");
                loginusername = Console.ReadLine();   //  username: sritejagovindula
                Console.WriteLine("******************");
                Console.WriteLine("Enter the password");
                Console.WriteLine("******************");
                password = Console.ReadLine();  // password: Sriteja@12
            }
                int j = 0;
                for (int i = 0; i < list.Count; i++)  // 0 < 6 -> true, 1 < 6 -> true
                {
                    if (loginusername.Equals(list[i]))  // 0 -> 1 => False, 1 -> sritejagovindula => True 
                    {

                        while (j < list.Count)   // 0 <
                                                 // 6 -> true, 1 < 6 -> true, 2 < 6 -> true
                        {
                            if (password.Equals(list[j])) // false, false, true
                            {
                                correctpassword++;
                                break;
                            }
                            else
                            {
                                j = j + 1;  // 1, 2
                                passwordcounter++;
                            }

                        }
                    }

                    else
                    {
                        usernamecounter++;
                        continue;
                    }


                }
            
            if (correctpassword == 1)
            {
                Console.WriteLine("===================");
                Console.WriteLine("Welcome to Railway Reservation System:");
                
                Console.WriteLine("===================");
                TicketOperation o = new TicketOperation();
                o.operations();
            }
            else if (usernamecounter > 0 && passwordcounter > 0)
            {
                Console.WriteLine("Invalid Login credentials:");
                goto logindetails;
            }
            else
            {
                Console.WriteLine("Login Failed: Please register before login");
                User u2 = new User();
                u2.Registration();
            }
           
        }

    }
}
