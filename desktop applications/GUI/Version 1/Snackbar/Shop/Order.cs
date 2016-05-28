using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Order
    {
        private string date;
        private double totalPrice;
        private List<OrderLine> orderLineList;
        private OrderLine orderline;
        private int order_id;
        private int accountNumber;
        private int isPayed;

        public int Order_id { get { return order_id; } set { order_id = value; } }
        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public int IsPayed { get { return isPayed; } set { isPayed = value; } }
        public string Date { get { return date; } set { date = value; } }
        public double TotalPrice { get { return totalPrice; } set { totalPrice = value; } }
        public List<OrderLine> OrderLineList { get { return orderLineList; } set { orderLineList = value; } }
        public OrderLine Orderline { get { return orderline; } set { orderline = value; } }

        public Order()
        {
            isPayed = 0;
            this.orderLineList = new List<OrderLine>();
        }


        public Order(int order_id, double totalPrice, string date, int account, int ispayed)
        {
            this.order_id = order_id;
            this.totalPrice = totalPrice;
            this.date = date;
            this.accountNumber = account;
            this.isPayed = ispayed;

        }




        public double orderGetTotalPrice()
        {


            return totalPrice;
        }
        public List<OrderLine> getAllOrderLines()
        {
            return orderLineList;

        }
        public void AddOrderLine(OrderLine neworder)
        {

            totalPrice += neworder.Price;
            this.orderLineList.Add(neworder);
        }
        public void RemoveOrderLine(int i)
        {

            totalPrice -= orderLineList.ElementAt(i).Price;
            this.orderLineList.RemoveAt(i);
        }

        public string AsString()
        {
            return "Order_id: " + order_id + " Price: " + totalPrice + " Date: " + date + "Account: " + accountNumber;
        }

    }
}
