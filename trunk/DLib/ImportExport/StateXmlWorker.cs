using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ImportExport
{
    public class StateXmlWorker: IXmlWorker
    {
        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            throw new NotImplementedException();
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            throw new NotImplementedException();
        }

        public void ParseFromNode(XmlNode node)
        {
            throw new NotImplementedException();
        }

        public bool Compare(XmlNode node)
        {
            throw new NotImplementedException();
        }

        public string GenerateFileName()
        {
            throw new NotImplementedException();
        }

        public object Value
        {
            get { throw new NotImplementedException(); }
        }

        public string NodeName
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
