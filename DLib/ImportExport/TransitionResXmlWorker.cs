﻿using System;
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

        private TransitionRes<StructAtom<string>, StructAtom<string>> value = null;
        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; set; }

        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            return CreateXmlNode(doc, NodeName);
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            if (value == null)
                throw new NullReferenceException();

            XmlNode result = doc.CreateElement(nodeName);
            
            StateXmlWorker w = new StateXmlWorker(value.DestState);
            result.AppendChild(w.CreateXmlNode(doc, "DestState"));

            XmlElement element = doc.CreateElement("Output");
            element.InnerText = value.Output.Value;
            result.AppendChild(element);

            element = doc.CreateElement("Probability");
            element.InnerText = value.Probability.ToString();
            result.AppendChild(element);

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");
            if (FSM == null) throw new NullReferenceException("FSM");

            value = new TransitionRes<StructAtom<string>, StructAtom<string>>();

            try
            {
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    switch (childNode.Name.ToLower())
                    {
                        case "deststate":
                            {
                                StateXmlWorker w = new StateXmlWorker();
                                w.FSM = this.FSM;
                                w.ParseFromNode(node.ChildNodes[i]);
                                var state = w.Value as FSMState<StructAtom<string>, StructAtom<string>>;
                                if (state != null)
                                {
                                    var exState = FSM.StateSet.First(s => s.KeyName == state.KeyName);
                                    if (exState != null)
                                        state = exState;
                                    value.DestState = state;
                                }
                            }
                            break;
                        case "output":
                            {
                                value.Output = new StructAtom<string>(childNode.InnerText);
                            }
                            break;
                        case "probability":
                            {
                                value.Probability = double.Parse(childNode.InnerText);
                            }
                            break;
                    }
                }
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
            get { return "TransitionResult"; }
        }

        #endregion
    }
}
