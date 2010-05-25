using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2ATI
{
    public class LogOffResponse : Response
    {
        public string Message;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            Message = doc.ReadString("collective2/data");
        }
    }
}
