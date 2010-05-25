using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Collective2.C2ATI
{
    //<collective2>
    //    <status>OK</status>
    //    <error>
    //        <code>0</code>
    //        <url></url>
    //    </error>
    //</collective2>
    public abstract class Response
    {
        public DateTime RequestTime;
        public DateTime ResponseTime;
        public string Status;
        public string ErrorCode;
        public string ErrorURL;


        public virtual void Parse(XmlDocument doc)
        {
            Status = doc.ReadString("collective2/status");
            ErrorCode = doc.ReadString("collective2/error/code");
            ErrorURL = doc.ReadString("collective2/error/url");
        }
    }
}
