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

namespace Version_1
{
    public partial class Main : Form
    {
        private RFID myRFIDReader;
        public Main()
        {
            InitializeComponent();
            try
            {
                myRFIDReader = new RFID();
                myRFIDReader.Attach += new AttachEventHandler(ShowWhoIsAttached);
                myRFIDReader.Detach += new DetachEventHandler(ShowWhoIsDetached);
                myRFIDReader.Tag += new TagEventHandler(ProcessThisTag);
                listBox1.Items.Add("Startup: So far so good.");
            }
            catch (PhidgetException) { listBox1.Items.Add("Error at startup."); }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                myRFIDReader.open();
                myRFIDReader.waitForAttachment(3000);
                listBox1.Items.Add("an RFID-Reader is found and opened.");
                myRFIDReader.Antenna = true;
                myRFIDReader.LED = true;
            }
            catch (PhidgetException) { listBox1.Items.Add("no RFID-Reader is opened"); }
        }
        private void ShowWhoIsAttached(object sender, AttachEventArgs e)
        {
            listBox1.Items.Add("RFID attached!, serial nr: " + e.Device.SerialNumber.ToString());
        }
        private void ShowWhoIsDetached(object sender, AttachEventArgs e)
        {
            listBox1.Items.Add("RFID detached!, serial nr: " + e.Device.SerialNumber.ToString());
        }
        private void ProcessThisTag(object sender, AttachEventArgs e)
        {
            listBox1.Items.Add("RFID has tag-nr: " + e.Tag);
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
