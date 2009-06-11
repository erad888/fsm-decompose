using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FSM;

namespace ImportExport
{
    public class TransitionXmlWorker:IXmlWorker
    {
        public TransitionXmlWorker()
        {
        }

        public TransitionXmlWorker(Transition<StructAtom<string>, StructAtom<string>> transition)
        {
            value = transition;
        }

        private Transition<StructAtom<string>, StructAtom<string>> value = null;
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

            StateXmlWorker w = new StateXmlWorker(value.SourceState);
            result.AppendChild(w.CreateXmlNode(doc, "SourceState"));

            XmlElement element = doc.CreateElement("Input");
            element.InnerText = value.Input.Value;
            result.AppendChild(element);

            element = doc.CreateElement("TransitionResults");
            foreach (var destinationState in value.destinationStates)
            {
                TransitionResXmlWorker worker = new TransitionResXmlWorker(destinationState);
                element.AppendChild(worker.CreateXmlNode(doc));
            }
            result.AppendChild(element);

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");
            if (FSM == null) throw new NullReferenceException("FSM");

            value = new Transition<StructAtom<string>, StructAtom<string>>(FSM);

            try
            {
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    switch (childNode.Name.ToLower())
                    {
                        case "sourcestate":
                            {
                                StateXmlWorker w = new StateXmlWorker();
                                w.FSM = this.FSM;
                                w.ParseFromNode(childNode);
                                var state = w.Value as FSMState<StructAtom<string>, StructAtom<string>>;
                                if(state != null)
                                {
                                    var exState = this.FSM.StateSet.FirstOrDefault(s => s.KeyName == state.KeyName);
                                    if (exState != null)
                                        state = exState;
                                    value.SourceState = state;
                                }
                            }
                            break;
                        case "input":
                            {
                                value.Input = new StructAtom<string>(childNode.InnerText);
                            }
                            break;
                        case "transitionresults":
                            {
                                for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                                {
                                    var childChildNodes = childNode.ChildNodes[j];
                                    if (childChildNodes.Name.ToLower() == "transitionresult")
                                    {
                                        TransitionResXmlWorker w = new TransitionResXmlWorker();
                                        w.FSM = this.FSM;
                                        w.ParseFromNode(childChildNodes);
                                        if(w.Value is TransitionRes<StructAtom<string>, StructAtom<string>>)
                                            value.destinationStates.Add(w.Value as TransitionRes<StructAtom<string>, StructAtom<string>>);
                                    }
                                }
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
            get { return "Transition"; }
        }

        #endregion
    }
}
