using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<businessmodel>
    //  <modelnum>1</modelnum>
    //  <modelname>periodic</modelname>
    //  <periodname>month</periodname>
    //  <freetrial>7</freetrial>
    //  <charge>97</charge>
    //</businessmodel>

    [DebuggerDisplay("modelname={modelname}, periodname={periodname}, charge={charge}, freetrial={freetrial}")]
    public class BusinessModel
    {
        public string modelnum;
        public string modelname;
        public string periodname;
        public string freetrial;
        public string charge;


        public void Parse(XmlNode node)
        {
            if (node == null) return;

            this.modelnum = node.ReadString("modelnum");
            this.modelname = node.ReadString("modelname");
            this.periodname = node.ReadString("periodname");
            this.freetrial = node.ReadString("freetrial");
            this.charge = node.ReadString("charge");
        }
    }
}
