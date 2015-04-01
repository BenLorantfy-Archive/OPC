namespace OPC
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
        /// the contents of this method with the code editor. (I just did - #shrekt)
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblConnect = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpSimulation = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numMaxTemp = new System.Windows.Forms.NumericUpDown();
            this.lblMidTemp = new System.Windows.Forms.Label();
            this.termometer1 = new Termometer();
            this.sliderLabel = new System.Windows.Forms.Label();
            this.cookLevelBar = new System.Windows.Forms.TrackBar();
            this.btnOff = new System.Windows.Forms.Button();
            this.btnOn = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.grpSimulation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cookLevelBar)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAddress);
            this.groupBox1.Controls.Add(this.lblConnect);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(477, 86);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OPC";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(20, 20);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(235, 20);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Text = "opcda://localhost/Kepware.KEPServerEX.V5";
            // 
            // lblConnect
            // 
            this.lblConnect.AutoSize = true;
            this.lblConnect.Location = new System.Drawing.Point(182, 51);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(73, 13);
            this.lblConnect.TabIndex = 2;
            this.lblConnect.Text = "Disconnected";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(101, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Disconnect";
            this.toolTip1.SetToolTip(this.button2, "Disconnect from the connected server.");
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(20, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.toolTip1.SetToolTip(this.button1, "Connect to KEPServerEX V5");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpSimulation
            // 
            this.grpSimulation.Controls.Add(this.label1);
            this.grpSimulation.Controls.Add(this.numMaxTemp);
            this.grpSimulation.Controls.Add(this.lblMidTemp);
            this.grpSimulation.Controls.Add(this.termometer1);
            this.grpSimulation.Controls.Add(this.sliderLabel);
            this.grpSimulation.Controls.Add(this.cookLevelBar);
            this.grpSimulation.Controls.Add(this.btnOff);
            this.grpSimulation.Controls.Add(this.btnOn);
            this.grpSimulation.Location = new System.Drawing.Point(12, 105);
            this.grpSimulation.Name = "grpSimulation";
            this.grpSimulation.Size = new System.Drawing.Size(477, 216);
            this.grpSimulation.TabIndex = 2;
            this.grpSimulation.TabStop = false;
            this.grpSimulation.Text = "Simulation";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "0";
            // 
            // numMaxTemp
            // 
            this.numMaxTemp.Location = new System.Drawing.Point(418, 12);
            this.numMaxTemp.Name = "numMaxTemp";
            this.numMaxTemp.Size = new System.Drawing.Size(40, 20);
            this.numMaxTemp.TabIndex = 14;
            this.numMaxTemp.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            this.numMaxTemp.ValueChanged += new System.EventHandler(this.numMaxTemp_ValueChanged);
            // 
            // lblMidTemp
            // 
            this.lblMidTemp.AutoSize = true;
            this.lblMidTemp.Location = new System.Drawing.Point(226, 16);
            this.lblMidTemp.Name = "lblMidTemp";
            this.lblMidTemp.Size = new System.Drawing.Size(13, 13);
            this.lblMidTemp.TabIndex = 13;
            this.lblMidTemp.Text = "0";
            // 
            // termometer1
            // 
            this.termometer1.Location = new System.Drawing.Point(20, 38);
            this.termometer1.Maximum = 45;
            this.termometer1.Name = "termometer1";
            this.termometer1.Size = new System.Drawing.Size(438, 43);
            this.termometer1.TabIndex = 12;
            // 
            // sliderLabel
            // 
            this.sliderLabel.AutoSize = true;
            this.sliderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sliderLabel.Location = new System.Drawing.Point(300, 123);
            this.sliderLabel.Name = "sliderLabel";
            this.sliderLabel.Size = new System.Drawing.Size(109, 18);
            this.sliderLabel.TabIndex = 11;
            this.sliderLabel.Text = "Set Cook Level";
            // 
            // cookLevelBar
            // 
            this.cookLevelBar.Location = new System.Drawing.Point(245, 152);
            this.cookLevelBar.Maximum = 6;
            this.cookLevelBar.Minimum = 1;
            this.cookLevelBar.Name = "cookLevelBar";
            this.cookLevelBar.Size = new System.Drawing.Size(213, 45);
            this.cookLevelBar.TabIndex = 10;
            this.cookLevelBar.Value = 1;
            this.cookLevelBar.Scroll += new System.EventHandler(this.cookLevelBar_Scroll);
            // 
            // btnOff
            // 
            this.btnOff.Location = new System.Drawing.Point(20, 152);
            this.btnOff.Name = "btnOff";
            this.btnOff.Size = new System.Drawing.Size(219, 46);
            this.btnOff.TabIndex = 9;
            this.btnOff.Text = "Off";
            this.btnOff.UseVisualStyleBackColor = true;
            this.btnOff.Click += new System.EventHandler(this.btnOff_Click);
            // 
            // btnOn
            // 
            this.btnOn.Location = new System.Drawing.Point(20, 95);
            this.btnOn.Name = "btnOn";
            this.btnOn.Size = new System.Drawing.Size(219, 46);
            this.btnOn.TabIndex = 8;
            this.btnOn.Text = "On";
            this.btnOn.UseVisualStyleBackColor = true;
            this.btnOn.Click += new System.EventHandler(this.btnOn_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 333);
            this.Controls.Add(this.grpSimulation);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Sensor Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpSimulation.ResumeLayout(false);
            this.grpSimulation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxTemp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cookLevelBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox grpSimulation;
        private System.Windows.Forms.Label lblConnect;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label sliderLabel;
        private System.Windows.Forms.TrackBar cookLevelBar;
        private System.Windows.Forms.Button btnOff;
        private System.Windows.Forms.Button btnOn;
        private Termometer termometer1;
        private System.Windows.Forms.Label lblMidTemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMaxTemp;

    }
}

