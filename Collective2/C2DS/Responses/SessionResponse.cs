using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SessionResponse : Response
    {
        public bool LoginValid;
        public string LoginMessage;

        public string SessionID;
        public string C2UserID;
        public string FirstName;
        public string LastName;

        public SystemInfoShort[] Subscriptions;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            if (Error == true) return;

            LoginValid = doc.ReadBoolean("c2xml/login/valid");
            LoginMessage = doc.ReadString("c2xml/login/message");

            if (LoginValid == false) return;

            SessionID = doc.ReadString("c2xml/session/id");
            C2UserID = doc.ReadString("c2xml/session/c2userid");
            FirstName = doc.ReadString("c2xml/session/firstname");
            LastName = doc.ReadString("c2xml/session/lastname");

            List<SystemInfoShort> systems = new List<SystemInfoShort>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/subscriptions/systemlist/system"))
            {
                var sysinfo = new SystemInfoShort();
                sysinfo.Parse(item);
                systems.Add(sysinfo);
            }

            Subscriptions = systems.ToArray();
        }
    }
}
