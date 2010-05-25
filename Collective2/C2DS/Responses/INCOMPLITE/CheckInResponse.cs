using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class CheckInResponse : Response
    {
        public string Comment = "IMPLEMENTATION IS INCOMPLITE";

        public string systemid;
        public string systemname;
        public string statustimestamp;    

        public Margin Margin = new Margin();

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            systemid = doc.ReadString("c2xml/systemid");
            systemname = doc.ReadString("c2xml/systemname");
            statustimestamp = doc.ReadString("c2xml/status/timestamp");

            Margin.Parse(doc.SelectSingleNode("c2xml/status/margin"));
        }
    }
}
