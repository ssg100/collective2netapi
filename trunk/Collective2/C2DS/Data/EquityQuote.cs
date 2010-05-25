using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<e>
    //  <t>2008-01-31 12:55:18</t>
    //  <o>-17</o>
    //  <c>50000</c>
    //</e>

    [DebuggerDisplay("Time={Time}, Open={Open}, Close={Close}")]
    public class EquityQuote
    {
        public string Time;
        public string Open;
        public string Close;

        public void Parse(XmlNode node)
        {
            this.Time = node.ReadString("t");
            this.Open = node.ReadString("o");
            this.Close = node.ReadString("c");
        }

        #region IComparable<EquityQuote> Members

        public int CompareTo(EquityQuote other)
        {
            DateTime this_time = Convert.ToDateTime(this.Time);
            DateTime other_time = Convert.ToDateTime(other.Time);
            return other_time.CompareTo(this_time);
        }

        #endregion
    }
}
