using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collective2.Core
{
    class CoreRequestParam
    {
        public string Name;
        public string Value;


        public CoreRequestParam(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
