﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;

namespace VideoPlayer
{
    class Controller
    {

        private static View _view;
        bool Connected = false;
        bool Setuped = false;
        RTSPmodel _RTSPmodel = null;
        RTPmodel _RTPmodel = null;
        string ServerIP = null;
        int ServerPort = 0;

        string statusLine = null;
        string CSeqLine = null;
        string sessionLine = null;

        string session;
        string response;
        int state = -1; //RTSP state == INIT or READY or PLAYING
        string VideoFileName; //video file to request to the server
        int RTSPSeqNb; //Sequence number of RTSP messages within the session
        int RTP_PORT; // = 25000; //port where the client will receive the RTP packets
        EndPoint ServerEP;




        public void Connect_btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Deterime which view to control
                _view = (View)((Button)sender).FindForm();

                // Create a model to connect to the server
                ServerIP = _view.GetServerIP();
                ServerPort = _view.GetServerPort();
                _RTSPmodel = new RTSPmodel(ServerIP, ServerPort);
            }
            catch (Exception ex)
            {
                PushToInfoBox("Make sure the server is up and listening\r\n and the server IP address and port number are correct");
            }

            Connected = true;
            //init RTSP state:
            state = 0; //INIT

            _view.Show_Player();
            _view.Disable_Connect();

            Random random = new Random();
            session = random.Next(4000, 9000).ToString();
        }



        //Handler for Setup button
        //-----------------------
        public void Setup_btn_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            RTP_PORT = (int)random.Next(1050, 9000);

            VideoFileName = _view._VideoName;
            PushToInfoBox(VideoFileName + " \r\n");

            if (state == 0 /*INIT*/)
            {
                //init RTSP sequence number
                RTSPSeqNb = 1;

                //Send SETUP message to the server
                _RTSPmodel.RTSPSend(Form_command("SETUP"));

                //Wait for the response 
                if (parse_server_response() != 200)
                    PushToInfoBox("Invalid Server Response \r\n");
                else
                {
                    state = 1; /* READY */

                    _view.Enable_Play();
                    _view.Disable_Pause();
                    _view.Disable_Setup();
                    _view.Disable_Movie_selection();

                    PushToCommBox(response + "\r\n");

                    if (!_view.RTSPTesting)
                    {
                        //Init non-blocking RTPsocket that will be used to receive data
                        try
                        {
                            //construct a new DatagramSocket to receive RTP packets from the server, on port RTP_PORT
                            //RTPsocket = ...

                            
                            _RTPmodel = new RTPmodel(_RTSPmodel.GetClientIP(), RTP_PORT);

                            IPEndPoint IPRemoteEP = new IPEndPoint(IPAddress.Any, 0);
                            ServerEP = (EndPoint)IPRemoteEP;
                        }
                        catch (SocketException se)
                        {
                            throw new Exception("Socket exception: " + se);
                        }
                    }
                }
            }
            Setuped = true;
        }

        public void Play_btn_Click(object sender, EventArgs e)
        {
            //increase RTSP sequence number
            RTSPSeqNb++;

            //Send PLAY message to the server            
            _RTSPmodel.RTSPSend(Form_command("PLAY"));

            //Wait for the response 
            if (parse_server_response() != 200)
                PushToInfoBox("Invalid Server Response \r\n");
            else
            {
                state = 2; /*PLAYING*/

                _view.Disable_Play();
                _view.Enable_Pause();
                _view.Enable_Teardown();

                PushToCommBox(response + "\r\n" );

                if (!_view.RTSPTesting)
                {
                    //start the timer
                    _view.Start_Timer();
                }
            }
        }

        public void Pause_btn_Click(object sender, EventArgs e)
        {
            //increase RTSP sequence number
            RTSPSeqNb++;

            //Send PAUSE message to the server
            _RTSPmodel.RTSPSend(Form_command("PAUSE"));

            //Wait for the response 
            if (parse_server_response() != 200)
                PushToInfoBox("Invalid Server Response \r\n");
            else
            {
                state = 1; /* READY */

                _view.Enable_Play();
                _view.Disable_Pause();
                _view.Enable_Teardown();

                PushToCommBox(response + "\r\n");
                if (!_view.RTSPTesting)
                {
                    //stop the timer
                    _view.Stop_Timer();
                }
            }
        }

        public void Teardown_btn_Click(object sender, EventArgs e)
        {
            //increase RTSP sequence number
            RTSPSeqNb++;

            //Send TEARDOWN message to the server
            _RTSPmodel.RTSPSend(Form_command("TEARDOWN"));

            //Wait for the response 
            if (parse_server_response() != 200)
                PushToInfoBox("Invalid Server Response \r\n");
            else
            {
                state = 0; //INIT

                _view.Disable_Play();
                _view.Disable_Pause();
                _view.Disable_Teardown();
                _view.Enable_Setup();
                _view.Enable_Movie_selection();

                PushToCommBox(response  + "\r\n");

                if (!_view.RTSPTesting)
                {
                    //stop the timer
                    _view.Stop_Timer();

                    //close sockets
                    _RTPmodel.close();
                }
     
                //reset RTSP sequence number
                RTSPSeqNb = 0;


            }

        }

        public void my_View_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Setuped)
            {
                //Send TEARDOWN message to the server
             //   _RTSPmodel.RTSPSend(Form_command("TEARDOWN"));
                _RTSPmodel.shutdown();
            }
        }

        public void PushToInfoBox(string msg)
        {
            _view.SetInfoBox(msg);
        }

        public void PushToCommBox(string msg)
        {
            _view.SetCommBox(msg);
        }

        //------------------------------------
        //Handler for timer
        //------------------------------------
        public void Time_Handler(object sender, EventArgs e)
        {
            //Construct a DatagramPacket to receive data from the UDP socket
            byte[] rcvdp = null;

            //receive the DP from the socket:
            rcvdp = _RTPmodel.Receive(ServerEP);
            if (rcvdp != null)
            {
                //Extract RTP packet from the UDP packet
                RTPpacket rtp_packet = new RTPpacket(rcvdp, rcvdp.Length);


                //get an Image object from the payload bitstream
                _view.Update_Screen(rtp_packet.GetPayloadAsImage());
                
                //print the header bitstream
                if (_view.DisplayHeader)
                    PushToInfoBox(rtp_packet.printheader() + "\r\n");

                //print important header fields of the RTP packet received: 
                if (_view.DisplayReport)
                    PushToInfoBox("Got RTP packet with SeqNum # "
                        + rtp_packet.getsequencenumber()
                        + " TimeStamp " + rtp_packet.gettimestamp() + " ms, of type "
                        + rtp_packet.getpayloadtype() + " \r\n");
            }
            else
            {
                state = 0; //INIT

                _view.Disable_Play();
                _view.Disable_Pause();
                _view.Disable_Teardown();
                _view.Enable_Setup();
                _view.Enable_Movie_selection();


                //stop the timer
                _view.Stop_Timer();

                //reset RTSP sequence number
                // ..........

                RTSPSeqNb = 0;


                //close sockets
                _RTPmodel.close();
            }

        }

        //------------------------------------
        //Parse Server Response
        //------------------------------------
        private int parse_server_response()
        {
            // Response ::= Status-Line <CRLF> CSeq-line <CRLF> Session-line <CRLF>
            //      Status-Line ::= RTSP-Version <SPACE> Status-Code <SPACE> Reason-Phrase 
            //          RTSP-Version ::=  "RTSP/1.0" 
            //          Status-Code ::= "100"      ; Continue
            //                        | "200"      ; OK
            //                        | "400"      ; Bad Request
            //          Reason-Phrase ::= *<TEXT, excluding CRLF>
            //      CSeq-line ::= "CSeq:" <SPACE> RTSP-Sequence-No
            //      Session-line ::= "Session:" <SPACE> Session-ID
            //
            // For examle: 
            //      RTSP/1.0 200 OK
            //      CSeq: 2
            //      Session: 123456



            int reply_code = 0;
            try
            {
                string receivedData = _RTSPmodel.RTSPReceive(); // block until server sends message

                 StringReader msg = new StringReader(receivedData);
                 StringWriter command = new StringWriter();
                // Now, read from StringReader.      
          
                // read response line
                 statusLine = msg.ReadLine();
                 command.WriteLine(statusLine);

                string ss = statusLine.Substring(statusLine.IndexOf(" ")+1);
                reply_code = Int32.Parse(ss.Substring(0,ss.LastIndexOf(" ")));

                //if reply code is OK get and print the 2 other lines
                if (reply_code == 200)
                {
                    // read sequence line
                    CSeqLine = msg.ReadLine();
                    command.WriteLine(CSeqLine);
                    // read session line
                    sessionLine = msg.ReadLine();
                    command.WriteLine(sessionLine);

                    session = sessionLine.Substring(sessionLine.IndexOf(" "));
                    response = command.ToString();

                }
            }
            catch (System.Exception ex)
            {
                throw new Exception("Exception caught: " + ex);
            }

            return (reply_code);
        }

        private string Form_command(string Method)
        {
            // command ::= Request-Line <CRLF> CSeq-line <CRLF> (Transport-line | Session-line) <CRLF>
            //      Request-Line ::= Method <SPACE> Request-URI <SPACE> RTSP-Version CRLF
            //          Method ::=  "SETUP" | "PLAY" | "PAUSE" | "TEARDOWN" 
            //          Request-URI ::= "rtsp://" SERVER_Host ":" RTP_PORT "/" MEDIA_FILENAME  
            //          RTSP-Version ::= "RTSP/1.0"
            //      CSeq-line ::= "CSeq:" <SPACE> RTSP-Sequence-No
            //      Transport-line ::= "Transport: RTP/UDP; client_port=" Port to receive the RTP packets
            //      Session-line ::= "Session:" <SPACE> Session-ID
            //
            // For examle: 
            //      SETUP video1.mjpeg RTSP/1.0
            //      CSeq: 1
            //      Transport: RTP/UDP; client_port= 25000
            //
            //      PLAY video1.mjpeg RTSP/1.0
            //      CSeq: 2
            //      Session: 123456

           StringWriter command = new StringWriter();

           // Add Method and a space
           command.Write(Method + " ");

           // Add Request_URI and a space
           command.Write("rtsp://" + ServerIP + ":" + ServerPort.ToString() + "/" + VideoFileName + " ");

           // Add RTSP-Version with CRLF
            command.WriteLine ("RTSP/1.0");

            //write the CSeq line with CRLF 
            command.WriteLine("CSeq: " + RTSPSeqNb.ToString());

            // if Method is equal to "SETUP" we write Transport line 
            // otherwise we write Session line
            if (Method == "SETUP")
                command.WriteLine("Transport: RTP/UDP; client_port= " + RTP_PORT.ToString());
            else
                command.WriteLine("Session: " + session);

            return (command.ToString());          
        }
    }
}
