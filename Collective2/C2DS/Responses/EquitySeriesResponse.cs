using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class EquitySeriesResponse : Response
    {
        public string systemid;

        public EquityQuote[] EquitySeries;


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            this.systemid = doc.ReadString("c2xml/systemid");

            List<EquityQuote> quotes = new List<EquityQuote>();

            foreach (XmlNode item in doc.SelectNodes("c2xml/equityseries/e"))
            {
                EquityQuote quote = new EquityQuote();
                quote.Parse(item);
                quotes.Add(quote);
            }

            quotes.Sort();

            this.EquitySeries = quotes.ToArray();
        }
    }
}
