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
            this.SuspendLayout();
            // 
            // panPort
            // 
            this.panPort.BaudRate = 256000;
            // 
            // btnGetPorts
            // 
            this.btnGetPorts.Location = new System.Drawing.Point(12, 12);
            this.btnGetPorts.Name = "btnGetPorts";
            this.btnGetPorts.Size = new System.Drawing.Size(96, 23);
            this.btnGetPorts.TabIndex = 0;
            this.btnGetPorts.Text = "Ports";
            this.btnGetPorts.UseVisualStyleBackColor = true;
            this.btnGetPorts.Click += new System.EventHandler(this.btnGetPorts_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.CausesValidation = false;
            this.btnConnect.Location = new System.Drawing.Point(12, 68);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(96, 23);
            this.btnConnect.TabIndex = 2;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // ddlPorts
            // 
            this.ddlPorts.FormattingEnabled = true;
            this.ddlPorts.Location = new System.Drawing.Point(12, 41);
            this.ddlPorts.Name = "ddlPorts";
            this.ddlPorts.Size = new System.Drawing.Size(96, 21);
            this.ddlPorts.TabIndex = 3;
            // 
            // lblx
            // 
            this.lblx.AutoSize = true;
            this.lblx.Location = new System.Drawing.Point(9, 172);
            this.lblx.Name = "lblx";
            this.lblx.Size = new System.Drawing.Size(26, 13);
            this.lblx.TabIndex = 4;
            this.lblx.Text = "X = ";
            // 
            // lbly
            // 
            this.lbly.AutoSize = true;
            this.lbly.Location = new System.Drawing.Point(9, 198);
            this.lbly.Name = "lbly";
            this.lbly.Size = new System.Drawing.Size(26, 13);
            this.lbly.TabIndex = 5;
            this.lbly.Text = "Y = ";
            // 
            // lblz
            // 
            this.lblz.AutoSize = true;
            this.lblz.Location = new System.Drawing.Point(9, 224);
            this.lblz.Name = "lblz";
            this.lblz.Size = new System.Drawing.Size(26, 13);
            this.lblz.TabIndex = 6;
            this.lblz.Text = "Z = ";
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(32, 169);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(76, 20);
            this.txtX.TabIndex = 7;
            this.txtX.Text = "400";
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(32, 195);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(76, 20);
            this.txtY.TabIndex = 8;
            this.txtY.Text = "200";
            // 
            // txtZ
            // 
            this.txtZ.Location = new System.Drawing.Point(32, 221);
            this.txtZ.Name = "txtZ";
            this.txtZ.Size = new System.Drawing.Size(76, 20);
            this.txtZ.TabIndex = 9;
            this.txtZ.Text = "0";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(12, 246);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(96, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // lblDebug
            // 
            this.lblDebug.AutoSize = true;
            this.lblDebug.Location = new System.Drawing.Point(12, 94);
            this.lblDebug.Name = "lblDebug";
            this.lblDebug.Size = new System.Drawing.Size(0, 13);
            this.lblDebug.TabIndex = 11;
            // 
            // btnOpenGrid
            // 
            this.btnOpenGrid.Location = new System.Drawing.Point(12, 103);
            this.btnOpenGrid.Name = "btnOpenGrid";
            this.btnOpenGrid.Size = new System.Drawing.Size(96, 23);
            this.btnOpenGrid.TabIndex = 12;
            this.btnOpenGrid.Text = "Mouse Control";
            this.btnOpenGrid.UseVisualStyleBackColor = true;
            this.btnOpenGrid.Click += new System.EventHandler(this.btnOpenGrid_Click);
            // 
            // btnOpenMonitor
            // 
            this.btnOpenMonitor.Location = new System.Drawing.Point(12, 133);
            this.btnOpenMonitor.Name = "btnOpenMonitor";
            this.btnOpenMonitor.Size = new System.Drawing.Size(96, 23);
            this.btnOpenMonitor.TabIndex = 13;
            this.btnOpenMonitor.Text = "Serial Monitor";
            this.btnOpenMonitor.UseVisualStyleBackColor = true;
            this.btnOpenMonitor.Click += new System.EventHandler(this.btnOpenMonitor_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 2);
            this.label1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 2);
            this.label2.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 281);
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
            this.MaximumSize = new System.Drawing.Size(136, 320);
            this.MinimumSize = new System.Drawing.Size(136, 320);
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
    }
}

