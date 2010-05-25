using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SystemRosterResponse : Response
    {
        public SystemRosterInfo[] Systems;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            List<SystemRosterInfo> list = new List<SystemRosterInfo>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/systemroster/system"))
            {
                SystemRosterInfo info = new SystemRosterInfo();
                info.Parse(item);
                list.Add(info);
            }

            list.Sort();

            this.Systems = list.ToArray();
        }
    }
}