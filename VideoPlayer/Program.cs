using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace VideoPlayer
{

    // Summary:
    //     Specifies the RTSP variables.
    public enum RTSPConst
    {
        //rtsp states
        INIT = 0,
        READY = 1,
        PLAYING = 2,

        //rtsp message types
        SETUP = 3,
        PLAY = 4,
        PAUSE = 5,
        TEARDOWN = 6,

    }
    // Summary:
    //     Specifies the Video variables.
    public enum VideoConst
    {
        MJPEG_TYPE = 26, //RTP payload type for MJPEG video
        FRAME_PERIOD = 100, //Frame period of the video to stream, in ms
        VIDEO_LENGTH = 600, //length of the video in frames
    }


    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new View());
        }
    }
}
