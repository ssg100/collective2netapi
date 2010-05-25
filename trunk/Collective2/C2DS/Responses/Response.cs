using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2DS.Responses
{
    public abstract class Response
    {
        public DateTime RequestTime;
        public DateTime ResponseTime;
        public bool Error;
        public string Message;
        public string XmlString;
        public XmlDocument XmlDocument;

        public virtual void Parse(XmlDocument doc)
        {
            Error = doc.ReadBoolean("c2xml/error");
            Message = doc.ReadString("c2xml/message");
            XmlString = doc.OuterXml;
            XmlDocument = doc;
        }
    }
}
