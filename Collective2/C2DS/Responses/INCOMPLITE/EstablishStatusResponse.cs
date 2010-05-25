using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class EstablishStatusResponse : Response
    {
        public string Comment = "IMPLEMENTATION IS INCOMPLITE";

        public string systemid;
        public string systemname;
        public string statustimestamp;

        public Margin Margin = new Margin();
        public Trade[] OpenPositions;
        public Signal[] SignalsTradedInOpenPositions;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            systemid = doc.ReadString("c2xml/systemid");
            systemname = doc.ReadString("c2xml/systemname");
            statustimestamp = doc.ReadString("c2xml/status/timestamp");

            Margin.Parse(doc.SelectSingleNode("c2xml/status/margin"));


            List<Trade> positions = new List<Trade>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/status/openPositions/trade"))
            {
                Trade position = new Trade();
                position.Parse(item);
                positions.Add(position);
            }

            positions.Sort();

            this.OpenPositions = positions.ToArray();



            List<Signal> signals = new List<Signal>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/status/signalsTradedInOpenPositions/signal"))
            {
                Signal signal = new Signal();
                signal.Parse(item);
                signals.Add(signal);
            }

            signals.Sort();

            this.SignalsTradedInOpenPositions = signals.ToArray();
        }
    }
}
