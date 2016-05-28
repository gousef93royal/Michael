using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Shop
{
    public class DataHelper
    {
      private  MySqlConnection mySqlconnection;

        /////////////Qasim's database
      //Server=athena01.fhict.local;
        //Uid=dbi343326;
        //Database=dbi343326;
        //Pwd=password456;

      string connectionString = "server=athena01.fhict.local;" +
                                          "database=dbi343326;" +
                                          "user id=dbi343326;" +
                                          "password=password456;" +
                                          "connect timeout=30;";


      public string SqlString { get { return connectionString; } set { connectionString = value; } }

      public MySqlConnection MySqlconnection
      {
          get { return mySqlconnection; }
          set { mySqlconnection = value; }
      }
      
                
        public void connect()
        {
            string connectionString = "server=athena01.fhict.local;" +
                                          "database=dbi316696;" +
                                          "user id=dbi316696;" +
                                          "password=QkDcFEDI67;" +
                                          "connect timeout=30;";

            MySqlconnection = new MySqlConnection(connectionString);
            try
            {
                MySqlconnection = new MySqlConnection(connectionString);
                MySqlconnection.Open();
                //MessageBox.Show("connected");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (MySqlconnection != null)
                    MySqlconnection.Close();
            }
        }

    }
}
