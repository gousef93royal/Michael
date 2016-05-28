using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Phidgets;
using Phidgets.Events;
using MySql.Data.MySqlClient;

namespace Shop
{
    public partial class RechargeForm : Form
    {
        private int account;
        private double moneybalance;
        private RFID myRfidReader;
        private string rfidTag;
        private Client client;
        private Shop shop;
        private DataHelper dataHelper;

        public RechargeForm()
        {
            InitializeComponent();
            shop = new Shop();
            dataHelper = new DataHelper();
            dataHelper.connect();
            initRFID();
            ReadChip();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            RechargeForm.ActiveForm.Hide();
            var form1 = new ShopMain();
            form1.Show();


        }

        private void initRFID()
        {
            try
            {
                myRfidReader = new RFID();
                myRfidReader.Tag += new TagEventHandler(RfidReaderTag);
            }
            catch (PhidgetException e)
            {
                MessageBox.Show(e.Message);

            }
        }

        private void RfidReaderTag(object sender, TagEventArgs e)
        {
            rfidTag = Convert.ToString(e.Tag);
            client = shop.SearchClient(rfidTag);
            label1.Text = "Account: " + client.AccountNumber;
            label3.Text = "MoneyBalance: " + client.MoneyBalance;

        }

        private void ReadChip()
        {

            try
            {

                myRfidReader.open();
                myRfidReader.waitForAttachment(3000);
                myRfidReader.Antenna = true;
                myRfidReader.LED = true;
                //MessageBox.Show("RFID reader is found and opennn");

            }
            catch (PhidgetException e)
            {
                MessageBox.Show(e.Message);
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(textBox1.Text);
            shop.Recharge(amount, client.AccountNumber);
        }
    }
}
