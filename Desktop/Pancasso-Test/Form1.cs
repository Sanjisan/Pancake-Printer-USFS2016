﻿using System;
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
using System.Threading.Tasks;

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

        private async void SVGButton_Click(object sender, EventArgs e)
        {   
            //if (File.Exists(@SVGLocationBox.Text))
            //{
                mouseControlForm mouseForm = new mouseControlForm();
                mouseForm.setPanPort(panPort);
                mouseForm.Show();

                InterpretSVG svg;
                var points = new Point();

                //SerialMonitor serialMon = new SerialMonitor();
                //serialMon.setPanPort(panPort);
                //serialMon.Show();

                var testSend = new Queue<Point>();

                // Starting values for dummy pancasso input
                points.X = 390;
                points.Y = 350;

                // Generate more dummy values, and push to queue.
                while (points.X > 320) //1
                {
                    points.X--;
                    points.Y--;

                    testSend.Enqueue(points);
                }
                while (points.X < 460) //2
                {
                    points.X++;

                    testSend.Enqueue(points);
                }
                while (points.X > 390) //3
                {
                    points.X--;
                    points.Y--;

                    testSend.Enqueue(points);
                }
                while (points.X > 320) //4
                {
                    points.X--;
                    points.Y++;

                    testSend.Enqueue(points);
                }
                while (points.X > 250) //5
                {
                    points.X--;
                    points.Y--;

                    testSend.Enqueue(points);
                }
                while (points.X < 530) // 6
                {
                    points.X++;

                    testSend.Enqueue(points);
                }
                while (points.X > 390) // 7
                {
                    points.X--;
                    points.Y++;

                    testSend.Enqueue(points);
                }

            // Dequeue dummy values and actually send to pancasso
            while (testSend.Count >= 1)
                {
                    points = testSend.Dequeue();
                    mouseForm.sendToPancasso(points.X.ToString(), points.Y.ToString(), "-40");
                    await Task.Delay(5);
                    mouseForm.SVGDisplay(points.X.ToString(), points.Y.ToString());
                }
            //}

            //else
                //MessageBox.Show("Enter a valid path for the SVG file. ie. C:\\test.svg");
        }
    }
}
