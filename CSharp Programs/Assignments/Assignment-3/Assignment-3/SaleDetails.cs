using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class SaleDetails
    {
        static int Salesno;
        static int Productno;
        static float Price;
        static DateTime dateofsale;
        static int qty;
        static int TotalAmount;
        public SaleDetails(int salesno, int productno, float price, DateTime Dateofsale, int Qty)
        {
            Salesno = salesno;
            Productno = productno;
            Price = price;
            dateofsale = Dateofsale;
            qty = Qty;
            Sales(qty, Price);
        }
        public void Sales(int qty, float Price)
        {
            TotalAmount = (int)(qty * Price);
        }
        public static void ShowData()
        {
            Console.WriteLine("The sales number is:" + Salesno);
            Console.WriteLine("The product number is:" + Productno);
            Console.WriteLine("The price number is:" + Price);
            Console.WriteLine("The dateofsale number is:" + dateofsale);
            Console.WriteLine("The quantity is:" + qty);
        }

        public static void Main(String[] args)
        {
            Console.WriteLine("Enter the salesno:");
            Salesno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the productno:");
            Productno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the price:");
            Price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Enter the dateofsale:");
            dateofsale = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Enter the qty:");
            qty = Convert.ToInt32(Console.ReadLine());
            


            SaleDetails s = new SaleDetails(Salesno, Productno, Price, dateofsale, qty);
            SaleDetails.ShowData();
            Console.WriteLine("The total quantity is:" + TotalAmount);
            Console.Read();
        }
    }
}
