using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace Collective2.C2DS.Data
{
    //<tradestyle>
    //  <stockpcnt>1</stockpcnt>
    //  <optionpcnt>0</optionpcnt>
    //  <futurepcnt>0</futurepcnt>
    //  <forexpcnt>0</forexpcnt>
    //  <avgTradeMinute>19927</avgTradeMinute>
    //</tradestyle>

    [DebuggerDisplay("stockpcnt={stockpcnt}, optionpcnt={optionpcnt}, futurepcnt={futurepcnt}, forexpcnt={forexpcnt}, avgTradeMinute={avgTradeMinute}")]
    public class TradeStyle
    {
        public string stockpcnt;
        public string optionpcnt;
        public string futurepcnt;
        public string forexpcnt;
        public string avgTradeMinute;


        public void Parse(XmlNode node)
        {
            if (node == null) return;

            stockpcnt = node.ReadString("stockpcnt");
            optionpcnt = node.ReadString("optionpcnt");
            futurepcnt = node.ReadString("futurepcnt");
            forexpcnt = node.ReadString("forexpcnt");
            avgTradeMinute = node.ReadString("avgTradeMinute");
        }
    }
}
