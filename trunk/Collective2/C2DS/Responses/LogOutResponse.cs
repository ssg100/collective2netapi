using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2DS.Responses
{
    public class LogOutResponse : Response
    {
        public double Minutes;
        public long Bytes;

        public override void Parse(XmlDocument doc)
        {
            base.Parse(doc);

            Minutes = doc.ReadDouble("c2xml/logout/minutes");
            Bytes = doc.ReadInt64("c2xml/logout/bytes");
        }
    }
}
