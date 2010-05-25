using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    [DebuggerDisplay("systemid={systemid}, systemname={systemname}")]
    public class SystemInfoShort
    {
        public string systemid;
        public string systemname;


        public void Parse(XmlNode node)
        {
            this.systemid = node.ReadString("systemid");
            this.systemname = node.ReadString("systemname");
        }
    }
}
