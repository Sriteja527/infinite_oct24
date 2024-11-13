using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment_2
{
    public class Products : IComparable<Products>
    {
        public int productid { get; set; }
        public String productname { get; set; }
        public int price { get; set; }
        public Products(int productid, String productname, int price)
        {
            productid = productid;
            productname = productname;
            price = price;
        }
        public int CompareTo(Products other)
        {
            if(other == null)
            {
                return 1;
            }
            if(this.price > other.price)
            {
                return 1;
            }
            else if(this.price < other.price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
        public static void Main(String[] args)
        {
            List<Products> products = new List<Products>(); 
            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Enter details for product:");
                Console.WriteLine("Enter productid:");
                int productid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the product name:");
                String productname = Console.ReadLine();
                Console.WriteLine("Enter price:");
                int price = Convert.ToInt32(Console.ReadLine());
                products.Add(new Products(productid, productname, price));
                Console.WriteLine();

            }
            products.Sort();
            foreach(var product in products)
            {
                Console.WriteLine($"{product.productid}\t {product.productname}\t {product.price}");
            }
            Console.Read();
  


        }
    }
}
