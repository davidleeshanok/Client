namespace VideoPlayer
{
    partial class View
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.Connect_btn = new System.Windows.Forms.Button();
            this.Exit_btn = new System.Windows.Forms.Button();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ServerPort = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.player = new System.Windows.Forms.Panel();
            this.Frame = new System.Windows.Forms.PictureBox();
            this.Teardown_btn = new System.Windows.Forms.Button();
            this.Pause_btn = new System.Windows.Forms.Button();
            this.Play_btn = new System.Windows.Forms.Button();
            this.Setup_btn = new System.Windows.Forms.Button();
            this.InfoBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.printHeader = new System.Windows.Forms.CheckBox();
            this.packetReport = new System.Windows.Forms.CheckBox();
            this.resBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtspTest = new System.Windows.Forms.CheckBox();
            this.player.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).BeginInit();
            this.SuspendLayout();
            // 
            // Connect_btn
            // 
            this.Connect_btn.Location = new System.Drawing.Point(462, 658);
            this.Connect_btn.Name = "Connect_btn";
            this.Connect_btn.Size = new System.Drawing.Size(72, 25);
            this.Connect_btn.TabIndex = 1;
            this.Connect_btn.Text = "Connect";
            this.Connect_btn.UseVisualStyleBackColor = true;
            // 
            // Exit_btn
            // 
            this.Exit_btn.Location = new System.Drawing.Point(462, 689);
            this.Exit_btn.Name = "Exit_btn";
            this.Exit_btn.Size = new System.Drawing.Size(72, 25);
            this.Exit_btn.TabIndex = 1;
            this.Exit_btn.Text = "Exit";
            this.Exit_btn.UseVisualStyleBackColor = true;
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.BackColor = System.Drawing.Color.Transparent;
            this.PortLabel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PortLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.PortLabel.Location = new System.Drawing.Point(16, 402);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(103, 16);
            this.PortLabel.TabIndex = 10;
            this.PortLabel.Text = "Connect to Port:";
            // 
            // ServerPort
            // 
            this.ServerPort.AcceptsReturn = true;
            this.ServerPort.Location = new System.Drawing.Point(117, 400);
            this.ServerPort.Name = "ServerPort";
            this.ServerPort.Size = new System.Drawing.Size(40, 20);
            this.ServerPort.TabIndex = 11;
            this.ServerPort.Text = "3000";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label32.Location = new System.Drawing.Point(163, 403);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(114, 16);
            this.label32.TabIndex = 10;
            this.label32.Text = "Server IP address:";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(279, 401);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(69, 20);
            this.ServerIP.TabIndex = 11;
            this.ServerIP.Text = "127.0.0.1";
            // 
            // Timer
            // 
            this.Timer.Interval = 80;
            // 
            // player
            // 
            this.player.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.player.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player.Controls.Add(this.Frame);
            this.player.Controls.Add(this.Teardown_btn);
            this.player.Controls.Add(this.Pause_btn);
            this.player.Controls.Add(this.Play_btn);
            this.player.Controls.Add(this.Setup_btn);
            this.player.Location = new System.Drawing.Point(13, 13);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(517, 374);
            this.player.TabIndex = 12;
            this.player.Visible = false;
            // 
            // Frame
            // 
            this.Frame.BackColor = System.Drawing.Color.Black;
            this.Frame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Frame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Frame.Enabled = false;
            this.Frame.Location = new System.Drawing.Point(4, 3);
            this.Frame.Name = "Frame";
            this.Frame.Size = new System.Drawing.Size(508, 286);
            this.Frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Frame.TabIndex = 2;
            this.Frame.TabStop = false;
            // 
            // Teardown_btn
            // 
            this.Teardown_btn.Enabled = false;
            this.Teardown_btn.Location = new System.Drawing.Point(421, 295);
            this.Teardown_btn.Name = "Teardown_btn";
            this.Teardown_btn.Size = new System.Drawing.Size(79, 75);
            this.Teardown_btn.TabIndex = 1;
            this.Teardown_btn.Text = "Teardown";
            this.Teardown_btn.UseVisualStyleBackColor = true;
            // 
            // Pause_btn
            // 
            this.Pause_btn.Enabled = false;
            this.Pause_btn.Location = new System.Drawing.Point(284, 295);
            this.Pause_btn.Name = "Pause_btn";
            this.Pause_btn.Size = new System.Drawing.Size(79, 75);
            this.Pause_btn.TabIndex = 1;
            this.Pause_btn.Text = "Pause";
            this.Pause_btn.UseVisualStyleBackColor = true;
            // 
            // Play_btn
            // 
            this.Play_btn.Enabled = false;
            this.Play_btn.Location = new System.Drawing.Point(146, 295);
            this.Play_btn.Name = "Play_btn";
            this.Play_btn.Size = new System.Drawing.Size(79, 75);
            this.Play_btn.TabIndex = 1;
            this.Play_btn.Text = "Play";
            this.Play_btn.UseVisualStyleBackColor = true;
            // 
            // Setup_btn
            // 
            this.Setup_btn.Location = new System.Drawing.Point(4, 295);
            this.Setup_btn.Name = "Setup_btn";
            this.Setup_btn.Size = new System.Drawing.Size(79, 75);
            this.Setup_btn.TabIndex = 1;
            this.Setup_btn.Text = "Setup";
            this.Setup_btn.UseVisualStyleBackColor = true;
            // 
            // InfoBox
            // 
            this.InfoBox.BackColor = System.Drawing.Color.White;
            this.InfoBox.Location = new System.Drawing.Point(13, 429);
            this.InfoBox.Multiline = true;
            this.InfoBox.Name = "InfoBox";
            this.InfoBox.ReadOnly = true;
            this.InfoBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.InfoBox.Size = new System.Drawing.Size(443, 126);
            this.InfoBox.TabIndex = 13;
            this.InfoBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(354, 403);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Video name:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox1.Items.AddRange(new object[] {
            "video1.mjpeg",
            "video2.mjpeg"});
            this.comboBox1.Location = new System.Drawing.Point(430, 402);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(95, 21);
            this.comboBox1.TabIndex = 15;
            this.comboBox1.Text = "video1.mjpeg";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // printHeader
            // 
            this.printHeader.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.printHeader.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.printHeader.Location = new System.Drawing.Point(469, 509);
            this.printHeader.Name = "printHeader";
            this.printHeader.Size = new System.Drawing.Size(72, 33);
            this.printHeader.TabIndex = 17;
            this.printHeader.Text = "Print RTP Header";
            this.printHeader.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.printHeader.UseVisualStyleBackColor = true;
            // 
            // packetReport
            // 
            this.packetReport.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.packetReport.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.packetReport.Location = new System.Drawing.Point(469, 455);
            this.packetReport.Name = "packetReport";
            this.packetReport.Size = new System.Drawing.Size(72, 33);
            this.packetReport.TabIndex = 16;
            this.packetReport.Text = "Packet Report";
            this.packetReport.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.packetReport.UseVisualStyleBackColor = true;
            // 
            // resBox
            // 
            this.resBox.BackColor = System.Drawing.Color.White;
            this.resBox.Location = new System.Drawing.Point(12, 586);
            this.resBox.Multiline = true;
            this.resBox.Name = "resBox";
            this.resBox.ReadOnly = true;
            this.resBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.resBox.Size = new System.Drawing.Size(443, 128);
            this.resBox.TabIndex = 18;
            this.resBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(16, 567);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "Server Responses:";
            // 
            // rtspTest
            // 
            this.rtspTest.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rtspTest.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rtspTest.Location = new System.Drawing.Point(469, 588);
            this.rtspTest.Name = "rtspTest";
            this.rtspTest.Size = new System.Drawing.Size(72, 33);
            this.rtspTest.TabIndex = 20;
            this.rtspTest.Text = "RTSP only";
            this.rtspTest.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.rtspTest.UseVisualStyleBackColor = true;
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 727);
            this.Controls.Add(this.rtspTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resBox);
            this.Controls.Add(this.printHeader);
            this.Controls.Add(this.packetReport);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.InfoBox);
            this.Controls.Add(this.player);
            this.Controls.Add(this.ServerIP);
            this.Controls.Add(this.ServerPort);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.Exit_btn);
            this.Controls.Add(this.Connect_btn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "View";
            this.Text = "SE4472a Video Player";
            this.player.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Frame)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connect_btn;
        private System.Windows.Forms.Button Exit_btn;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox ServerPort;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Panel player;
        private System.Windows.Forms.Button Teardown_btn;
        private System.Windows.Forms.Button Pause_btn;
        private System.Windows.Forms.Button Play_btn;
        private System.Windows.Forms.Button Setup_btn;
        private System.Windows.Forms.TextBox VideoName;
        private System.Windows.Forms.TextBox InfoBox;
        private System.Windows.Forms.PictureBox Frame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox printHeader;
        private System.Windows.Forms.CheckBox packetReport;
        private System.Windows.Forms.TextBox resBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox rtspTest;
    }
}

