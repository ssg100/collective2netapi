using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Collective2.C2DS.Data;

namespace Collective2.C2DS.Responses
{
    public class SystemOverviewResponse : Response
    {
        public string systemid;
        public string systemname;
        public string startedwhen;
        public string creator_c2userid;
        public string creator_name;
        public string creator_org;
        public string descrip_short;
        public string descrip_long;


        public BusinessModel BusinessModel = new BusinessModel();
        public TradeStyle TradeStyle = new TradeStyle();
        public SummaryStats SummaryStats = new SummaryStats();
        public Margin Margin = new Margin();
        


        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            systemid = doc.ReadString("c2xml/system/systemid");
            systemname = doc.ReadString("c2xml/system/systemname");
            startedwhen = doc.ReadString("c2xml/system/startedwhen");
            creator_c2userid = doc.ReadString("c2xml/system/creator/c2userid");
            creator_name = doc.ReadString("c2xml/system/creator/name");
            creator_org = doc.ReadString("c2xml/system/creator/org");
            descrip_short = doc.ReadString("c2xml/system/descrip/short");
            descrip_long = doc.ReadString("c2xml/system/descrip/long");

            BusinessModel.Parse(doc.SelectSingleNode("c2xml/system/businessmodel"));
            TradeStyle.Parse(doc.SelectSingleNode("c2xml/system/tradestyle"));
            SummaryStats.Parse(doc.SelectSingleNode("c2xml/system/summarystats"));
            Margin.Parse(doc.SelectSingleNode("c2xml/system/margin"));
        }
    }
}
