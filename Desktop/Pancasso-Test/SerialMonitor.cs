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
    public partial class SerialMonitor : Form
    {

        public SerialMonitor()
        {
            InitializeComponent();
        }

        public void setPanPort(SerialPort port)
        {
            panPort = port;
        }

        private void panPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string Output = panPort.ReadExisting();
            rtbOutput.Text += Output;

        }

        private void rtbOutput_TextChanged(object sender, EventArgs e)
        {
            rtbOutput.SelectionStart = rtbOutput.Text.Length;
            rtbOutput.ScrollToCaret();
        }
    }
}
