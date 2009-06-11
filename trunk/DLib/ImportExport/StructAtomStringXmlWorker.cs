using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FSM;

namespace ImportExport
{
    public class StructAtomStringXmlWorker:IXmlWorker
    {
        public StructAtomStringXmlWorker()
        {    
        }

        public StructAtomStringXmlWorker(StructAtom<string> atom)
        {
            value = atom;
        }

        private StructAtom<string> value = null;

        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            return CreateXmlNode(doc, NodeName);
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            if (value == null)
                throw new NullReferenceException();

            XmlElement result = doc.CreateElement(nodeName);
            result.InnerText = value.Value;

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");

            try
            {
                //if (node.ChildNodes.Count == 0)
                    value = new StructAtom<string>(node.InnerText);
            }
            catch (Exception exc)
            {
                value = null;
                throw exc;
            }
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
            get { return value; }
        }

        public string NodeName
        {
            get { return "Atom"; }
        }

        #endregion
    }
}
