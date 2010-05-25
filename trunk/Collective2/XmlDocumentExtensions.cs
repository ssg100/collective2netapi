using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Web;

namespace Collective2
{
    static class XmlDocumentExtensions
    {
        public static string ReadString(this XmlNode doc, string xpath)
        {
            var nodes = doc.SelectNodes(xpath);

            if (nodes.Count > 0)
            {

                return HttpUtility.UrlDecode(nodes[0].InnerText);
            }

            return string.Empty;
        }


        public static bool ReadBoolean(this XmlNode doc, string xpath)
        {
            string stringValue = doc.ReadString(xpath).Trim().ToLower();

            if (stringValue == "true" || stringValue == "y" || stringValue == "1")
            {
                return true;
            }

            return false;
        }


        public static int ReadInt(this XmlNode doc, string xpath)
        {
            string stringValue = doc.ReadString(xpath);

            int result = 0;
            if (int.TryParse(stringValue, out result))
            {
                return result;
            }

            return 0;
        }


        public static double ReadDouble(this XmlNode doc, string xpath)
        {
            string stringValue = doc.ReadString(xpath);

            double result = 0;
            if (double.TryParse(stringValue, out result))
            {
                return result;
            }

            return 0;
        }


        public static long ReadInt64(this XmlDocument doc, string xpath)
        {
            string stringValue = doc.ReadString(xpath);

            long result = 0;
            if (long.TryParse(stringValue, out result))
            {
                return result;
            }

            return 0;
        }
    }
}
