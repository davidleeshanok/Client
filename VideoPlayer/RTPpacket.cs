using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace VideoPlayer
{
    class RTPpacket
    {
        
        //size of the RTP header:
        static int HEADER_SIZE = 12;
        static int HMAC_SIZE = 16;

        //Fields that compose the RTP header
        public int Version;
        public int Padding;
        public int Extension;
        public int CC;
        public int Marker;
        public int PayloadType;
        public int SequenceNumber;
        public int TimeStamp;
        public int Ssrc;

        //Bitstream of the RTP header
        public byte[] header;

        //size of the RTP payload
        public int payload_size;
        //Bitstream of the RTP payload
        public byte[] payload;

        //Bitstream of the RTP hmac
        public byte[] hmac;


        //--------------------------
        //Constructor of an RTPpacket object from the packet bistream 
        //--------------------------
        public RTPpacket(byte[] packet, int packet_size)
        {
            //fill default fields:
            Version = 2;
            Padding = 0;
            Extension = 0;
            CC = 0;
            Marker = 0;
            Ssrc = 0;

            //check if total packet size is lower than the header size
            if (packet_size >= HEADER_SIZE)
            {
                //get the header bitsream:
                header = new byte[HEADER_SIZE];
                for (int i = 0; i < HEADER_SIZE; i++)
                    header[i] = packet[i];

                //get the payload bitstream:
                payload_size = packet_size - HEADER_SIZE - HMAC_SIZE;
                payload = new byte[payload_size];
                for (int i = HEADER_SIZE; i < packet_size - HMAC_SIZE; i++)
                    payload[i - HEADER_SIZE] = packet[i];

                //get the hmac bitstream
                hmac = new byte[HMAC_SIZE];
                for (int i = HEADER_SIZE + payload_size; i < HMAC_SIZE + HEADER_SIZE + payload_size; i++)
                    hmac[i - HEADER_SIZE - payload_size] = packet[i];

                //interpret the changing fields of the header:
                PayloadType = header[1] & 127;
                SequenceNumber = unsigned_int(header[3]) + 256 * unsigned_int(header[2]);
                TimeStamp = unsigned_int(header[7]) + 256 * unsigned_int(header[6]) + 65536 * unsigned_int(header[5]) + 16777216 * unsigned_int(header[4]);
            }
        }

        public byte[] getHmac()
        {
            return hmac;
        }

        //--------------------------
        //getpayload: return the payload bistream of the RTPpacket and its size
        //--------------------------
        public virtual int getpayload(byte[] data)
        {

            for (int i = 0; i < payload_size; i++)
                data[i] = payload[i];

            return (payload_size);
        }

        //--------------------------
        //getpayload_length: return the length of the payload
        //--------------------------
        public virtual int getpayload_length()
        {
            return (payload_size);
        }

        //--------------------------
        //getlength: return the total length of the RTP packet
        //--------------------------
        public virtual int getlength()
        {
            return (payload_size + HEADER_SIZE);
        }

        //--------------------------
        //getpacket: returns the packet bitstream and its length
        //--------------------------
        public virtual int getpacket(byte[] packet)
        {
            //construct the packet = header + payload
            for (int i = 0; i < HEADER_SIZE; i++)
                packet[i] = header[i];
            for (int i = 0; i < payload_size; i++)
                packet[i + HEADER_SIZE] = payload[i];

            //return total size of the packet
            return (payload_size + HEADER_SIZE);
        }

        //--------------------------
        //gettimestamp
        //--------------------------

        public virtual int gettimestamp()
        {
            return (TimeStamp);
        }

        //--------------------------
        //getsequencenumber
        //--------------------------
        public virtual int getsequencenumber()
        {
            return (SequenceNumber);
        }

        //--------------------------
        //getpayloadtype
        //--------------------------
        public virtual int getpayloadtype()
        {
            return (PayloadType);
        }

        //--------------------------
        //print headers without the SSRC
        //--------------------------
        public virtual string printheader()
        {
            string s = null;
            for (int i = 0; i < (HEADER_SIZE - 4); i++)
            {
                for (int j = 7; j >= 0; j--)
                    if (((1 << j) & header[i]) != 0)
                        s += "1";
                    else
                        s += "0";
                s += " ";
            }
            return s;
        }

        //return the unsigned value of 8-bit integer nb
        internal static int unsigned_int(int nb)
        {
            if (nb >= 0)
                return (nb);
            else
                return (256 + nb);
        }

        public Image GetPayloadAsImage()
        {
            //get the payload bitstream from the RTPpacket object
            try
            {

                int payload_length = this.getpayload_length();
                byte[] payload = new byte[payload_length];
                this.getpayload(payload);

                Stream imageInMemory = new MemoryStream(payload);
                return Image.FromStream(imageInMemory);
            }
            catch (Exception e)
            {
                return null;
                // throw new Exception(e.Message);
            }
        }

        public byte[] GetPayloadAsByteArray()
        {
            //get the payload bitstream from the RTPpacket object
            try
            {

                int payload_length = this.getpayload_length();
                byte[] payload = new byte[payload_length];
                this.getpayload(payload);

                return payload;
            }
            catch (Exception e)
            {
                return null;
                // throw new Exception(e.Message);
            }
        }
    }
}
