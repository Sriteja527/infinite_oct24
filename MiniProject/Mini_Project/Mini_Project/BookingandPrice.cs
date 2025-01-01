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
    public class BookingandPrice
    {
        public static SqlConnection sqlconn = null;
        public static SqlCommand sqlcomm = null;
        public static IDataReader reader = null;

        public static string type_of_class = null;
        public static string type_of_berth = null;
        public static int no_of_tickets = 0;
        public static int upperberth = 0;
        public static int lowerberth = 0;
        public static int chaircar = 0;
        public static int price = 0;
        public static int available_seats = 0;
        public static string username;
        public static String gender;
        public static int train_number;
        public static String trainname;
        public static String train_name;
        public static int sleeper;
        public static ArrayList list1;
        TicketOperation o;
        public void Price()
        {

            list1 = new ArrayList();
            list1 = TicketOperation.list;



            train_name = null;
        trainnames:
            {
                Console.WriteLine("Enter the train name:");
                train_name = Console.ReadLine();  //intercity
            }
            int count1 = 12;  // Chunk size
            int matched = 0;
            int starting = 0;
            int upperberth_count = 0;
            int lowerberth_count = 0;
            int chaircar_count = 0;

            for (int i = 0; i < list1.Count; i++)
            {
                if (i < count1)
                {
                    if (train_name == list1[i].ToString())
                    {
                        matched = matched + 1;
                        break;
                    }
                }
                else
                {
                    count1 = count1 + 12;
                }
            }
            if (matched == 1)
            {
                // Console.WriteLine("matched");
                starting = count1 - 12;  // 24 - 12 = 12
                Console.WriteLine("Enter the type of class:");
                type_of_class = Console.ReadLine();
                for (int i = starting; i < count1; i++)
                {
                    if (type_of_class == list1[i].ToString())
                    {
                    berth:
                        {
                            //  Console.WriteLine("class is matched:");
                            Console.WriteLine("Enter the berth(upperberth or lowerberth or chaircar)");
                            type_of_berth = Console.ReadLine();
                            if (type_of_berth.ToLower() == "upperberth")
                            {
                                upperberth_count = starting + 7;
                                upperberth = Convert.ToInt32(list1[upperberth_count]);
                                if (upperberth > 0)
                                {
                                    Console.WriteLine("Enter the number of tickets to be booked:");
                                    no_of_tickets = Convert.ToInt32(Console.ReadLine());
                                    available_seats = upperberth - no_of_tickets;
                                    Console.WriteLine("The available seats are: " + available_seats);

                                    if (available_seats < 0)
                                    {
                                        Console.WriteLine("The available seats are: " + upperberth);
                                        goto berth;
                                    }
                                    if (upperberth == 0)
                                    {
                                        Console.WriteLine("Not available in upperberth" + upperberth);
                                    }

                                }
                            }
                            else if (type_of_berth.ToLower() == "lowerberth")
                            {
                                lowerberth_count = starting + 8;
                                lowerberth = Convert.ToInt32(list1[lowerberth_count]);
                                if (lowerberth > 0)
                                {
                                    Console.WriteLine("Enter the number of tickets to be booked:");
                                    no_of_tickets = Convert.ToInt32(Console.ReadLine());
                                    available_seats = lowerberth - no_of_tickets;
                                    Console.WriteLine("The available seats are: " + available_seats);

                                    if (available_seats < 0)
                                    {
                                        Console.WriteLine("The available seats are: " + lowerberth);
                                        goto berth;
                                    }
                                    if (lowerberth == 0)
                                    {
                                        Console.WriteLine("Not available in upperberth" + lowerberth);
                                    }

                                }





                            }
                            else if (type_of_berth.ToLower() == "chaircar")
                            {
                                chaircar_count = starting + 9;
                                chaircar = Convert.ToInt32(list1[chaircar_count]);
                                if (chaircar > 0)
                                {
                                    Console.WriteLine("Enter the number of tickets to be booked:");
                                    no_of_tickets = Convert.ToInt32(Console.ReadLine());
                                    available_seats = chaircar - no_of_tickets;
                                    Console.WriteLine("The available seats are: " + available_seats);

                                    if (available_seats < 0)
                                    {
                                        Console.WriteLine("The available seats are: " + chaircar);
                                        goto berth;
                                    }
                                    if (chaircar == 0)
                                    {
                                        Console.WriteLine("Not available in chaircar" + chaircar);
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Not available:");
                                    goto berth;
                                }
                            }
                        }

                        price = starting + 11;
                    }

                }


                sqlconn = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
                sqlconn.Open();
                sqlcomm = new SqlCommand("sp_Display1", sqlconn);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add(new SqlParameter("@type_of_berth", SqlDbType.VarChar, 40)).Value = type_of_berth;
                sqlcomm.Parameters.Add(new SqlParameter("@trainname", SqlDbType.VarChar, 40)).Value = train_name;
                reader = sqlcomm.ExecuteReader();
                int count = reader.FieldCount;
                int berth = 0;
                while (reader.Read())
                {
                    for (int i = 0; i < count; i++)
                    {
                        berth = reader.GetInt32(i);
                    }
                }
            }

            //username and gender fetching.
            User u;
            username = User.loginusername;
            Console.WriteLine("The username is:" + username);
            sqlconn = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
            sqlconn.Open();
            sqlcomm = new SqlCommand("sp_registrationdisplay1", sqlconn);
            sqlcomm.CommandType = CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 40)).Value = username;
            reader = sqlcomm.ExecuteReader();
            gender = null;
            while (reader.Read())
            {
                gender = reader[1].ToString();
            }
            sqlconn.Close();
            price = TicketOperation.price;
            train_number = TicketOperation.train_number;
            Console.WriteLine("***************************");
            Console.WriteLine("username:" + username);
            Console.WriteLine("gender:" + gender);
            Console.WriteLine("type_of_berth:" + type_of_berth);
            Console.WriteLine("available_seats:" + available_seats);
            Console.WriteLine("type_of_class:" + type_of_class);
            Console.WriteLine("train number:" + train_number);
            Console.WriteLine("train name:" + train_name);
            Console.WriteLine("no.of tickets:" + no_of_tickets);
            Console.WriteLine("price:" + price);
            Console.WriteLine("***************************");
            Console.WriteLine("Are you sure want to book the ticket if yes please enter(BookNow) or enter exit");
            String book = Console.ReadLine();
            if (book.ToLower() == "booknow")
            {
                BookingandCancellation b = new BookingandCancellation();
                b.booking();
            }
        }
    }
}