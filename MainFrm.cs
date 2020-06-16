using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ComPort
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            string[] ArryPort = System.IO.Ports.SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            for (int i = 0; i < ArryPort.Length; i++)
            {
                comboBox1.Items.Add(ArryPort[i]);
            }

            comboBox1.SelectedItem = "COM1";
            comboBox2.SelectedItem = "9600";
            comboBox3.SelectedItem = "8";
            comboBox4.SelectedItem = "1";
            comboBox5.SelectedItem = "NONE";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button functionality toggles depending on port status
            if (serialPort1.IsOpen)
            {
                //unhook the event handler
                //serialPort1.DataReceived -= new System.IO.Ports.SerialDataReceivedEventHandler(spPort_DataReceived);
                //close the port
                serialPort1.Close();
                mnuConnect.Text = "Connect";
                button1.Text = "打开";
                //btnSend.Enabled = false;
            }
            else
            {
                //reset the data textbox
                txtData.Text = "";
                //set the port settings
                serialPort1.PortName = comboBox1.SelectedItem.ToString();
                serialPort1.BaudRate = int.Parse(comboBox2.Text);

                try
                {
                    //try openning the port and hook up the events
                    serialPort1.Open();
                    //serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(spPort_DataReceived);
                    mnuConnect.Text = "Disconnect";
                    button1.Text = "关闭";
                    //btnSend.Enabled = true;
                }
                catch
                {
                    //an exception may happen if the port isn't actually valid
                    MessageBox.Show("Port not recognised", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
