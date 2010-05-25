using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class PendingSignalsResponse : Response
    {
        public string systemid;
        public string systemname;

        public Signal[] PendingSignals;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");
            this.systemname = doc.ReadString("c2xml/systemname");

            List<Signal> list = new List<Signal>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/pendingSignals/signal"))
            {
                Signal signal = new Signal();
                signal.Parse(item);
                list.Add(signal);
            }

            list.Sort();

            this.PendingSignals = list.ToArray();
        }
    }
}