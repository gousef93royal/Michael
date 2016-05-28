using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        private int productId;
        private string name;
        private double price;
        private double totprice;
      
      



        public int ProductId { get { return productId; } set { productId = value; } }
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }


        public Product(int productId, string name, double price)
        {
            this.productId = productId;
            this.name = name;
            this.price = price;
        }
        public override string ToString()
        {
            return  " " + name + ", " + "Price :" + price;
        }

     

    }
}
