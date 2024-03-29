﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FSM;

namespace ImportExport
{
    public class StateXmlWorker: IXmlWorker
    {
        public StateXmlWorker()
        {
        }

        public StateXmlWorker(FSMState<StructAtom<string>, StructAtom<string>> state)
        {
            value = state;
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; set; }

        private FSMState<StructAtom<string>, StructAtom<string>> value = null;

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
            result.InnerText = value.StateCore as string;

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");
            if (FSM == null) throw new NullReferenceException("FSM");

            try
            {
                //if(node.ChildNodes.Count == 0)
                    value = new FSMState<StructAtom<string>, StructAtom<string>>(FSM, node.InnerText);
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
            get { return "State"; }
        }

        #endregion
    }
}
