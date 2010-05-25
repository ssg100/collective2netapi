using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2ATI
{
    public class LoginResponse : Response
    {
        public string Session;
        public string First;
        public string Last;
        public string RedirectIP;
        public int RedirectPort;
        public string PollInterval;
        public string ServerTime;
        public string HumanTime;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            Session = doc.ReadString("collective2/data/session");
            First = doc.ReadString("collective2/data/first");
            Last = doc.ReadString("collective2/data/last");
            RedirectIP = doc.ReadString("collective2/data/redirectip");
            RedirectPort = doc.ReadInt("collective2/data/redirectport");
            PollInterval = doc.ReadString("collective2/data/pollinterval");
            ServerTime = doc.ReadString("collective2/data/servertime");
            HumanTime = doc.ReadString("collective2/data/humantime");
        }
    }
}
