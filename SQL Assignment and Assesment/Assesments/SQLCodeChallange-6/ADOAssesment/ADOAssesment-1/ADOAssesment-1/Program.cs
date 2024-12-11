using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ADOAssesment_1
{
    public class Program
    {
        public static SqlConnection connection = null;
        public static SqlCommand command = null;
        public static IDataReader reader = null;
        void Operations()
        {
           
            connection = new SqlConnection("Data source = ICS-LT-D244D6GL; database = ADOAssesment; trusted_connection = true;");
            Console.WriteLine("Successfully connected:");
          
            connection.Open();
           
            command = new SqlCommand("sp_productdetails", connection);
            command.CommandType = CommandType.StoredProcedure;
           
           
                Console.WriteLine("Enter the product id:");
                int ProductId = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Product_name:");
                String ProductName = Console.ReadLine();
                Console.WriteLine("Enter the Product price:");
                float Price = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine("Enter the discounted Price:");
                float DiscountedPrice = Convert.ToSingle(Console.ReadLine());
                DiscountedPrice = Price - 0.10f;
                

                
                command.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int)).Value = ProductId;
                command.Parameters.Add(new SqlParameter("@productName", SqlDbType.VarChar, 40)).Value = ProductName;
                command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Float)).Value = Price;
                command.Parameters.Add(new SqlParameter("@DiscountedPrice", SqlDbType.Float)).Value = DiscountedPrice;
                
                

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Success:");
                }
                else
                {
                    Console.WriteLine("Fail:");
                }
            connection.Close();
            
           
            }
        void select()
        {
            connection = new SqlConnection("Data source = ICS-LT-D244D6GL; database = ADOAssesment; trusted_connection = true;");
            Console.WriteLine("Successfully connected:");
            
            connection.Open();
            
            command = new SqlCommand("sp_productdetails2", connection);
            command.CommandType = CommandType.StoredProcedure;
            Console.WriteLine("Enter the product id:");
            int product_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Product_name:");
            String Product_name = Console.ReadLine();
            
            Console.WriteLine("Enter the Product_price:");
            float Product_price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the Discounted Price:");
            float Discounted_price = Convert.ToSingle(Console.ReadLine());
            
            command.Parameters.Add(new SqlParameter("@productId", SqlDbType.Int)).Value = product_id;
            command.Parameters.Add(new SqlParameter("@productName", SqlDbType.VarChar, 40)).Value = Product_name;
            command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Float)).Value = Product_price;
            command.Parameters.Add(new SqlParameter("@DiscountedPrice", SqlDbType.Float)).Value = Discounted_price;
            

            reader = command.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Product id is:" + reader[0] + "\t" + "product name is:" + reader[1] + "\t" + "product_quantity is:" + reader[2] + "\t" + "product price is:" + reader[3]);
            }
        }
        public static void Main(string[] args)
        {
            Program p = new Program();
            p.Operations();
            p.select();
            Console.Read();
        }
    }
}
