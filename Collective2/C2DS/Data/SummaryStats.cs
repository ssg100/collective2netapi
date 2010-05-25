using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace Collective2.C2DS.Data
{
    //<summarystats>
    //  <startcapital>50000</startcapital>
    //  <openpl>5134</openpl>
    //  <closedpl>138798</closedpl>
    //  <marginused>0</marginused>
    //  <equity>3594.81</equity>
    //  <cash>174634</cash>
    //  <trades>20</trades>
    //  <numloss>4</numloss>
    //  <dollarwin>166770</dollarwin>
    //  <dollarloss>24830</dollarloss>
    //</summarystats>

    [DebuggerDisplay("trades={trades}, numloss={numloss}, dollarwin={dollarwin}, dollarloss={dollarloss}")]
    public class SummaryStats
    {
        public string startcapital;
        public string openpl;
        public string closedpl;
        public string marginused;
        public string equity;
        public string cash;
        public string trades;
        public string numloss;
        public string dollarwin;
        public string dollarloss;


        public void Parse(XmlNode node)
        {
            if (node == null) return;

            startcapital = node.ReadString("startcapital");
            openpl = node.ReadString("openpl");
            closedpl = node.ReadString("closedpl");
            marginused = node.ReadString("marginused");
            equity = node.ReadString("equity");
            cash = node.ReadString("cash");
            trades = node.ReadString("trades");
            numloss = node.ReadString("numloss");
            dollarwin = node.ReadString("dollarwin");
            dollarloss = node.ReadString("dollarloss");
        }
    }
}
