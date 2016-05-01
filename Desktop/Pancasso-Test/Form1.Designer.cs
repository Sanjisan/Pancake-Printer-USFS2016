namespace Pancasso_Test
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panPort = new System.IO.Ports.SerialPort(this.components);
            this.btnGetPorts = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.ddlPorts = new System.Windows.Forms.ComboBox();
            this.lblx = new System.Windows.Forms.Label();
            this.lbly = new System.Windows.Forms.Label();
            this.lblz = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtZ = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblDebug = new System.Windows.Forms.Label();
            this.btnOpenGrid = new System.Windows.Forms.Button();
            this.btnOpenMonitor = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.readBitmapButton = new System.Windows.Forms.Button();
            this.btnSendBitmap = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.sendProgBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // panPort
            // 
            this.panPort.BaudRate = 256000;
            this.panPort.WriteBufferSize = 64;
            // 
            // btnGetPorts
            // 
            this.btnGetPorts.Location = new System.Drawing.Point(18, 18);
            this.btnGetPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGetPorts.Name = "btnGetPorts";
            this.btnGetPorts.Size = new System.Drawing.Size(144, 35);
            this.btnGetPorts.TabIndex = 0;
            this.btnGetPorts.Text = "Ports";
            this.btnGetPorts.UseVisualStyleBackColor = true;
            this.btnGetPorts.Click += new System.EventHandler(this.btnGetPorts_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.CausesValidation = false;
            this.btnConnect.Location = new System.Drawing.Point(18, 105);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(144, 35);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ddlPorts
            // 
            this.ddlPorts.FormattingEnabled = true;
            this.ddlPorts.Location = new System.Drawing.Point(18, 63);
            this.ddlPorts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ddlPorts.Name = "ddlPorts";
            this.ddlPorts.Size = new System.Drawing.Size(142, 28);
            this.ddlPorts.TabIndex = 3;
            // 
            // lblx
            // 
            this.lblx.AutoSize = true;
            this.lblx.Location = new System.Drawing.Point(14, 265);
            this.lblx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblx.Name = "lblx";
            this.lblx.Size = new System.Drawing.Size(37, 20);
            this.lblx.TabIndex = 4;
            this.lblx.Text = "X = ";
            // 
            // lbly
            // 
            this.lbly.AutoSize = true;
            this.lbly.Location = new System.Drawing.Point(14, 305);
            this.lbly.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbly.Name = "lbly";
            this.lbly.Size = new System.Drawing.Size(37, 20);
            this.lbly.TabIndex = 5;
            this.lbly.Text = "Y = ";
            // 
            // lblz
            // 
            this.lblz.AutoSize = true;
            this.lblz.Location = new System.Drawing.Point(14, 345);
            this.lblz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblz.Name = "lblz";
            this.lblz.Size = new System.Drawing.Size(36, 20);
            this.lblz.TabIndex = 6;
            this.lblz.Text = "Z = ";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(48, 260);
            this.txtX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(112, 26);
            this.txtX.TabIndex = 7;
            this.txtX.Text = "400";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(48, 300);
            this.txtY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(112, 26);
            this.txtY.TabIndex = 8;
            this.txtY.Text = "200";
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(48, 340);
            this.txtZ.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(112, 26);
            this.txtZ.TabIndex = 9;
            this.txtZ.Text = "0";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(18, 378);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(144, 35);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(18, 145);
            this.lblDebug.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 20);
            this.lblDebug.TabIndex = 11;
            // 
            // btnOpenGrid
            // 
            this.btnOpenGrid.Location = new System.Drawing.Point(18, 158);
            this.btnOpenGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenGrid.Name = "btnOpenGrid";
            this.btnOpenGrid.Size = new System.Drawing.Size(144, 35);
            this.btnOpenGrid.TabIndex = 12;
            this.btnOpenGrid.Text = "Mouse Control";
            this.btnOpenGrid.UseVisualStyleBackColor = true;
            this.btnOpenGrid.Click += new System.EventHandler(this.btnOpenGrid_Click);
            // 
            // btnOpenMonitor
            // 
            this.btnOpenMonitor.Location = new System.Drawing.Point(18, 205);
            this.btnOpenMonitor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpenMonitor.Name = "btnOpenMonitor";
            this.btnOpenMonitor.Size = new System.Drawing.Size(144, 35);
            this.btnOpenMonitor.TabIndex = 13;
            this.btnOpenMonitor.Text = "Serial Monitor";
            this.btnOpenMonitor.UseVisualStyleBackColor = true;
            this.btnOpenMonitor.Click += new System.EventHandler(this.btnOpenMonitor_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(18, 248);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 3);
            this.label1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(18, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 3);
            this.label2.TabIndex = 15;
            // 
            // readBitmapButton
            // 
            this.readBitmapButton.Location = new System.Drawing.Point(18, 482);
            this.readBitmapButton.Name = "readBitmapButton";
            this.readBitmapButton.Size = new System.Drawing.Size(144, 35);
            this.readBitmapButton.TabIndex = 18;
            this.readBitmapButton.Text = "Browse for BMP";
            this.readBitmapButton.UseVisualStyleBackColor = true;
            this.readBitmapButton.Click += new System.EventHandler(this.readBitmapButton_Click);
            // 
            // btnSendBitmap
            // 
            this.btnSendBitmap.Enabled = false;
            this.btnSendBitmap.Location = new System.Drawing.Point(18, 525);
            this.btnSendBitmap.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSendBitmap.Name = "btnSendBitmap";
            this.btnSendBitmap.Size = new System.Drawing.Size(144, 35);
            this.btnSendBitmap.TabIndex = 19;
            this.btnSendBitmap.Text = "Send Bitmap";
            this.btnSendBitmap.UseVisualStyleBackColor = true;
            this.btnSendBitmap.Click += new System.EventHandler(this.btnSendBitmap_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Location = new System.Drawing.Point(18, 422);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 3);
            this.label3.TabIndex = 20;
            // 
            // sendProgBar
            // 
            this.sendProgBar.Location = new System.Drawing.Point(18, 570);
            this.sendProgBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendProgBar.Name = "sendProgBar";
            this.sendProgBar.Size = new System.Drawing.Size(144, 35);
            this.sendProgBar.TabIndex = 21;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 20);
            this.label4.TabIndex = 22;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 612);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sendProgBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSendBitmap);
            this.Controls.Add(this.readBitmapButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOpenMonitor);
            this.Controls.Add(this.btnOpenGrid);
            this.Controls.Add(this.lblDebug);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtZ);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.lblz);
            this.Controls.Add(this.lbly);
            this.Controls.Add(this.lblx);
            this.Controls.Add(this.ddlPorts);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnGetPorts);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(190, 741);
            this.MinimumSize = new System.Drawing.Size(190, 541);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPorts;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ComboBox ddlPorts;
        private System.Windows.Forms.Label lblx;
        private System.Windows.Forms.Label lbly;
        private System.Windows.Forms.Label lblz;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtZ;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblDebug;
        public System.IO.Ports.SerialPort panPort;
        private System.Windows.Forms.Button btnOpenGrid;
        private System.Windows.Forms.Button btnOpenMonitor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button readBitmapButton;
        private System.Windows.Forms.Button btnSendBitmap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar sendProgBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

