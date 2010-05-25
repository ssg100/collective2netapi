using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace Collective2.Core
{
    class CoreResponse : XmlDocument
    {
        public CoreResponse(Stream stream)
        {
            this.Load(stream);
        }
    }
}
