using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
namespace Mini_Project
{
    public class AdminFinal
    {
        public static SqlConnection sqlconn = null;
        public static SqlCommand command = null;
        public static IDataReader reader = null;
        static int usernamecounter = 0;
        static int passwordcounter = 0;
        static int correctpassword = 0;
        public  int train_number = 0;
        public  String source_point = null;
        public  String destination_point = null;
        public  String train_name = null;
        public  TimeSpan source_time;
      //  public  TimeSpan destination_time;
        public  DateTime source_date;
      //  public  DateTime destination_date;
        public  int upperberth = 0;
        public  int lowerberth = 0;
        public  int carchair = 0;
        public  String type_of_class = null;
        public  int total_berth = 0;
        public String status = null;
        public  String action = null;
        public void connection()
        {
            sqlconn = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
            Console.WriteLine("Connected successfully:");
            sqlconn.Open();
        }
        public void TrainOperations()
        {
            Console.WriteLine("Welcome to Admin:");
            LoginAdmin();
            if (correctpassword == 1)
            {
                AdminFinal a = new AdminFinal();
                a.Add();
            }
        }
        public static void LoginAdmin()

        {
            AdminFinal a = new AdminFinal();
            a.connection();
            command = new SqlCommand("sp_loginadmin", sqlconn);
            command.CommandType = CommandType.StoredProcedure;
            reader = command.ExecuteReader();
            int count = reader.FieldCount;
            ArrayList list = new ArrayList();
            while (reader.Read())
            {
                for (int i = 0; i < count; i++)
                {
                    list.Add(reader[i]);
                }
            }
        /* for (int i = 0; i < list.Count; i++)
         {
             Console.WriteLine("The elements is:" + list[i] + "index is:" + i);
         }  */
        validations:
            {
                Console.WriteLine("Enter login credentials:");
                Console.WriteLine("******************");
                Console.WriteLine("Enter the username");   
                Console.WriteLine("******************");
                String username = Console.ReadLine();   // Admin username: sritejagovindula
                Console.WriteLine("******************");
                Console.WriteLine("Enter the password");
                Console.WriteLine("******************");
                String password = Console.ReadLine();  // Admin password: Sriteja@12
                int j = 0;

                for (int i = 0; i < list.Count; i++)  // 0 < 6 -> true, 1 < 6 -> true
                {
                    if (username.Equals(list[i]))  // 0 -> 1 => False, 1 -> sritejagovindula => True 
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
            }
            
            if (correctpassword == 1)
            {
                Console.WriteLine("Login Successfull:");
            }
            else if (usernamecounter > 0 && passwordcounter > 0)
            {
                Console.WriteLine("Login Failed:");
                goto validations;
            }
            else
            {
                Console.WriteLine("Login Failed: Please enter correct username and password:");
                goto validations;
            }




        }
        public  void Add()
        {
            int i = 0;
            int no_of_trains = 0;
            try
            {
                Console.WriteLine("select how many trains you have to add or modify or delete(Enter 1 or 2 or 3)");
                no_of_trains = Convert.ToInt32(Console.ReadLine()); // 1
            }
            catch(Exception e)
            {
                Console.WriteLine("Enter data in correct format:");
            }
                while (i < no_of_trains)  // 
                {
                    AdminFinal a = new AdminFinal();
                    a.connection();
                    //Console.WriteLine("Connected Successfully:");
                    command = new SqlCommand("sp_addtrain", sqlconn);
                    command.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("If you want to add train please enter (Add) or If you want to Modify existing train please enter (Modify) or If you want to delete the train please enter (Delete) or Exit:");
                    action = Console.ReadLine();

                    int lowerberth1 = 0;
                    int upperberth1 = 0;
                    int seats1 = 0;
                    int sum = 0;
                    if (action.ToLower() == "Add".ToLower())
                    {
                
                        try
                        {
                            Console.WriteLine("Enter the Train number:");
                            train_number = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Enter the Source point:");
                            source_point = Console.ReadLine();
                            Console.WriteLine("Enter the Destination point:");
                            destination_point = Console.ReadLine();
                            Console.WriteLine("Enter the train name:");
                            train_name = Console.ReadLine();
                            Console.WriteLine("Enter the source date with time:Enter date in (yyyy-MM-dd hh:mm)");
                            DateTime source_time_part = Convert.ToDateTime(Console.ReadLine());
                            source_time = source_time_part.TimeOfDay;
                            //   Console.WriteLine("Enter the destination date with time: Enter date in (yyyy-MM-dd hh:mm)");
                            //  DateTime destination_time_part = Convert.ToDateTime(Console.ReadLine());
                            //    TimeSpan destination_time = destination_time_part.TimeOfDay;
                            source_date = source_time_part.Date;
                            //   destination_date = destination_time_part.Date;
                            Console.WriteLine("Enter the Class:(FirstClassA/C or SecondClassA/C or ThirdClassA/C or Sleeper or Chaircar)");
                            type_of_class = Console.ReadLine();
                            Console.WriteLine("Enter the train status:");
                            status = Console.ReadLine();
                            Console.WriteLine("Enter the total berth:");
                            total_berth = Convert.ToInt32(Console.ReadLine());
                        
                    }catch(Exception e)
                    {
                        Console.WriteLine("please enter the data in correct format:");

                    }
                        if (total_berth > 0)
                        {
                        upperberth:
                            {
                                Console.WriteLine("Enter how many Upper berths you want to add:");
                                upperberth = Convert.ToInt32(Console.ReadLine());  //  24

                                upperberth1 = sum + upperberth;   // 0 + 12 -> 12
                                if (upperberth1 < total_berth)  // 12 < 24
                                {
                                    goto lowerberth;
                                }
                                else if (upperberth1 == total_berth)
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto upperberth;

                                }
                            }
                        lowerberth:
                            {
                                Console.WriteLine("Enter how many lower berths you want to add:");
                                lowerberth = Convert.ToInt32(Console.ReadLine());  //  10
                                lowerberth1 = upperberth1 + lowerberth;   // 12 + 10 -> 22
                                if (lowerberth1 < total_berth)  // 22 < 24
                                {
                                    goto seats;
                                }
                                else if (lowerberth1 == total_berth)
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto lowerberth;
                                }
                            }
                        seats:
                            {
                                Console.WriteLine("Enter how many seats you want to add:");
                                carchair = Convert.ToInt32(Console.ReadLine());  //  2
                                seats1 = lowerberth1 + carchair;   // 22 + 2 -> 24
                                if (seats1 < total_berth)  // False  24 < 24 -> False
                                {
                                    goto seats;
                                }
                                else if (seats1 == total_berth)  // 24 == 24 -> True
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto seats;
                                }
                            }
                        }








                    Equals:
                        {

                            if (type_of_class.ToLower() == "firstclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                               // command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                              //  command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                                command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                                command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train added successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not added:");
                                }


                            }
                            else if (type_of_class.ToLower() == "secondclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                              //  command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                              //  command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                                command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                                command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train added successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not added:");
                                }


                            }
                            else if (type_of_class.ToLower() == "thirdclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                             //   command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                             //   command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                                command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                                command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train added successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not added:");
                                }


                            }
                            else if (type_of_class.ToLower() == "sleeper")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                               // command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                               // command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train added successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not added:");
                                }


                            }
                            else if (type_of_class.ToLower() == "chaircar")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                              //  command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                              //  command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train added successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not added:");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter in FirstClassA/C or SecondClassA/C or ThirdClassA/C or Sleeper or chaircar please don't enter other than these:");
                            }
                        }
                    }
                    else if (action.ToLower() == "Modify".ToLower())
                    {
                    try
                    {
                        Console.WriteLine("Enter the Train number:");
                        train_number = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the status:");
                        status = Console.ReadLine();
                        Console.WriteLine("Enter the Source point:");
                        source_point = Console.ReadLine();
                        Console.WriteLine("Enter the Destination point:");
                        destination_point = Console.ReadLine();
                        Console.WriteLine("Enter the train name:");
                        train_name = Console.ReadLine();
                        Console.WriteLine("Enter the source date with time: Enter date in (yyyy-MM-dd hh:mm) ");
                        DateTime source_time_part = Convert.ToDateTime(Console.ReadLine());
                        source_time = source_time_part.TimeOfDay;
                        //    Console.WriteLine("Enter the destination date with time: Enter date in (yyyy-MM-dd hh:mm)");
                        //    DateTime destination_time_part = Convert.ToDateTime(Console.ReadLine());
                        //   TimeSpan destination_time = destination_time_part.TimeOfDay;
                        source_date = source_time_part.Date;
                        //  destination_date = destination_time_part.Date;
                        Console.WriteLine("Enter the Class:(FirstClassA/C or SecondClassA/C or ThirdClassA/C or Sleeper or General)");
                        type_of_class = Console.ReadLine();
                        Console.WriteLine("Enter the total berth:");
                        total_berth = Convert.ToInt32(Console.ReadLine());
                    }catch(Exception e)
                    {
                        Console.WriteLine("Enter in correct format:");
                    }
                        if (total_berth > 0)
                        {
                        upperberth:
                            {
                                Console.WriteLine("Enter how many Upper berths you want to add:");
                                upperberth = Convert.ToInt32(Console.ReadLine());  //  24

                                upperberth1 = sum + upperberth;   // 0 + 12 -> 12
                                if (upperberth1 < total_berth)  // 12 < 24
                                {
                                    goto lowerberth;
                                }
                                else if (upperberth1 == total_berth)
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto upperberth;

                                }
                            }
                        lowerberth:
                            {
                                Console.WriteLine("Enter how many lower berths you want to add:");
                                lowerberth = Convert.ToInt32(Console.ReadLine());  //  10
                                lowerberth1 = upperberth1 + lowerberth;   // 12 + 10 -> 22
                                if (lowerberth1 < total_berth)  // 22 < 24
                                {
                                    goto seats;
                                }
                                else if (lowerberth1 == total_berth)
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto lowerberth;
                                }
                            }
                        seats:
                            {
                                Console.WriteLine("Enter how many seats you want to add:");
                                carchair = Convert.ToInt32(Console.ReadLine());  //  2
                                seats1 = lowerberth1 + carchair;   // 22 + 2 -> 24
                                if (seats1 < total_berth)  // False  24 < 24 -> False
                                {
                                    goto seats;
                                }
                                else if (seats1 == total_berth)  // 24 == 24 -> True
                                {
                                    goto Equals;
                                }
                                else
                                {
                                    Console.WriteLine("Enter the number the upperberth and lowerberth and seats of sum is equal to totalberths:");
                                    goto seats;
                                }
                            }
                        }
                    Equals:
                        {

                            if (type_of_class.ToLower() == "firstclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                             //   command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                             //   command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train updated successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not updated:");
                                }


                            }
                            else if (type_of_class.ToLower() == "secondclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                             //   command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                             //   command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train updated successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not updated:");
                                }


                            }
                            else if (type_of_class.ToLower() == "thirdclassa/c")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                            //    command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                            //    command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train updated successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not updated:");
                                }


                            }
                            else if (type_of_class.ToLower() == "sleeper")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                            //    command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                            //    command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train updated successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not updated:");
                                }


                            }
                            else if (type_of_class.ToLower() == "chaircar")
                            {
                                Console.WriteLine("Enter the price:");
                                float price = Convert.ToInt32(Console.ReadLine());
                                command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                                command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                                command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                                command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                                command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                            //    command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                                command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                            //   command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                                command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                                command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                                command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                                command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                                command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                            command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                            command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                                command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                                int result = command.ExecuteNonQuery();
                                if (result > 0)
                                {
                                    Console.WriteLine("Train updated successfully:");
                                }
                                else
                                {
                                    Console.WriteLine("Train not updated:");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Enter in FirstClassA/C or SecondClassA/C or ThirdClassA/C or Sleeper or chaircar please don't enter other than these:");
                            }
                        }
                    }
                    else if (action.ToLower() == "Delete".ToLower())
                    
                {
                        Console.WriteLine("Enter the Train number:");
                        train_number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the status:");
                    status = Console.ReadLine();
                        Console.WriteLine("Enter the Source point:");
                        source_point = Console.ReadLine();
                        Console.WriteLine("Enter the Destination point:");
                        destination_point = Console.ReadLine();
                        Console.WriteLine("Enter the train name:");
                        train_name = Console.ReadLine();
                        Console.WriteLine("Enter the source date with time: Enter in (yyyy:MM:dd hh:mm)");
                        DateTime source_time_part = Convert.ToDateTime(Console.ReadLine());
                        source_time = source_time_part.TimeOfDay;
                     //   Console.WriteLine("Enter the destination date with time: Enter in (yyyy:MM:dd hh:mm)");
                    //    DateTime destination_time_part = Convert.ToDateTime(Console.ReadLine());
                    //    TimeSpan destination_time = destination_time_part.TimeOfDay;
                        source_date = source_time_part.Date;
                     //   destination_date = destination_time_part.Date;
                        Console.WriteLine("Enter the Class:(FirstClassA/C or SecondClassA/C or ThirdClassA/C or Sleeper or Chaircar)");
                        type_of_class = Console.ReadLine();
                        Console.WriteLine("Enter the total berth:");
                        total_berth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Upper berth:");
                        upperberth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the Lower berth:");
                        lowerberth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the chaircar:");
                        carchair = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter the price:");
                        float price = Convert.ToInt32(Console.ReadLine());
                        command.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                        command.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                        command.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
                        command.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                        command.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                    //    command.Parameters.Add(new SqlParameter("@destination_time", SqlDbType.Time)).Value = destination_time;
                        command.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
                    //    command.Parameters.Add(new SqlParameter("@destination_date", SqlDbType.Date)).Value = destination_date;
                        command.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                        command.Parameters.Add(new SqlParameter("@total_berth", SqlDbType.Int)).Value = total_berth;
                        command.Parameters.Add(new SqlParameter("@upper_berth", SqlDbType.Int)).Value = upperberth;
                        command.Parameters.Add(new SqlParameter("@lower_berth", SqlDbType.Int)).Value = lowerberth;
                        command.Parameters.Add(new SqlParameter("@chair_car", SqlDbType.Int)).Value = carchair;
                        command.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 40)).Value = status;
                        command.Parameters.Add(new SqlParameter("@price", SqlDbType.Float)).Value = price;
                        command.Parameters.Add(new SqlParameter("@action", SqlDbType.VarChar, 20)).Value = action;
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            Console.WriteLine("Train Deleted successfully:");
                        }
                        else
                        {
                            Console.WriteLine("Train not deleted:");
                        }
                    }
                    else if(action.ToLower() == "Exit".ToLower())
                {
                    Console.WriteLine("Thank you:");
                    break;
                }
                
                    i = i + 1;
                }
            
        }
    }
}
