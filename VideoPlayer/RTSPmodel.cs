using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace VideoPlayer
{
    class RTSPmodel
    {

        Socket RTSPsocket; //socket used to send/receive RTSP messages
        IPAddress ServerIPAddr = null;
        IPAddress ClientIPAddr = null;
        int RTSP_PORT;


        public RTSPmodel(string IP, int port)
        {

            //Create TCP socket to exchange RTSP messages with the server
            RTSPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // Creating Endpoint 
            ServerIPAddr = IPAddress.Parse(IP);
            RTSP_PORT = port;
            IPEndPoint RTSP_serverEndPoint = new IPEndPoint(ServerIPAddr, RTSP_PORT);

            // try to connect
            try
            {
                RTSPsocket.Connect(RTSP_serverEndPoint);
            }
            catch (Exception ex)
            {
                throw new Exception("Exception caught: " + ex);
            }

            ClientIPAddr = ((IPEndPoint)RTSPsocket.LocalEndPoint).Address;
        }

        public void RTSPSend(string data)
        {
            try
            {
                byte[] byteData = Encoding.ASCII.GetBytes(data);
                RTSPsocket.Send(byteData, 0, byteData.Length, SocketFlags.None);
            }
            catch (Exception e)
            {
                // throw new Exception("RTSPsocket.Send : " + e.Message);
            }
        }

        public string RTSPReceive()
        {
            {
                try
                {
                    byte[] buffer = new byte[2048];

                    int byteRecv = RTSPsocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    string receivedData = Encoding.ASCII.GetString(buffer, 0, byteRecv);

                    return receivedData;
                }
                catch (Exception e)
                {
                    // throw new Exception("RTSPReceive : " + e.Message);
                    return null;
                }
            }
        }
        public IPAddress GetClientIP()
        {
            return ClientIPAddr;
        }

        public void shutdown()
        {
            RTSPsocket.Close();
        }
    }
}
