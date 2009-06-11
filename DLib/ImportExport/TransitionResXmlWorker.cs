using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FSM;
using LogicUtils;
using System.Xml;

namespace ImportExport
{
    public class TransitionResXmlWorker : IXmlWorker
    {
        public TransitionResXmlWorker()
        {

        }
        public TransitionResXmlWorker(TransitionRes<StructAtom<string>, StructAtom<string>> transitionRes)
        {
            value = transitionRes;
        }

        private TransitionRes<TInput, TOutput> value = null;

        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            return CreateXmlNode(doc, NodeName);
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            if (value == null)
                throw new NullReferenceException();

            XmlNode Node = doc.CreateElement(this.NodeName);

            //XmlAttribute Attr = doc.CreateAttribute("Version");
            //Attr.InnerText = this.Version;
            //Node.Attributes.Append(Attr);

            //XmlElement Element = doc.CreateElement("DestState");
            //Element.InnerText = value.DestState.KeyName;
            //Node.AppendChild(Element);


            return Node;
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

        public TransitionRes<TInput, TOutput> Value
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
