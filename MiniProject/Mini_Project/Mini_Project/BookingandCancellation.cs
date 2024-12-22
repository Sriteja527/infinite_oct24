using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Mini_Project
{
    public class BookingandCancellation
    {
        public static SqlConnection sqlconnection = null;
        public static SqlCommand sqlcommand = null;
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
        public static String book;
        public static string source_point;
        public static string destination_point;
        public void booking()
        {
            int booked = 0;
            int notbooked = 0;
            TicketOperation o;
            source_point = TicketOperation.sourcepoint;
            destination_point = TicketOperation.destination_place;
            Console.WriteLine("source point is:" + source_point);
            Console.WriteLine("Destination point is:" + destination_point);
            BookingandPrice b;
            username = BookingandPrice.username;
            gender = BookingandPrice.gender;
            type_of_berth = BookingandPrice.type_of_berth;
            available_seats = BookingandPrice.available_seats;
            type_of_class = BookingandPrice.type_of_class;
            train_number = BookingandPrice.train_number;
            train_name = BookingandPrice.train_name;
            no_of_tickets = BookingandPrice.no_of_tickets;
            Console.WriteLine("The no.of tickets is:"+ no_of_tickets);
            Console.WriteLine("Enter the name:");
            String name = Console.ReadLine();
            Console.WriteLine("Enter the age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the mobilenumber:");
            String mobile_number = Console.ReadLine();
            price = BookingandPrice.price;
            String order_status = "Booked";
            sqlconnection = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
            sqlconnection.Open();
            sqlcommand = new SqlCommand("sp_insertbookings", sqlconnection);
            sqlcommand.CommandType = CommandType.StoredProcedure;
            sqlcommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 40)).Value = username;
            sqlcommand.Parameters.Add(new SqlParameter("@gender", SqlDbType.VarChar, 40)).Value = gender;
            sqlcommand.Parameters.Add(new SqlParameter("@type_of_berth", SqlDbType.VarChar, 40)).Value = type_of_berth;
            sqlcommand.Parameters.Add(new SqlParameter("@available_seats", SqlDbType.Int)).Value = available_seats;
            sqlcommand.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
            sqlcommand.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
            sqlcommand.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
            sqlcommand.Parameters.Add(new SqlParameter("@order_status", SqlDbType.VarChar, 40)).Value = order_status;
            sqlcommand.Parameters.Add(new SqlParameter("@no_of_tickets", SqlDbType.Int)).Value = no_of_tickets;
            sqlcommand.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 40)).Value = price;
            sqlcommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 40)).Value = name;
            sqlcommand.Parameters.Add(new SqlParameter("@age", SqlDbType.VarChar, 40)).Value = age;
            sqlcommand.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar, 10)).Value = mobile_number;
            sqlcommand.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
            sqlcommand.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;
            int result = sqlcommand.ExecuteNonQuery();
            if (result > 0)
            {
                booked = booked + 1;

            }
            else
            {
                notbooked = notbooked + 1;
            }
            
            if(booked == 1)
            {
                sqlconnection.Close();
                sqlconnection = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
                sqlconnection.Open();
                sqlcommand = new SqlCommand("sp_bookingdisplay", sqlconnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;
                sqlcommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 40)).Value = name;
                reader = sqlcommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("****************************");
                    Console.WriteLine("Ticked Booked:");
                    Console.WriteLine("username:" + reader[0]);
                    Console.WriteLine("gender:" + reader[1]);
                    Console.WriteLine("type of berth:" + reader[2]);
                    Console.WriteLine("type of class:" + reader[3]);
                    Console.WriteLine("train number:" + reader[4]);
                    Console.WriteLine("train name:" + reader[5]);
                    Console.WriteLine("order status:" + reader[6]);
                    Console.WriteLine("no of tickets:" + reader[7]);
                    Console.WriteLine("name:" + reader[8]);
                    Console.WriteLine("age:" + reader[9]);
                    Console.WriteLine("price:" + reader[10]);
                    Console.WriteLine("mobilenumber:" + reader[11]);
                    Console.WriteLine("sourcepoint:" + reader[12]);
                    Console.WriteLine("destinationpoint" + reader[13]);
                    Console.WriteLine("**********************************");
                }
                sqlconnection.Close();

            }
            Console.WriteLine("if you want to cancel tickets then enter(CancelTicket) or enter exit:");
            String cancel = Console.ReadLine();

            if (cancel.ToLower() == "cancelticket")
            {
                // Update the available seats
                available_seats = available_seats + no_of_tickets;

                // Set up the SQL connection and command
                SqlConnection sqlconnection = new SqlConnection("Data source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
                sqlconnection.Open();

                SqlCommand sqlcommand = new SqlCommand("sp_CancelTicket", sqlconnection);
                sqlcommand.CommandType = CommandType.StoredProcedure;

                // Add parameters to the command
                sqlcommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 40)).Value = username;
                sqlcommand.Parameters.Add(new SqlParameter("@type_of_berth", SqlDbType.VarChar, 40)).Value = type_of_berth;
                sqlcommand.Parameters.Add(new SqlParameter("@available_seats", SqlDbType.Int)).Value = available_seats;
                sqlcommand.Parameters.Add(new SqlParameter("@no_of_tickets", SqlDbType.Int)).Value = no_of_tickets;
                sqlcommand.Parameters.Add(new SqlParameter("@type_of_class", SqlDbType.VarChar, 40)).Value = type_of_class;
                sqlcommand.Parameters.Add(new SqlParameter("@train_number", SqlDbType.Int)).Value = train_number;
                sqlcommand.Parameters.Add(new SqlParameter("@train_name", SqlDbType.VarChar, 40)).Value = train_name;
                sqlcommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 40)).Value = name;
                sqlcommand.Parameters.Add(new SqlParameter("@age", SqlDbType.Int)).Value = age;
                sqlcommand.Parameters.Add(new SqlParameter("@mobile_number", SqlDbType.VarChar, 10)).Value = mobile_number;
                sqlcommand.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = source_point;
                sqlcommand.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_point;

                // Execute the stored procedure
                int result1 = sqlcommand.ExecuteNonQuery();

                // Check result and give feedback
                if (result1 > 0)
                {
                    Console.WriteLine("********************");
                    Console.WriteLine("Ticket Cancelled:");
                    Console.WriteLine("********************");
                }
                else
                {
                    Console.WriteLine("Not cancelled:");
                }

                // Close the connection
                sqlconnection.Close();
            }
            else
            {
                Console.WriteLine("ThankYou:");
            }




        }
        }
    }

