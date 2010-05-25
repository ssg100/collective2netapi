using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<margin>
    //  <startingCash>50000</startingCash>
    //  <currentCash>174634.00</currentCash>
    //  <equity>3594.81</equity>
    //  <marginUsed>0.00</marginUsed>
    //  <availBuyPower>178228.81</availBuyPower>
    //</margin>

    [DebuggerDisplay("currentCash={currentCash}, equity={equity}, availBuyPower={availBuyPower}")]
    public class Margin
    {
        public string startingCash;
        public string currentCash;
        public string equity;
        public string marginUsed;
        public string availBuyPower;

        public void Parse(XmlNode node)
        {
            startingCash = node.ReadString("startingCash");
            currentCash = node.ReadString("currentCash");
            equity = node.ReadString("equity");
            marginUsed = node.ReadString("marginUsed");
            availBuyPower = node.ReadString("availBuyPower");
        }
    }
}
