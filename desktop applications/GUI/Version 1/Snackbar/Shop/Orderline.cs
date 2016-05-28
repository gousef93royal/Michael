using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class OrderLine
    {

           
        private int order_line_id;
        private string name;
        private int quantity;
        private Product product;
        private int product_id;
        private double price;
       // private BarApp bar = new BarApp();


        public int Order_id { get { return order_line_id; } set { order_line_id = value; }}
        public string Name { get { return name; } set { name = value; } }
        public double Price { get { return price; } set { price = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }
        public Product Product { get { return product; } set { product = value; } }
        public int Product_id { get { return product_id; } set { product_id = value; } }

        public OrderLine(string nm, int qua, Snack snacki)
        {

           // this.order_line_id = bar.GetOrderID();
            this.name = nm;
            this.price = snacki.Price;
            this.quantity = qua;
            this.product = snacki;
         //   snacklist = new Snack();
       
            
            
        }
        public OrderLine(string nm, int qua, Drink drinki)
        {
           // this.order_line_id = bar.GetOrderID(); 
            this.name = nm;
            this.quantity = qua;
            this.price = drinki.Price;
            product = drinki;
            
        }
       
        public string AsString()
        {
            return  "Name: " + name + "Price: "+ price +", Quantity: " + quantity  + " OrderLine-price: " + OrderLineTotal(); 
        
        }
        public double OrderLineTotal()
        {
            return price * quantity;
        }
    }
}
