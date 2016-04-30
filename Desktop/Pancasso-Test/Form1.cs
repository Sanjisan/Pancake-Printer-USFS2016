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
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace Pancasso_Test
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private struct byteImageLayer
        {
            public int x;
            public int y;
            public int z;
            public int width;
            public int height;
            public byte[] byteImage;


        }

        byteImageLayer currentLayer = new byteImageLayer();

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
        static readonly Regex binary = new Regex("^[01]{1,32}$", RegexOptions.Compiled);

        private void readBitmapButton_Click(object sender, EventArgs e)
        {
            string filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            //System.IO.StreamWriter file = new System.IO.StreamWriter(_filePath + @"\test_assets\test.txt");

            Bitmap img = new Bitmap(filePath + @"\test_assets\triforcebitmap.bmp");

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
                }
            }
            int count = 0;
            byte binaryHold = 0;
            Queue<byte> tempByteImage = new Queue<byte>();
            for (int i = 0; i < (img.Height*img.Width); i+=8)
            {
                count++;
                try
                {
                    if (i < (img.Height*img.Width) && byteArr[i/img.Width, i%img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 0));

                    if (i+1 < (img.Height*img.Width) && byteArr[i / img.Width, (1+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 1));

                    if (i+2 < (img.Height*img.Width) && byteArr[i / img.Width, (2+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 2));

                    if (i+3 < (img.Height*img.Width) && byteArr[i / img.Width, (3+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 3));         
                                                                              
                    if (i+4 < (img.Height*img.Width) && byteArr[i / img.Width, (4+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 4));         
                                                                              
                    if (i+5 < (img.Height*img.Width) && byteArr[i / img.Width, (5+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 5));         
                                                                              
                    if (i+6 < (img.Height*img.Width) && byteArr[i / img.Width, (6+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 6));

                    if (i+7 < (img.Height*img.Width) && byteArr[i / img.Width, (7+i) % img.Width] == 1)
                        binaryHold += Convert.ToByte(Math.Pow(2, 7));

                    tempByteImage.Enqueue(binaryHold);
                    binaryHold = 0;
                }
                catch { }
            }

            if (count == ((img.Width*img.Height - 1) / 8 + 1))
            {
                currentLayer.byteImage = tempByteImage.ToArray();
                currentLayer.width = img.Width;
                currentLayer.height = img.Height;
                btnSendBitmap.Enabled = true;
            }
            else
            {
                MessageBox.Show("Reading Bitmap failed");
            }
        }

        private void btnSendBitmap_Click(object sender, EventArgs e)
        {
            /*
            //debug*******************
            string filePath = Directory.GetParent(Directory.GetParent(_filePath).FullName).FullName;
            //************************
            */

            if (!panPort.IsOpen)
            {
                MessageBox.Show("Sending Failed, Connect Pancasso.");
                return;
            }

            currentLayer.x = int.Parse(txtX.Text);
            currentLayer.y = int.Parse(txtY.Text);
            currentLayer.z = int.Parse(txtZ.Text);
            
            //send the x,y,z,w,h
            string xyzwhCommand = "x" + currentLayer.x + "y" + currentLayer.y + "z" + currentLayer.z + "w" + currentLayer.width + "h" + currentLayer.height;
            panPort.Write(xyzwhCommand);

            /*
            //debug*******************
            string timeStamp = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath + @"\test_assets\" + timeStamp + "_Start.txt");
            file.Write(xyzwhCommand);
            file.Close();
            //************************
            */

            sendProgBar.Value = 0;
            sendProgBar.Maximum = currentLayer.byteImage.Length;
            for (int i = 0; i <currentLayer.byteImage.Length; i += 64)
            {
                System.Threading.Thread.Sleep(100);
                int numWrite = 64;
                if (currentLayer.byteImage.Length - i < 64)
                {
                    numWrite = currentLayer.byteImage.Length - i;
                }
                panPort.Write(currentLayer.byteImage, i, numWrite);
                sendProgBar.Value = i + numWrite;

                /*
                //debug*******************
                timeStamp = System.DateTime.Now.ToString("yyyyMMddHHmmssffff");
                string identifier = timeStamp + "_" + i.ToString() + "-" + (i + numWrite).ToString(); 
                //file = new System.IO.StreamWriter(filePath + @"\test_assets\" + timeStamp + ".txt");
                file = new System.IO.StreamWriter(filePath + @"\test_assets\" + identifier + ".txt");
                string filewrite = "";
                for (int j = i; j < (i + numWrite); j++)
                {
                    filewrite += currentLayer.byteImage[j].ToString() + " ";
                }
                file.Write(filewrite);
                file.Close();
                //************************
                */ 
            }
        }
    }
}
