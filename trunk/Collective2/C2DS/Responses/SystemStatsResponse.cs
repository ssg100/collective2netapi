using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SystemStatsResponse : Response
    {
        public string systemid;
        public string systemname;

        public Stat[] Stats;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");
            this.systemname = doc.ReadString("c2xml/systemname");

            List<Stat> list = new List<Stat>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/stats/stat"))
            {
                Stat stat = new Stat();
                stat.Parse(item);
                list.Add(stat);
            }

            list.Sort();

            this.Stats = list.ToArray();
        }
    }
}
