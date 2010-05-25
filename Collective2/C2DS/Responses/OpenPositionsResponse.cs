using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class OpenPositionsResponse : Response
    {
        public string systemid;
        public string systemname;

        public Trade[] OpenPositions;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");
            this.systemname = doc.ReadString("c2xml/systemname");

            List<Trade> positions = new List<Trade>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/openPositions/trade"))
            {
                Trade position = new Trade();
                position.Parse(item);
                positions.Add(position);
            }

            positions.Sort();

            this.OpenPositions = positions.ToArray();
        }
    }
}