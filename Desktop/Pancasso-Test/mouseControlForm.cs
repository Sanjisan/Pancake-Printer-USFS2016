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
    public partial class mouseControlForm : Form
    {

        SerialPort panPort;
        private Bitmap workSpace;
        private Bitmap overlay;

        private int _delta = 0;

        private bool LMB = false;
        private bool MMB = false;
        private bool RMB = false;

        public mouseControlForm()
        {
            
            InitializeComponent();
            this.pbOverlay.MouseWheel += new MouseEventHandler(this.pbOverlay_MouseWheel);
            Bitmap newWorkSpace = new Bitmap(panel1.Width, panel1.Height);
            Bitmap newOverlay = new Bitmap(pbOverlay.Width, pbOverlay.Height);
            this.workSpace = newWorkSpace;
            this.overlay = newOverlay;
        }

        private void mouseControlForm_Load(object sender, EventArgs e)
        {
            
        }


        public bool sendToPancasso(string x, string y, string z)
        {
            bool state = true;
            string newPosition = "x" + x + "y" + y + "z" + z;
            lblSending.Visible = true;
            try
            {
                panPort.Write(newPosition);
            }
            catch (System.InvalidOperationException ex)
            {
                //lblError.Visible = true;
                state = false;
            }
            lblSending.Visible = false;
            return state;
        }
        private void mouseControlForm_Shown(object sender, EventArgs e)
        {
            DrawFullFrame();
            if (!panPort.IsOpen)
            {
                //lblError.Visible = true;
            }
        }

        public void setPanPort(SerialPort port)
        {
            panPort = port;
        }

        private void DrawFullFrame()
        {
            using (Graphics bufferwksp = Graphics.FromImage(workSpace))
            {
                bufferwksp.FillRectangle(Brushes.Black, 0, 0, 800, 400);
                bufferwksp.FillPie(Brushes.White, 0, 0, 800, 800, 180, 180);
                bufferwksp.FillPie(Brushes.Black, 200, 200, 400, 400, 180, 180);
            }
            panel1.Invalidate();
        }

        public void SVGDisplay(string x, string y, string z)
        {
            lblLSX.Text = x;
            lblLSY.Text = y;
            //Draw the updated position
            DrawPoint(int.Parse(lblCPX.Text), int.Parse(lblCPY.Text));
        }

        public void SVGDisplay(string X, string Y)
        {
            lblLSX.Text = X;
            lblLSY.Text = Y;
            
            DrawPoint(int.Parse(lblCPX.Text), int.Parse(lblCPY.Text));
        }

        private void DrawPoint(int X, int Y, Point[] curvePoints)
        {
            var redPen = new Pen(Color.Red, 3);

            using (Graphics bufferOverlay = Graphics.FromImage(overlay))
            {
                bufferOverlay.DrawCurve(redPen, curvePoints);
                bufferOverlay.Clear(Color.Transparent);
                bufferOverlay.FillEllipse(Brushes.Red, (X - 3), (400 - Y - 3), 6, 6);
            }
            pbOverlay.Invalidate();
        }

        private void DrawPoint(int X, int Y)
        {

            using (Graphics bufferOverlay = Graphics.FromImage(overlay))
            {
                bufferOverlay.Clear(Color.Transparent);
                bufferOverlay.FillEllipse(Brushes.Red, (X - 3), (400 - Y - 3), 6, 6);
            }
            pbOverlay.Invalidate();
        }

        private void mouseControlForm_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(workSpace, Point.Empty);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void pnlOverlay_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImageUnscaled(overlay, Point.Empty);
        }

        private void pnlOverlay_MouseMove(object sender, MouseEventArgs e)
        {
            //update the panel xy coordinates
            lblCPX.Text = e.Location.X.ToString();
            lblCPY.Text = (400 - e.Location.Y).ToString();


            //if lmb has been clicked send the position
            if (LMB && !lblError.Visible)
            {
                if (sendToPancasso(lblCPX.Text, lblCPY.Text, lblCPZ.Text) == true)
                {
                    lblLSX.Text = lblCPX.Text;
                    lblLSY.Text = lblCPY.Text;
                    //Draw the updated position
                    DrawPoint(int.Parse(lblCPX.Text), int.Parse(lblCPY.Text));
                }
            }
        }

        private void pbOverlay_MouseWheel(object sender, MouseEventArgs e)
        {
            _delta += e.Delta;
            int delta = _delta / 120;
            _delta -= delta * 120;
            int z = int.Parse(lblCPZ.Text) + delta;
            lblCPZ.Text = z.ToString();
            if (LMB)
            {
                if (sendToPancasso(lblCPX.Text, lblCPY.Text, lblCPZ.Text))
                {
                    lblLSZ.Text = lblCPZ.Text;
                    //Draw the updated position
                    DrawPoint(int.Parse(lblCPX.Text), int.Parse(lblCPY.Text));
                }
            }
        }

        private void pbOverlay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && !lblError.Visible)
            {
                if (sendToPancasso(lblCPX.Text, lblCPY.Text, lblCPZ.Text))
                {
                    lblLSX.Text = lblCPX.Text;
                    lblLSY.Text = lblCPY.Text;
                    //Draw the updated position
                    DrawPoint(int.Parse(lblCPX.Text), int.Parse(lblCPY.Text));
                }
            }
            if (e.Button == MouseButtons.Middle && !lblError.Visible)
            {
                if (sendToPancasso(lblLSX.Text, lblLSY.Text, lblCPZ.Text))
                {
                    lblLSZ.Text = lblCPZ.Text;
                }
            }
        }

        private void pbOverlay_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LMB = true;
            }
            if (e.Button == MouseButtons.Middle)
            {
                MMB = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                RMB = true;
            }
        }

        private void pbOverlay_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                LMB = false;
            }
            if (e.Button == MouseButtons.Middle)
            {
                MMB = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                RMB = false;
            }
        }
    }
}
