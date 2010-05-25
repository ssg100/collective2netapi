using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SignalHistoryResponse : Response
    {
        public string systemid;
        public string systemname;

        public HistoricalSignal[] Signals;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");
            this.systemname = doc.ReadString("c2xml/systemname");

            List<HistoricalSignal> signals = new List<HistoricalSignal>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/signals/signal"))
            {
                HistoricalSignal signal = new HistoricalSignal();
                signal.Parse(item);
                signals.Add(signal);
            }

            signals.Sort(); 

            this.Signals = signals.ToArray();
        }
    }
}