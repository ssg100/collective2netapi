using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<signal>
    //  <signalid>49247662</signalid>
    //  <tradeid>49247665</tradeid>
    //  <filledwhen>2010-05-11 15:16:22</filledwhen>
    //  <fillprice>16.6378</fillprice>
    //  <action>BTO</action>
    //  <quant>2850</quant>
    //  <symbol>QID</symbol>
    //  <instrument>stock</instrument>
    //  <marketOrder>1</marketOrder>
    //  <limitPrice>0</limitPrice>
    //  <stopPrice>0</stopPrice>
    //  <TIF>DAY</TIF>
    //  <postedwhen>2010-05-11 15:16:22</postedwhen>
    //  <conditionalUpon>
    //  </conditionalUpon>
    //  <commentary>Buying%202%2C850%20shares%20of%20QID%2C%20starting%20that%20position%2C%20which%20is%20about%2025%25%20of%20ETF%20Timer%27s%20total%20account%20value%2E</commentary>
    //</signal>

    [DebuggerDisplay("ID={ID}, Posted={PostedTime}, Action={Action}, Symbol={Symbol}, Symbol={Quantity}")]
    public class Signal : IComparable<Signal>
    {
        public string ID;
        public string TradeID;
        public string FilledTime;
        public string FilledPrice;
        public string Action;
        public string Quantity;
        public string Symbol;
        public string Type;
        public bool MarketOrder;
        public string Limit;
        public string Stop;
        public string TIF;
        public string PostedTime;
        public string Comment;

        public void Parse(XmlNode node)
        {
            this.ID = node.ReadString("signalid");
            this.TradeID = node.ReadString("tradeid");
            this.FilledTime = node.ReadString("filledwhen");
            this.FilledPrice = node.ReadString("fillprice");
            this.Action = node.ReadString("action");
            this.Quantity = node.ReadString("quant");
            this.Symbol = node.ReadString("symbol");
            this.Type = node.ReadString("instrument");
            this.MarketOrder = node.ReadBoolean("marketOrder");
            this.Limit = node.ReadString("limitPrice");
            this.Stop = node.ReadString("stopPrice");
            this.TIF = node.ReadString("TIF");
            this.PostedTime = node.ReadString("postedwhen");
            this.Comment = node.ReadString("commentary");
        }

        #region IComparable<Signal> Members

        public int CompareTo(Signal other)
        {
            DateTime this_filled = Convert.ToDateTime(this.FilledTime);
            DateTime other_filled = Convert.ToDateTime(other.FilledTime);
            return other_filled.CompareTo(this_filled);
        }

        #endregion
    }
}
