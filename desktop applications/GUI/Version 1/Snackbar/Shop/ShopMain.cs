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

namespace Shop
{
    public partial class ShopMain : Form
    {


        private Shop shop;
        private List<Snack> snakList;
        private String holder1;
        private double holder2;
        private int quanTextbox;
        private int produrcID;
        private RFID myRfidReader;
        private Order order;
        private Client client;
        //Current RFID tag
        private string myRfid;
        private double totalprice = 0;



        public ShopMain()
        {
            InitializeComponent();
            //make the form start in full screen
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;

            //init Shop
            shop = new Shop();

            //Initialize RFID reader
            initializaRFID();

           

            //get all snacks & drinks from database
            getAllSnackFromDb();
            getAllDrinksFromDb();

            //Create an empty order
            order = new Order();

        }

        private void initializaRFID()
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

        private void ReadChip()
        {
            try
            {
                myRfidReader.open();
                myRfidReader.waitForAttachment(3000);
                //MessageBox.Show("RFID reader is found and open");
                myRfidReader.Antenna = true;
                myRfidReader.LED = true;
            }
            catch (PhidgetException)
            {
                MessageBox.Show("No RFID reader found");
            }
        }

        private void RfidReaderTag(object sender, TagEventArgs e)
        {
            myRfid = Convert.ToString(e.Tag);
            //MessageBox.Show(myRfid);

            //get client by RFID number from database
            client = shop.SearchClient(myRfid);
            //set the account & balance
            lbBalance.Text = "Balance: " + Convert.ToString(client.MoneyBalance);
            lbAccount.Text = "Account: " + Convert.ToString(client.AccountNumber);


            //if (listBox1.Items.Count != 0)
            //{
            //    toPay = true;
            //}
            //else
            //{
            //    toPay = false;
            //}
            //if (this.toPay)
            //{

            //}
        }

        public void getAllSnackFromDb()
        {
            int counter = 0;
            MyButton my = new MyButton();
            MyButton[] snacksButtons = new MyButton[100];
            int wOfButton = 110; //width
            int hOfButton = 100; //hight
            Point xy = new Point(10, 10);
            int space = 130;
            int maxPossition = 4;
            List<Snack> tempSnackList = shop.GetAllSnacks();
            int possition;

            for (int y = 0; y < 3; y++)
            {

                for (int x = 0; x < maxPossition; x++)
                {
                    possition = (y * (maxPossition) + x);
                    snacksButtons[possition] = new MyButton();
                    snacksButtons[possition].Location = xy;
                    snacksButtons[possition].Price = tempSnackList[possition].Price;
                    snacksButtons[possition].Text = tempSnackList[possition].Name;
                    snacksButtons[possition].ProductId1 = tempSnackList[possition].ProductId;
                    //  snacksButtons[possition].Image = imageList1.Images[counter];
                    // snacksButtons[possition].Image = imageList1.Images[tempSnackList[possition].ProductId - 1];
                    snacksButtons[possition].Size = new System.Drawing.Size(wOfButton, hOfButton);
                    tabPage1.Controls.Add(snacksButtons[possition]);
                    snacksButtons[possition].Click += new EventHandler(onClick);
                    xy.X += space;
                    counter++;
                    if (counter >= 12)
                    {
                        counter = 0;
                    }
                }
                xy.Y += space;
                xy.X = 10;

            }

        }
        public void getAllDrinksFromDb()
        {
            int counter = 0;
            MyButton[] drinksButtons = new MyButton[100];
            int wOfButton = 110; //width
            int hOfButton = 100; //hight
            Point xy = new Point(10, 10);
            int space = 130;
            int maxPossition = 4;
            List<Drink> tempDrinksList = shop.GetAllDrinks();
            int possition;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < maxPossition; x++)
                {
                    possition = (y * (maxPossition) + x);
                    drinksButtons[possition] = new MyButton();
                    drinksButtons[possition].Location = xy;
                    drinksButtons[possition].Price = tempDrinksList[possition].Price;
                    drinksButtons[possition].Text = tempDrinksList[possition].Name;
                    //drinksButtons[possition].ProductId1 = tempDrinksList[possition].ProductId;
                    //drinksButtons[possition].Image = imageList2.Images[(tempDrinksList[possition].ProductId - 13)];
                    drinksButtons[possition].Size = new System.Drawing.Size(wOfButton, hOfButton);
                    tabPage2.Controls.Add(drinksButtons[possition]);
                    drinksButtons[possition].Click += new EventHandler(onClick);
                    xy.X += space;
                    counter++;
                    if (counter >= 12)
                    {
                        counter = 0;
                    }
                }
                xy.Y += space;
                xy.X = 10;
            }
        }

        private void onClick(object sender, EventArgs e)
        {
            quanTextbox = Convert.ToInt16(numericUpDown1.Value);
            String name = ((MyButton)sender).Text;
            double price = ((MyButton)sender).Price;
            int id = ((MyButton)sender).ProductId1;



            //  listBox1.Items.Add(snack.ToString());

            if (tabControl1.SelectedTab == tabPage1)
            {
                Snack snack = new Snack(id, name, price);
                OrderLine orderLine = new OrderLine(holder1, quanTextbox, snack);
                order.AddOrderLine(orderLine);
                listBox1.Items.Add(orderLine.AsString());
                double p = 0;
                foreach (OrderLine item in order.getAllOrderLines())
                {
                    p += item.Price * item.Quantity;
                }
                lbTotal.Text = "Total: € " + p;
            }
            else if (tabControl1.SelectedTab == tabPage2)
            {
                Drink drink = new Drink(id, name, price);
                OrderLine orderLine = new OrderLine(drink.Name, quanTextbox, drink);
                order.AddOrderLine(orderLine);
                listBox1.Items.Add(orderLine.AsString());
                double p = 0;
                foreach (OrderLine item in order.getAllOrderLines())
                {
                    p += item.Price * item.Quantity;
                }
                lbTotal.Text = "Total: € " + p;
            }
        }


        private void ShopMain_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void btnx_Click(object sender, EventArgs e)
        {
            totalprice = 0;
            try
            {
                int i = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(i);
                order.RemoveOrderLine(i);
                foreach (OrderLine orderline in order.getAllOrderLines())
                {
                    totalprice += orderline.OrderLineTotal();
                }
                lbTotal.Text = "Total : €" + totalprice.ToString();
            }
            catch (Exception)
            {

                MessageBox.Show("Please select which orderline to remove.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Open RFID reader
            ReadChip();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(client != null)
            {
                myRfidReader.close();
                RechargeForm rechargeForm = new RechargeForm();
                rechargeForm.Show();

                this.Hide();
               
            }
           
        }
    }
}
