using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Client
    {
        private int accountNumber;
        private string first_name;
        private string last_name;
        private string rfid;
        private string address;
        private string zipCode;
        private string email;
        private string gender;
        private DateTime dateOfBirth;
        private double moneyBalance;
        private bool inEvent;
        private string password;

        public int AccountNumber { get { return accountNumber; } set { accountNumber = value; } }
        public string First_name { get { return first_name; } set { first_name = value; } }
        public string Last_name { get { return last_name; } set { last_name = value; } }
        public string Rfid { get { return rfid; } set { rfid = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string ZipCode { get { return zipCode; } set { zipCode = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public DateTime DateOfBirth { get { return dateOfBirth; } set { dateOfBirth = value; } }
        public double MoneyBalance { get { return moneyBalance; } set { moneyBalance = value; } }
        public bool InEvent { get { return inEvent; } set { inEvent = value; } }
        public string Password { get { return password; } set { password = value; } }


        //constructor for registring a client

        public Client(int accountNumber, string first_name, string last_name, string rfid, string address, string zipCode, string email, string gender, DateTime dateOfBirth, double moneyBalance, bool inEvent, string password)
        {
            this.accountNumber = accountNumber;
            this.first_name = first_name;
            this.last_name = last_name;
            this.rfid = rfid;
            this.address = address;
            this.zipCode = zipCode;
            this.email = email;
            this.gender = gender;
            this.dateOfBirth = dateOfBirth;
            this.moneyBalance = moneyBalance;
            this.inEvent = inEvent;
            this.password = password;

        }

        public Client(string first_name, string last_name, int accountNumber, double moneyBalance)
        {
            this.first_name = first_name;
            this.last_name = last_name;
            this.accountNumber = accountNumber;
            this.moneyBalance = moneyBalance;
        }
        //Constructor for a client when borrowing material ..etc




        public override string ToString()
        {
            return "AccNum: " + Convert.ToString(accountNumber).PadLeft(6, '0') + " ; " + first_name + " " + last_name + " , Balance: €" + moneyBalance;
        }
    }
}
