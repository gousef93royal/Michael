using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Shop
{
    public class Shop
    {
        private DataHelper helper;
        private Client client;
       


        private MySqlConnection MySqlconnection;

        //To automatically connect to the database when the shop runs
        public Shop()
        {
            helper = new DataHelper();
            MySqlconnection = new MySqlConnection(helper.SqlString);

            helper.connect();

        }


        //Return the client with the rfid tag
        public Client SearchClient(string RFID)
        {
            string sql = "SELECT first_name, last_name,AccountNumber,MoneyBalance,InEvent,RFID FROM client WHERE RFID =\"" + RFID + "\";";
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
                    client = new Client(first_name, last_name, accountNr, Moneybalance);

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
            return client;
        }

        //Return a list of snacks from the database
        public List<Snack> GetAllSnacks()
        {
            string sql = "SELECT * FROM Product WHERE IsItSnack = \"1\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            List<Snack> snackList  = new List<Snack>();

            try
            {

                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Snack snack;

                int productId;
                String name;
                int quantity;
                double price;
                bool isItSnack;
                string pathstring;
                while (reader.Read())
                {

                    productId = Convert.ToInt32(reader[0]);
                    name = Convert.ToString(reader[1]);
                    //quantity = Convert.ToInt32(reader[2]);
                    price = Convert.ToDouble(reader[3]);
                    isItSnack = Convert.ToBoolean(reader[4]);
                    pathstring = Convert.ToString(reader[5]);
                    snack = new Snack(productId, name, price);

                    snackList.Add(snack);
                }


            }
            catch (MySqlException e)
            {


            }
            finally
            {
                MySqlconnection.Close();
            }
            return snackList;
        }

        public List<Drink> GetAllDrinks()
        {
            string sql = "SELECT * FROM Product WHERE IsItSnack = \"0\";";
            MySqlCommand command = new MySqlCommand(sql, MySqlconnection);
            List<Drink>  drinksList = new List<Drink>();

            try
            {

                MySqlconnection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                Drink drink;

                int productId;
                String name;
                int quantity;
                double price;
                bool isItSnack;
                string pathstring;
                while (reader.Read())
                {

                    productId = Convert.ToInt32(reader[0]);
                    name = Convert.ToString(reader[1]);
                    quantity = Convert.ToInt32(reader[2]);
                    price = Convert.ToDouble(reader[3]);
                    isItSnack = Convert.ToBoolean(reader[4]);
                    pathstring = Convert.ToString(reader[5]);
                    drink = new Drink(productId, name, price);

                    drinksList.Add(drink);
                }


            }
            catch (MySqlException e)
            {

            }
            finally
            {
                MySqlconnection.Close();
            }
            return drinksList;
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

    }
}
