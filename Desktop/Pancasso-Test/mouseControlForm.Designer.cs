namespace Pancasso_Test
{
    partial class mouseControlForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbOverlay = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblCPX = new System.Windows.Forms.Label();
            this.lblCPY = new System.Windows.Forms.Label();
            this.lblCPZ = new System.Windows.Forms.Label();
            this.lblLSZ = new System.Windows.Forms.Label();
            this.lblLSY = new System.Windows.Forms.Label();
            this.lblLSX = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblSending = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOverlay)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pbOverlay);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 400);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pbOverlay
            // 
            this.pbOverlay.BackColor = System.Drawing.Color.Transparent;
            this.pbOverlay.Location = new System.Drawing.Point(0, 0);
            this.pbOverlay.Name = "pbOverlay";
            this.pbOverlay.Size = new System.Drawing.Size(800, 400);
            this.pbOverlay.TabIndex = 20;
            this.pbOverlay.TabStop = false;
            this.pbOverlay.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlOverlay_Paint);
            this.pbOverlay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbOverlay_MouseClick);
            this.pbOverlay.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbOverlay_MouseDown);
            this.pbOverlay.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlOverlay_MouseMove);
            this.pbOverlay.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbOverlay_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "--------------- Cursor Position ---------------";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(161, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "X =";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(224, 425);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Y =";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(286, 425);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Z =";
            // 
            // lblCPX
            // 
            this.lblCPX.AutoSize = true;
            this.lblCPX.Location = new System.Drawing.Point(183, 425);
            this.lblCPX.Name = "lblCPX";
            this.lblCPX.Size = new System.Drawing.Size(25, 13);
            this.lblCPX.TabIndex = 5;
            this.lblCPX.Text = "000";
            // 
            // lblCPY
            // 
            this.lblCPY.AutoSize = true;
            this.lblCPY.Location = new System.Drawing.Point(245, 425);
            this.lblCPY.Name = "lblCPY";
            this.lblCPY.Size = new System.Drawing.Size(25, 13);
            this.lblCPY.TabIndex = 9;
            this.lblCPY.Text = "000";
            // 
            // lblCPZ
            // 
            this.lblCPZ.AutoSize = true;
            this.lblCPZ.Location = new System.Drawing.Point(307, 425);
            this.lblCPZ.Name = "lblCPZ";
            this.lblCPZ.Size = new System.Drawing.Size(25, 13);
            this.lblCPZ.TabIndex = 10;
            this.lblCPZ.Text = "000";
            // 
            // lblLSZ
            // 
            this.lblLSZ.AutoSize = true;
            this.lblLSZ.Location = new System.Drawing.Point(609, 425);
            this.lblLSZ.Name = "lblLSZ";
            this.lblLSZ.Size = new System.Drawing.Size(25, 13);
            this.lblLSZ.TabIndex = 17;
            this.lblLSZ.Text = "000";
            // 
            // lblLSY
            // 
            this.lblLSY.AutoSize = true;
            this.lblLSY.Location = new System.Drawing.Point(547, 425);
            this.lblLSY.Name = "lblLSY";
            this.lblLSY.Size = new System.Drawing.Size(25, 13);
            this.lblLSY.TabIndex = 16;
            this.lblLSY.Text = "000";
            // 
            // lblLSX
            // 
            this.lblLSX.AutoSize = true;
            this.lblLSX.Location = new System.Drawing.Point(484, 425);
            this.lblLSX.Name = "lblLSX";
            this.lblLSX.Size = new System.Drawing.Size(25, 13);
            this.lblLSX.TabIndex = 15;
            this.lblLSX.Text = "000";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(588, 425);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 13);
            this.label11.TabIndex = 14;
            this.label11.Text = "Z =";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(526, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 13);
            this.label12.TabIndex = 13;
            this.label12.Text = "Y =";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(462, 425);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 13);
            this.label13.TabIndex = 12;
            this.label13.Text = "X =";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(462, 403);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(170, 13);
            this.label14.TabIndex = 11;
            this.label14.Text = "------------ Last Sent Position ------------";
            // 
            // lblSending
            // 
            this.lblSending.AutoSize = true;
            this.lblSending.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSending.ForeColor = System.Drawing.Color.Green;
            this.lblSending.Location = new System.Drawing.Point(347, 403);
            this.lblSending.Name = "lblSending";
            this.lblSending.Size = new System.Drawing.Size(106, 25);
            this.lblSending.TabIndex = 18;
            this.lblSending.Text = "SENDING";
            this.lblSending.Visible = false;
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(356, 425);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(87, 25);
            this.lblError.TabIndex = 19;
            this.lblError.Text = "ERROR";
            this.lblError.Visible = false;
            // 
            // mouseControlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 461);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSending);
            this.Controls.Add(this.lblLSZ);
            this.Controls.Add(this.lblLSY);
            this.Controls.Add(this.lblLSX);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.lblCPZ);
            this.Controls.Add(this.lblCPY);
            this.Controls.Add(this.lblCPX);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "mouseControlForm";
            this.Text = "mouseControlForm";
            this.Load += new System.EventHandler(this.mouseControlForm_Load);
            this.Shown += new System.EventHandler(this.mouseControlForm_Shown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseControlForm_MouseMove);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbOverlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblCPX;
        private System.Windows.Forms.Label lblCPY;
        private System.Windows.Forms.Label lblCPZ;
        private System.Windows.Forms.Label lblLSZ;
        private System.Windows.Forms.Label lblLSY;
        private System.Windows.Forms.Label lblLSX;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblSending;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.PictureBox pbOverlay;

    }
}