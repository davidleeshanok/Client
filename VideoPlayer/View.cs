using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;


namespace VideoPlayer
{
    public partial class View : Form
    {
 
        Controller _controller;

        // This delegate enables asynchronous calls for setting
        // the text property on a InfoBox control.
        delegate void SetInfoCallback(string info);
        delegate void SetCommCallback(string request);

        // This delegate enables asynchronous calls for setting the timer
        public delegate void TimerDelegate();
        
        string VideoFileName = "video1.mjpeg";

        public View()
        {
            InitializeComponent();
            _controller = new Controller();
            this.Connect_btn.Click += new System.EventHandler(_controller.Connect_btn_Click);
            this.Setup_btn.Click += new System.EventHandler(_controller.Setup_btn_Click); 
            this.Play_btn.Click += new System.EventHandler(_controller.Play_btn_Click);
            this.Pause_btn.Click += new System.EventHandler(_controller.Pause_btn_Click);
            this.Teardown_btn.Click += new System.EventHandler(_controller.Teardown_btn_Click);
            this.Timer.Tick += new System.EventHandler(_controller.Time_Handler);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(_controller.my_View_FormClosing);
            this.Exit_btn.Click += new System.EventHandler(Exit_btn_Click);
        }

        public void SetInfoBox(String _msg)
        {
            string text = _msg;
            SetInfoCallback d = new SetInfoCallback(add_text);
            this.Invoke(d, new object[] { text });
        }

        public void SetCommBox(String _msg)
        {
            string text = _msg;
            SetCommCallback d = new SetCommCallback(add_response);
            this.Invoke(d, new object[] { text });
        }

        public void add_text(String _msg)
        {
            this.InfoBox.Text += _msg;
        }

        public void add_response(String _req)
        {
            this.resBox.Text += _req;
        }

        public void Disable_Movie_selection()
        {
            this.comboBox1.Enabled = false;
        }

        public void Enable_Movie_selection()
        {
           this.comboBox1.Enabled = true;
        }

        public void Enable_Play()
        {
            this.Play_btn.Enabled = true;
        }

        public void Disable_Play()
        {
            this.Play_btn.Enabled = false;
        }

        public void Enable_Pause()
        {
            this.Pause_btn.Enabled = true;
        }

        public void Disable_Pause()
        {
            this.Pause_btn.Enabled = false;
        }

        public void Enable_Teardown()
        {
            this.Teardown_btn.Enabled = true;
        }
        public void Disable_Teardown()
        {
            this.Teardown_btn.Enabled = false;
        }
        public void Enable_Setup()
        {
            this.Setup_btn.Enabled = true;
        }

        public void Disable_Setup()
        {
            this.Setup_btn.Enabled = false;
        }

        public void Disable_Connect()
        {
            this.Connect_btn.Enabled = false;
        }

        public void Show_Player()
        {
            this.player.Visible = true;
        }

        public void Update_Screen(Image img)
        {
            this.Frame.Image = img;
        }

        public void Start_Timer()
        {
            this.Timer.Start();
        }

        public void Stop_Timer()
        {
            this.Timer.Stop();
        }

        public void StartTimer()
        {
            TimerDelegate d = new TimerDelegate(Start_Timer);
            this.Invoke(d);
        }

        public void StopTimer()
        {
            TimerDelegate d = new TimerDelegate(Stop_Timer);
            this.Invoke(d);
        }

        public String GetServerIP()
        {
            return this.ServerIP.Text.ToString();
        }

        public int GetServerPort()
        {
            return Int32.Parse(this.ServerPort.Text);
        }

        public string _VideoName
        {
            get { return VideoFileName; }
            set { VideoFileName = value; }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            VideoFileName = comboBox1.SelectedItem.ToString();

        }

        public bool DisplayReport
        {
            get { return this.packetReport.Checked; }
            set { this.packetReport.Checked = value; }
        }

        public bool DisplayHeader
        {
            get { return this.printHeader.Checked; }
            set { this.printHeader.Checked = value; }
        }

        public bool RTSPTesting
        {
            get { return this.rtspTest.Checked; }
            set { this.rtspTest.Checked = value; }
        }

        public void Exit_btn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
