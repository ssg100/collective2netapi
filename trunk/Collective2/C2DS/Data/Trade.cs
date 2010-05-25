using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<trade>
    //  <tradeid>49247665</tradeid>
    //  <symbol>QID</symbol>
    //  <instrument>stock</instrument>
    //  <side>long</side>
    //  <positionOpened>2010-05-11 15:16:22</positionOpened>
    //  <quantOpened>2850</quantOpened>
    //  <quantClosed>1140</quantClosed>
    //  <entryPrice>16.63777</entryPrice>
    //  <pointValue>1</pointValue>
    //  <quote>
    //    <bid>18.7400c</bid>
    //    <ask>18.7400c</ask>
    //    <last>18.7400</last>
    //    <tick>16:00:01t</tick>
    //  </quote>
    //</trade>

    [DebuggerDisplay("ID={ID}, Symbol={Symbol}, Type={Type}, Side={Side}, Time={PositionOpenedTime}")]
    public class Trade : IComparable<Trade>
    {
        public string ID;
        public string Symbol;
        public string Type;
        public string Side;
        public string PositionOpenedTime;
        public string QuantityOpened;
        public string QuantityClosed;
        public string EntryPrice;
        public string PointValue;
        public string QuoteBid;
        public string QuoteAsk;
        public string QuoteLast;
        public string QuoteTick;

        public void Parse(XmlNode node)
        {
            this.ID = node.ReadString("tradeid");
            this.Symbol = node.ReadString("symbol");
            this.Type = node.ReadString("instrument");
            this.Side = node.ReadString("side");
            this.PositionOpenedTime = node.ReadString("positionOpened");
            this.QuantityOpened = node.ReadString("quantOpened");
            this.QuantityClosed = node.ReadString("quantClosed");
            this.EntryPrice = node.ReadString("entryPrice");
            this.PointValue = node.ReadString("pointValue");
            this.QuoteBid = node.ReadString("quote/bid");
            this.QuoteAsk = node.ReadString("quote/ask");
            this.QuoteLast = node.ReadString("quote/last");
            this.QuoteTick = node.ReadString("quote/tick");
        }

        #region IComparable<Signal> Members

        public int CompareTo(Trade other)
        {
            DateTime this_time = Convert.ToDateTime(this.PositionOpenedTime);
            DateTime other_time = Convert.ToDateTime(other.PositionOpenedTime);
            return other_time.CompareTo(this_time);
        }

        #endregion
    }
}
