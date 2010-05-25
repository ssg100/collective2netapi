using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class TradeHistoryResponse : Response
    {
        public string systemid;
        public string systemname;

        public HistoricalTrade[] Trades;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");
            this.systemname = doc.ReadString("c2xml/systemname");

            List<HistoricalTrade> treades = new List<HistoricalTrade>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/trades/trade"))
            {
                HistoricalTrade trade = new HistoricalTrade();
                trade.Parse(item);
                treades.Add(trade);
            }

            treades.Sort();

            this.Trades = treades.ToArray();
        }
    }
}