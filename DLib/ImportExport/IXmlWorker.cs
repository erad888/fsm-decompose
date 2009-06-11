using System;
using System.Xml;
namespace ImportExport
{
    public interface IXmlWorker
    {
        XmlNode CreateXmlNode(XmlDocument doc);
        XmlNode CreateXmlNode(XmlDocument doc, string nodeName);
        void ParseFromNode(XmlNode node);

        bool Compare(XmlNode node);

        string GenerateFileName();

        object Value { get; }
        string NodeName { get; }
    }
}
