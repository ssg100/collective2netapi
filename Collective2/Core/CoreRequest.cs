using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml;
using System.IO;

namespace Collective2.Core
{
    class CoreRequest
    {
        public string Host;
        public int Port;
        public string Path;
        public string Command;
        public CoreRequestParamCollection Params = new CoreRequestParamCollection();
        public bool LoggingEnabled;


        public static CoreRequest Create(string host, int port, string path, string command)
        {
            return new CoreRequest()
            {
                Host = host,
                Port = port,
                Path = path,
                Command = command
            };
        }


        public static CoreRequest Create(string host, int port, string command)
        {
            return new CoreRequest()
            {
                Host = host,
                Port = port,
                Path = string.Empty,
                Command = command
            };
        }


        public CoreResponse GetResponse()
        {
            string uri;

            if (Port == 80)
            {
                uri = string.Format("http://{0}{1}?cmd={2}{3}", Host, Path, Command, Params);
            }
            else
            {
                uri = string.Format("http://{0}:{1}{2}?cmd={3}{4}", Host, Port, Path, Command, Params);
            }
            

            WebRequest webRequest = WebRequest.Create(uri);
            WebResponse webResponse = (WebResponse)webRequest.GetResponse();

            var result = new CoreResponse(webResponse.GetResponseStream());

            if (LoggingEnabled)
            {
                if (Directory.Exists("log") == false)
                {
                    Directory.CreateDirectory("log");
                }

                string fileName = "log\\" + DateTime.Now.ToString("yyyyMMdd_hhmmss") + "_" + Command + ".xml";
                result.Save(fileName);
            }

            return result;
        }
    }
}
