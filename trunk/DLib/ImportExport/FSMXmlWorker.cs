using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FSM;

namespace ImportExport
{
    public class FSMXmlWorker: IXmlWorker
    {
        public FSMXmlWorker()
        {
            
        }

        public FSMXmlWorker(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            value = fsm;
        }

        private FiniteStateMachine<StructAtom<string>, StructAtom<string>> value = null;

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

            XmlElement element = doc.CreateElement("StateSet");
            foreach (var state in value.StateSet)
            {
                StateXmlWorker worker = new StateXmlWorker(state);
                element.AppendChild(worker.CreateXmlNode(doc));
            }
            result.AppendChild(element);

            element = doc.CreateElement("InputSet");
            foreach (var input in value.InputSet)
            {
                StructAtomStringXmlWorker worker = new StructAtomStringXmlWorker(input);
                element.AppendChild(worker.CreateXmlNode(doc, "Input"));
            }
            result.AppendChild(element);

            element = doc.CreateElement("OutputSet");
            foreach (var output in value.OutputSet)
            {
                StructAtomStringXmlWorker worker = new StructAtomStringXmlWorker(output);
                element.AppendChild(worker.CreateXmlNode(doc, "Output"));
            }
            result.AppendChild(element);

            element = doc.CreateElement("KeyName");
            element.InnerText = value.KeyName;
            result.AppendChild(element);

            StateXmlWorker w = new StateXmlWorker(value.InitialState);
            result.AppendChild(w.CreateXmlNode(doc, "InitialState"));

            element = doc.CreateElement("Transitions");
            foreach (var transition in value.Transitions.Values)
            {
                TransitionXmlWorker worker = new TransitionXmlWorker(transition);
                element.AppendChild(worker.CreateXmlNode(doc));
            }
            result.AppendChild(element);

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");

            value = new FiniteStateMachine<StructAtom<string>, StructAtom<string>>();

            try
            {
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    switch (childNode.Name.ToLower())
                    {
                        case "stateset":
                            {
                                for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                                {
                                    var childChildNode = childNode.ChildNodes[j];
                                    if (childChildNode.Name.ToLower() == "transition")
                                    {
                                        StateXmlWorker w = new StateXmlWorker();
                                        w.FSM = value;
                                        w.ParseFromNode(childChildNode);
                                        var state = w.Value as FSMState<StructAtom<string>, StructAtom<string>>;
                                        if (state != null)
                                            value.AddState(state);
                                    }
                                }
                            }
                            break;
                        case "inputset":
                            {
                                for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                                {
                                    var childChildNode = childNode.ChildNodes[j];
                                    if (childChildNode.Name.ToLower() == "input")
                                    {
                                        StructAtomStringXmlWorker w = new StructAtomStringXmlWorker();
                                        w.ParseFromNode(childChildNode);
                                        var inp = w.Value as StructAtom<string>;
                                        if (inp != null)
                                            value.AddInput(inp);
                                    }
                                }
                            }
                            break;
                        case "outputset":
                            {
                                for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                                {
                                    var childChildNode = childNode.ChildNodes[j];
                                    if (childChildNode.Name.ToLower() == "output")
                                    {
                                        StructAtomStringXmlWorker w = new StructAtomStringXmlWorker();
                                        w.ParseFromNode(childChildNode);
                                        var inp = w.Value as StructAtom<string>;
                                        if (inp != null)
                                            value.AddOutput(inp);
                                    }
                                }
                            }
                            break;
                        
                        case "keyname":
                            value.KeyName = childNode.InnerText;
                            break;
                        case "initialstate":
                            {
                                StateXmlWorker w = new StateXmlWorker();
                                w.FSM = value;
                                w.ParseFromNode(childNode);
                                var state = w.Value as FSMState<StructAtom<string>, StructAtom<string>>;
                                if(state != null)
                                    value.InitialState = state;
                            }
                            break;
                    }
                }

                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    switch (childNode.Name.ToLower())
                    {
                        case "transitions":
                            {
                                for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                                {
                                    var childChildNode = childNode.ChildNodes[j];
                                    if (childChildNode.Name.ToLower() == "transition")
                                    {
                                        TransitionXmlWorker w = new TransitionXmlWorker();
                                        w.FSM = value;
                                        w.ParseFromNode(childChildNode);
                                        var tr = w.Value as Transition<StructAtom<string>, StructAtom<string>>;
                                        if (tr != null)
                                        {
                                            foreach (var destinationState in tr.destinationStates)
                                            {
                                                value.AddOutgoing(tr.SourceState, tr.Input, destinationState.DestState, destinationState.Output, destinationState.Probability);
                                            }
                                            //value.Transitions.Add(tr.ToString(), tr);
                                        }
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
            get { return "FiniteStateMachine"; }
        }

        #endregion
    }
}
