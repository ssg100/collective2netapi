using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Diagnostics;

namespace Collective2.C2DS.Data
{
    //<stat>
    //  <name>avgadversedd</name>
    //  <val>-3.41</val>
    //  <calced>2010-05-22 20:30:37</calced>
    //</stat>

    [DebuggerDisplay("name={name}, val={val}, calced={calced}")]
    public class Stat : IComparable<Stat>
    {
        public string name;
        public string val;
        public string calced;


        public void Parse(XmlNode node)
        {
            this.name = node.ReadString("name");
            this.val = node.ReadString("val");
            this.calced = node.ReadString("calced");
        }

        #region IComparable<Stat> Members

        public int CompareTo(Stat other)
        {
            return name.CompareTo(other.name);
        }

        #endregion

    }
}
