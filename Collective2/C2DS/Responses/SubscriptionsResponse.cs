using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SubscriptionsResponse : Response
    {
        public SystemInfoShort[] Subscriptions;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            List<SystemInfoShort> systems = new List<SystemInfoShort>();

            foreach (XmlNode item in doc.SelectNodes("subscriptions/systemlist/system"))
            {
                var sysinfo = new SystemInfoShort();
                sysinfo.Parse(item);
                systems.Add(sysinfo);
            }

            Subscriptions = systems.ToArray();
        }
    }
}
