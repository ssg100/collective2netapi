using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Collective2.Core
{
    class CoreRequestParamCollection: List<CoreRequestParam>
    {
        public void Add(string name, string value)
        {
            this.Add(new CoreRequestParam(name, value));
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in this)
            {
                //b.AppendFormat("&{0}={1}", item.Name, HttpUtility.UrlEncode(item.Value));
                sb.AppendFormat("&{0}={1}", item.Name, item.Value);
            }

            return sb.ToString();
        }
    }
}
