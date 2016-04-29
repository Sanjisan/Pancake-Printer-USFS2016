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
using System.IO;
using System.Collections;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

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

        private string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);

        private void readBitmapButton_Click(object sender, EventArgs e)
        {
            _filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            System.IO.StreamWriter file = new System.IO.StreamWriter(_filePath + @"\test_assets\test.txt");

            Bitmap img = new Bitmap(_filePath + @"\test_assets\triforcebitmap.bmp");

            byte[,] byteArr = new byte[img.Height, img.Width];

            for (int i = 0; i < img.Height; i++)
            {
                for (int j = 0; j < img.Width; j++)
                {
                    Color c = img.GetPixel(j, i);

                    int r = c.R;
                    if (r > 100)
                        byteArr[i, j] = 0;
                    else
                        byteArr[i, j] = 1;
                    file.Write(byteArr[i, j] + " ");
                }
                file.WriteLine();
            }

            file.Close();
        }
    }
}
