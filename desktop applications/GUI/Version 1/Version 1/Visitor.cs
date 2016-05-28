using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    class visitor
    {
        private DBhelper datahelper;
        private MySqlConnection MySqlconnection;
        private List<Items> items_List;
        private List<Materials> material_List;
        private Customer customer;

        public visitor()
        {
            datahelper = new DBhelper();
            MySqlconnection = new MySqlConnection(dataHelper.SqlString);

         
        }
        


        
        public Customer SearchCustomer(string RFID)
        {
            string sql = "SELECT * FROM client WHERE RFID =\"" + RFID + "\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string first_name = Convert.ToString(reader["First_Name"]);
                    string last_name = Convert.ToString(reader["Last_Name"]);
                    int accountNr = Convert.ToInt32(reader["AccountNumber"]);
                    double Moneybalance = Convert.ToDouble(reader["MoneyBalance"]);
                    customer = new Customer(first_name, last_name, accountNr, Moneybalance);

                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("The RFID is not in the database"); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return visitor;
        }
        public bool ChangeInEvent(int accnumber, int answer)
        {

            string sql = "UPDATE client SET InEvent =" + answer + " WHERE AccountNumber =" + accnumber;
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {

                MySqlconnection.Open();
                command.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return true;
        }
        public int CheckInEvent(int accnumber)
        {
            int answer = 0;
            string sql = "Select InEvent From client WHERE AccountNumber =" + accnumber;
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    answer = Convert.ToInt16(reader["InEvent"]);
                }
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return answer;
        }
        public void Recharge(int amount, int accountnr)
        {
            string sqll = "UPDATE `client` SET `MoneyBalance` = `MoneyBalance` + " + amount + " WHERE `AccountNumber` =" + accountnr + ";";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);

            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
        }
        public bool ReduceMoneyBalance(string RFID, int amount)
        {
            string sql = "UPDATE client SET MoneyBalance  = MoneyBalance - " + amount + " WHERE RFID = '" + RFID + "'";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);

            try
            {

                MySqlconnection.Open();
                command.ExecuteNonQuery();
            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return true;
        }
        public List<OrderLine> getAllOrdersNotPayed(int accountnumber)
        {
            string sql = "SELECT `name`,`price`,`Material_Material_id`,`Product_Prioduct_id` FROM `order_line` WHERE `Order_Order_id` IN (SELECT `Order_id` FROM `order`WHERE `Client_AccountNumber`=" + accountnumber + " AND `Payed` = 0 ) AND  `Material_Material_id` IS NOT NULL;";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            listOfOrders = new List<OrderLine>();

            try
            {

                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                OrderLine orderTopayed;

                string name;
                double price;

                while (reader.Read())
                {
                        name = Convert.ToString(reader["name"]);
                        price = Convert.ToDouble(reader["price"]);
                        orderTopayed = new OrderLine(name, price);

                        listOfOrders.Add(orderTopayed);
                    
                    
                }
                

            }
            catch (MySqlException e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);

            }
            finally
            {
                MySqlconnection.Close();
            }

            return listOfOrders;

        }
        public int GetOrderID()
        {

            string sql = "SELECT MAX(Order_id) FROM `order`";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            int result = 0;
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    result = (Convert.ToInt32(reader["MAX(Order_id)"])) + 1;
                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return result;
        }
        public double PayOrderPrice(int accountnumber)
        {

            string sqll = "SELECT sum(TotalPrice) as price FROM `order` WHERE `Client_AccountNumber` =" + accountnumber + " AND `Payed` = 0;";
            MySqlCommand command = new MySqlCommand(sqll, MySqlconnection);
            double orderTobePayedPrice = 0;
            try
            {
                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.IsDBNull(reader.GetOrdinal("price")))
                    {
                        orderTobePayedPrice = 0;
                    }
                    else
                    {
                        orderTobePayedPrice = Convert.ToDouble(reader["price"]);
                    }


                }

            }

            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("bad " + ex.Message); ;
            }
            finally
            {
                MySqlconnection.Close();
            }
            return orderTobePayedPrice;

        }
    }
}