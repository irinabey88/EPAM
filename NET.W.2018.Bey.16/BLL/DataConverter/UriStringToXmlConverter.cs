using System;
using System.Collections.Generic;
using System.Xml.Linq;
using BLL.Interface.Interfaces;

namespace BLL.DataConverter
{
    /// <summary>
    /// Provides class for converting dataFormat
    /// </summary>
    public class UriStringToXmlConverter : IConverter<XDocument>
    {
        private readonly IDataReceiver<string> _dataReceiver;
        private readonly IDataCreator<string, XElement> _dataCreator;

        /// <summary><see cref="UriStringToXmlConverter"/>
        /// Get instance of 
        /// </summary>
        /// <param name="dataReceiver">Data receiver</param>
        /// <param name="dataCreator">Data creator</param>
        public UriStringToXmlConverter(IDataReceiver<string> dataReceiver, IDataCreator<string, XElement> dataCreator)
        {
            this._dataReceiver = dataReceiver ?? throw new ArgumentNullException(nameof(dataReceiver));
            this._dataCreator = dataCreator ?? throw new ArgumentNullException(nameof(dataCreator));
        }

        /// <summary>
        /// Convert uri in string to xml view
        /// </summary>
        /// <returns></returns>
        public XDocument Convert()
        {
            var uriList = this._dataReceiver.GetData();
            
            List<XElement> elements = new List<XElement>();

            foreach (var uri in uriList)
            {
                var element = this._dataCreator.Create(uri);
                elements.Add(element);
            }

            XDocument xmlDocument = new XDocument();
            XElement rootTag = new XElement("urlAdress");
            xmlDocument.Add(rootTag);
            rootTag.Add(elements);

            return xmlDocument;
        }
    }
}