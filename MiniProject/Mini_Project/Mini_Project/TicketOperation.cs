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
    public class TicketOperation
    {
        public static SqlConnection sqlconn = null;
        public static SqlCommand sqlcomm = null;
        public static IDataReader reader = null;
        public static String train_name = null;
        public static int train_number = 0;
        public static string type_of_class = null;
        public static int upper_berth = 0;
        public static int lower_berth = 0;
        
        public static int chaircar = 0;
        public static int price = 0;
        public static String sourcepoint = null;
        public static String destination_place = null;
        public static DateTime source_date;
        public static ArrayList list;
        public void operations()
        {
        details:
            {
                Console.WriteLine("Enter the Pickup place:");
                sourcepoint = Console.ReadLine();
                Console.WriteLine("Enter the destination place:");
                destination_place = Console.ReadLine();
                Console.WriteLine("Enter the source date with time:Enter date in (yyyy-MM-dd hh:mm)");
                DateTime source_time_part = Convert.ToDateTime(Console.ReadLine());

                TimeSpan source_time = source_time_part.TimeOfDay;
                source_date = source_time_part.Date;
            }
                sqlconn = new SqlConnection("Data Source = ICS-LT-D244D6GL; database = RailwaySystem; trusted_connection = true;");
                sqlconn.Open();
                sqlcomm = new SqlCommand("sp_displaytraindetails", sqlconn);
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.Parameters.Add(new SqlParameter("@source_point", SqlDbType.VarChar, 40)).Value = sourcepoint;
                sqlcomm.Parameters.Add(new SqlParameter("@destination_point", SqlDbType.VarChar, 40)).Value = destination_place;
                //  sqlcomm.Parameters.Add(new SqlParameter("@source_time", SqlDbType.Time)).Value = source_time;
                sqlcomm.Parameters.Add(new SqlParameter("@source_date", SqlDbType.Date)).Value = source_date;
            
            reader = sqlcomm.ExecuteReader();
            int count = reader.FieldCount;
            list = new ArrayList();
            bool dataAvailable = false;
            while (reader.Read())
            {

                if (reader[0] != DBNull.Value && reader[1] != DBNull.Value && reader[2] != DBNull.Value &&
                    reader[3] != DBNull.Value && reader[4] != DBNull.Value && reader[5] != DBNull.Value &&
                    reader[6] != DBNull.Value && reader[7] != DBNull.Value && reader[8] != DBNull.Value &&
                    reader[9] != DBNull.Value && reader[10] != DBNull.Value && reader[11] != DBNull.Value)
                {

                    dataAvailable = true;


                    Console.WriteLine("=================================");
                    Console.WriteLine("Train details:");
                    train_number = reader.GetInt32(0);
                    Console.WriteLine("train number:" + reader[0]);
                    Console.WriteLine("train name:" + reader[1]);
                    // for(int i=0;i < count; i++) { 
                    //  list.Add(reader[1]);
                    // }
                    Console.WriteLine("pickup point:" + reader[2]);
                    Console.WriteLine("Destination point:" + reader[3]);
                    Console.WriteLine("source time:" + reader[4]);
                    Console.WriteLine("seats available in:");
                    Console.WriteLine("type of class:" + reader[5] + " is available");
                    type_of_class = reader[5].ToString();
                    Console.WriteLine("total_berth:" + reader[6] + " is available");
                    Console.WriteLine("upper_berth:" + reader[7] + " is available");
                    upper_berth = reader.GetInt32(7);
                    Console.WriteLine("lower_berth:" + reader[8] + " is available");
                    lower_berth = reader.GetInt32(8);

                    DateTime date = reader.GetDateTime(11);
                    string formattedDate = date.ToString("yyyy/MM/dd");
                    Console.WriteLine("source_date:" + formattedDate);
                    Console.WriteLine("chaircar:" + reader[9]);
                    chaircar = reader.GetInt32(9);
                    Console.WriteLine("price" + reader[10]);
                    price = reader.GetInt32(10);
                    Console.WriteLine("=============================");
                    for (int i = 0; i < count; i++)
                    {
                        list.Add(reader[i]);
                    }

                }
            }
            int data_count = 0;
            if (!dataAvailable)
            {
                Console.WriteLine("Trains are not available.");
                Console.WriteLine("Do you want to continue or exit if continue please enter(continue) or enter (exit)");
                String con = Console.ReadLine();
                if(con.ToLower() == "continue")
                {
                    data_count = data_count + 1;
                    goto details;
                }
            }
            else
            {
                Console.WriteLine("Thank you:");
            }
            if (data_count > 0 || dataAvailable)
            {
                Console.WriteLine("If you want to Book ticket please enter (yes)");
                String ticketok = Console.ReadLine();  // yes
                if (ticketok == "yes")
                {
                    BookingandPrice p = new BookingandPrice();
                    p.Price();
                }
            }

            


        }
    }
}
