﻿using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
//using CSCore;
//using CSCore.MediaFoundation;
//using CSCore.SoundOut;

using static System.Net.Mime.MediaTypeNames;
using OSCVRCWiz.TTS;
using Newtonsoft.Json.Linq;
using OSCVRCWiz.Text;
using VRC.OSCQuery;
using CoreOSC;
using Extensions = VRC.OSCQuery.Extensions;
using Windows.Devices.Power;
using Newtonsoft.Json;
//using VRC.OSCQuery; // Beta Testing dll (added the project references)


namespace OSCVRCWiz
{

    public class WebCaptionerRecognition
    {
            public static int Port = 54026;
            public static string recievedString ="";
            private static HttpListener _listener;
            static bool webCapEnabled = false;



        public static void WebCapToggle()
        {
            if (webCapEnabled == false)
            {
                webCapOn();
                webCapEnabled = true;
            }
            else
            {
                webCapOff();
                webCapEnabled = false;

            }
        }

        public static void autoStopWebCap()
        {
            if (webCapEnabled == true)
            {
                webCapOff();
                webCapEnabled = false;

            }

        }

        private static void webCapOn()
        {
            System.Diagnostics.Debug.WriteLine("Starting HTTP listener...");
            // var httpServer = new HttpServer();
            Task.Run(() => Start());
            System.Diagnostics.Debug.WriteLine("Starting HTTP listener Started");
            OutputText.outputLog("[Starting HTTP listener for Web Captioner Started. Go to https://webcaptioner.com/captioner > Settings (bottom right) > Channels > Webhook > set 'http://localhost:54026/' as the Webhook URL and experiment with different chunking values (I recommend a large value so it only sends when you finish talking). Now you're all set to click 'Start Captioning' in Web Captioner]");
            //button11.Enabled = false;
        }
        private static void webCapOff()
        {
            System.Diagnostics.Debug.WriteLine("Stopping HTTP listener...");
            //  var httpServer = new HttpServer();
            Task.Run(() => Stop());
            System.Diagnostics.Debug.WriteLine("Stopped HTTP listener");
            OutputText.outputLog("[HTTP listener for Web Captioner Stopped.]");
            // button11.Enabled = false;
        }



        public static void Start()
            {
                _listener = new HttpListener();
            // _listener.Prefixes.Add("http://*:" + Port.ToString() + "/");//MUST RUN AS ADMIN //http://127.0.0.1:8080/
            _listener.Prefixes.Add("http://localhost:" + Port.ToString() + "/"); //THIS IS THE EASIEST WAY TO MAKE USERS NOT HAVE TO RUN PROGRAM AS ADMINISTRATOR EVREY TIME!!! //http://localhost:8080/
            _listener.Start();
               
                Task.Run(() => Receive());
            }

            public static void Stop()
            {
                _listener.Stop();
            }

            private static void Receive()
            {
                _listener.BeginGetContext(new AsyncCallback(ListenerCallback), _listener);
                
            }

            private static async void ListenerCallback(IAsyncResult result)
            {
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //  System.Diagnostics.Debug.WriteLine("testing if this still works");
           // watch.Start();
            if (_listener.IsListening)
                {
                    var context = _listener.EndGetContext(result);
                    var request = context.Request;



                    if (request.HasEntityBody)
                    {
                        var body = request.InputStream;
                        var encoding = request.ContentEncoding;
                        var reader = new StreamReader(body, encoding);
                        string json = reader.ReadToEnd();
                        var text = JObject.Parse(json)["transcript"].ToString();   
                        Task.Run(() => VoiceWizardWindow.MainFormGlobal.MainDoTTS(text));

                   
                
                }
                    Stop();
                    Start();

                }
            }
       









    }
    }
  

