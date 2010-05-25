using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<trade>
    //  <tradeid>30415398</tradeid>
    //  <result>2489</result>
    //  <type>stock</type>
    //  <earliestopen>2008-01-31 11:10:53</earliestopen>
    //  <openaction>BTO</openaction>
    //  <openquant>700</openquant>
    //  <opensymbol>QID</opensymbol>
    //  <openprice>49.5614</openprice>
    //  <lastclose>2008-03-14 11:09:00</lastclose>
    //  <closeaction>STC</closeaction>
    //  <closequant>700</closequant>
    //  <closeprice>53.1179</closeprice>
    //  <maxdrawdown>
    //    <amt>-1093</amt>
    //    <openquant>400</openquant>
    //    <entryprice>49.6525</entryprice>
    //    <worstprice>46.92</worstprice>
    //    <maxddwhen>2008-02-01 10:09:00</maxddwhen>
    //    <calcedwhen>2008-03-21 06:32:17</calcedwhen>
    //  </maxdrawdown>
    //</trade>
    public class HistoricalTrade : IComparable<HistoricalTrade>
    {
        public string TradeID;
        public string Result;
        public string Type;
        public string EarliestOpen;
        public string OpenAction;
        public string OpenQuant;
        public string OpenSymbol;
        public string OpenPrice;
        public string LastClose;
        public string CloseAction;
        public string CloseQuant;
        public string ClosePrice;
        public string MaxDrawdownAmt;
        public string MaxDrawdownOpenquant;
        public string MaxDrawdownEntryPrice;
        public string MaxDrawdownWorstPrice;
        public string MaxDrawdownMaxddwhen;
        public string MaxDrawdownCalcedwhen;


        public void Parse(XmlNode node)
        {
            this.TradeID = node.ReadString("tradeid");
            this.Result = node.ReadString("result");
            this.Type = node.ReadString("type");
            this.EarliestOpen = node.ReadString("earliestopen");
            this.OpenAction = node.ReadString("openaction");
            this.OpenQuant = node.ReadString("openquant");
            this.OpenSymbol = node.ReadString("opensymbol");
            this.OpenPrice = node.ReadString("openprice");
            this.LastClose = node.ReadString("lastclose");
            this.CloseAction = node.ReadString("closeaction");
            this.CloseQuant = node.ReadString("closequant");
            this.ClosePrice = node.ReadString("closeprice");
            this.MaxDrawdownAmt = node.ReadString("maxdrawdown/amt");
            this.MaxDrawdownOpenquant = node.ReadString("maxdrawdown/openquant");
            this.MaxDrawdownEntryPrice = node.ReadString("maxdrawdown/entryprice");
            this.MaxDrawdownWorstPrice = node.ReadString("maxdrawdown/worstprice");
            this.MaxDrawdownMaxddwhen = node.ReadString("maxdrawdown/maxddwhen");
            this.MaxDrawdownCalcedwhen = node.ReadString("maxdrawdown/calcedwhen");
        }

        #region IComparable<HistoricalTrade> Members

        public int CompareTo(HistoricalTrade other)
        {
            DateTime this_time = Convert.ToDateTime(this.EarliestOpen);
            DateTime other_time = Convert.ToDateTime(other.EarliestOpen);
            return other_time.CompareTo(this_time);
        }

        #endregion
    }
}
