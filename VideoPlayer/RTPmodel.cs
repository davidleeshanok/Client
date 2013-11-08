using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace VideoPlayer
{
    class RTPmodel
    {
        
        Socket RTPsocket; //UDP socket to be used to send and receive UDP packets

        public RTPmodel(IPAddress IP, int port)
        {
            //Create UDP socket  
            RTPsocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Creating client Endpoint and bound to UDP socket 
            RTPsocket.Bind(new IPEndPoint(IP, port));
        }

        /// Returns a UDP datagram that was sent by a remote host.
        public byte[] Receive(EndPoint EP)
        {
            byte[] data_in = new byte[62028];

            RTPsocket.ReceiveTimeout = 1000;
            try
            {
                //try to receive message
                RTPsocket.ReceiveFrom(data_in, ref EP);
            }
            catch 
            {
                data_in = null;
            }
            return data_in;
        }


        public void close()
        {
            try
            {
                RTPsocket.Close();
            }
            catch (Exception e)
            {
                //  throw new Exception(e.Message);
            }

        }


    }
}
