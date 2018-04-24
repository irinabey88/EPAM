using System;
using System.Web;
using System.Xml.Linq;
using BLL.Exceptions;
using BLL.Interface.Interfaces;

namespace BLL.DataCreator
{
    public class XmlFileCreator : IXmlCreator<string>
    {
        public XElement Create(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
            {
                throw new ArgumentNullException(nameof(data));
            }

            Uri uri;

            try
            {
                uri = new Uri(data);
            }
            catch (UriFormatException ex)
            {                
                throw new UriException($"Incorrect uri: {data}", ex);
            }

            var urlElement = new XElement("url");  
            var hostElement = new XElement("host");
            hostElement.Add(new XAttribute("value", uri.Host));
            urlElement.Add(hostElement);

            if (uri.Segments.Length > 0)
            {
                var uriPathElement = new XElement("path");
                hostElement.Add(uriPathElement);

                foreach (var segment in uri.Segments)
                {
                    var segmentElement = new XElement("segment");
                    segmentElement.Add(new XAttribute("value", segment));
                    uriPathElement.Add(segmentElement);
                }
            }

            var paramsList = HttpUtility.ParseQueryString(uri.Query);
            if (paramsList.Count > 0)
            {
                var paramsElement = new XElement("params");
                hostElement.Add(paramsElement);

                foreach (var param in paramsList)
                {
                    var paramElement = new XElement("param");
                    paramElement.Add(new XAttribute("value", param.ToString()));
                    paramsElement.Add(paramElement);
                }
            }

            return urlElement;
        }
    }
}