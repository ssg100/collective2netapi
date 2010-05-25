using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace Collective2.C2DS.Data
{
    //<signal>
    //  <sigid>30415393</sigid>
    //  <posted>2008-01-31 11:10:48</posted>
    //  <traded>2008-01-31 11:10:53</traded>
    //  <action>BTO</action>
    //  <quant>100</quant>
    //  <symbol>QID</symbol>
    //  <type>stock</type>
    //  <market>0</market>
    //  <limit>0</limit>
    //  <stop>50.71</stop>
    //  <tif>DAY</tif>
    //  <tradeprice>50.71</tradeprice>
    //  <tradeid>30415398</tradeid>
    //  <comment>
    //  </comment>
    //</signal>

    [DebuggerDisplay("ID={ID}, Posted={PostedTime}, Action={Action}, Symbol={Symbol}, Symbol={Quantity}")]
    public class HistoricalSignal: IComparable<HistoricalSignal> 
    {
        public string ID;
        public string PostedTime;
        public string TradedTime;
        public string Action;
        public string Quantity;
        public string Symbol;
        public string Type;
        public bool MarketOrder;
        public string Limit;
        public string Stop;
        public string TIF;
        public string TradePrice;
        public string TradeID;
        public string Comment;

        public void Parse(XmlNode node)
        {
            this.ID = node.ReadString("sigid");
            this.PostedTime = node.ReadString("posted");
            this.TradedTime = node.ReadString("traded");
            this.Action = node.ReadString("action");
            this.Quantity = node.ReadString("quant");
            this.Symbol = node.ReadString("symbol");
            this.Type = node.ReadString("type");
            this.MarketOrder = node.ReadBoolean("market");
            this.Limit = node.ReadString("limit");
            this.Stop = node.ReadString("stop");
            this.TIF = node.ReadString("tif");
            this.TradePrice = node.ReadString("tradeprice");
            this.TradeID = node.ReadString("tradeid");
            this.Comment = node.ReadString("comment");
        }

        #region IComparable<Signal> Members

        public int CompareTo(HistoricalSignal other)
        {
            DateTime this_posted = Convert.ToDateTime(this.PostedTime);
            DateTime other_posted = Convert.ToDateTime(other.PostedTime);
            return other_posted.CompareTo(this_posted);
        }

        #endregion
    }
}
