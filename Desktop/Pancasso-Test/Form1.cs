using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Pancasso_Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        } 

        private void btnGetPorts_Click(object sender, EventArgs e)
        {
            string[] ListSerialPorts = null;
            ListSerialPorts = SerialPort.GetPortNames();
            ddlPorts.Items.Clear();
            foreach(string port in ListSerialPorts)
            {
                ddlPorts.Items.Add(port);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if ( btnConnect.Text == "Disconnect")
            {
                panPort.Close();
                btnConnect.Text = "Connect";
            }
            
            else if (ddlPorts.SelectedItem != null &&
                btnConnect.Text == "Connect")
            {
                panPort.PortName = ddlPorts.SelectedItem.ToString();
                try
                {
                    panPort.Open();
                }
                catch(System.IO.IOException ex)
                {
                    MessageBox.Show("Connection Failed. \nTry a different port.");
                    return;
                }
                
                btnConnect.Text = "Disconnect";
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string xyzCommand = "x" + txtX.Text + "y" + txtY.Text + "z" + txtZ.Text;
            if ( btnConnect.Text == "Disconnect")
            {
                panPort.Write(xyzCommand);
                lblDebug.Text = xyzCommand;
            }
        }

        private void btnOpenGrid_Click(object sender, EventArgs e)
        {
            mouseControlForm mouseForm = new mouseControlForm();
            mouseForm.setPanPort(panPort);
            mouseForm.Show();
        }

        private void btnOpenMonitor_Click(object sender, EventArgs e)
        {
            SerialMonitor serialMon = new SerialMonitor();
            serialMon.setPanPort(panPort);
            serialMon.Show();
        }
    }
}
