using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml;

namespace Collective2.C2DS.Data
{
    //<system>
    //  <id>555</id>
    //  <name>Test%20System</name>
    //  <agedays>1763.11</agedays>
    //  <numtrades>1</numtrades>
    //  <startcash>100000</startcash>
    //  <win>1019</win>
    //  <loss>0</loss>
    //  <forexpcnt>1</forexpcnt>
    //  <futurespcnt>0</futurespcnt>
    //  <stockpcnt>0</stockpcnt>
    //  <optionpcnt>0</optionpcnt>
    //  <c2userid>250</c2userid>
    //</system>

    [DebuggerDisplay("id={id}, name={name}, agedays={agedays}, numtrades={numtrades}")]
    public class SystemRosterInfo : IComparable<SystemRosterInfo>
    {
        public string id;
        public string name;
        public string agedays;
        public string numtrades;
        public string startcash;
        public string win;
        public string loss;
        public string forexpcnt;
        public string futurespcnt;
        public string stockpcnt;
        public string optionpcnt;
        public string c2userid;

        public void Parse(XmlNode node)
        {
            this.id = node.ReadString("id");
            this.name = node.ReadString("name");
            this.agedays = node.ReadString("agedays");
            this.numtrades = node.ReadString("numtrades");
            this.startcash = node.ReadString("startcash");
            this.win = node.ReadString("win");
            this.loss = node.ReadString("loss");
            this.forexpcnt = node.ReadString("forexpcnt");
            this.futurespcnt = node.ReadString("futurespcnt");
            this.stockpcnt = node.ReadString("stockpcnt");
            this.optionpcnt = node.ReadString("optionpcnt");
            this.c2userid = node.ReadString("c2userid");
        }

        #region IComparable<SystemRosterInfo> Members

        public int CompareTo(SystemRosterInfo other)
        {
            int this_id = Convert.ToInt32(this.id);
            int other_id = Convert.ToInt32(other.id);
            return this_id.CompareTo(other_id);
        }

        #endregion
    }
}
