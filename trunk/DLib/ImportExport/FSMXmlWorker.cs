using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
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


        public static bool SaveFSMToFile(FiniteStateMachine<StructAtom<string>, StructAtom<string>> fsm)
        {
            if (fsm == null) throw new ArgumentNullException("fsm");

            bool result = false;

            try
            {
                var sfd = new SaveFileDialog();
                sfd.Filter = "xml-файл (*.xml)|*.xml";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var fi = new FileInfo(sfd.FileName);
                    if (fi.Extension == ".xml")
                    {
                        XmlDocument doc = new XmlDocument();
                        FSMXmlWorker w = new FSMXmlWorker(fsm);
                        doc.AppendChild(w.CreateXmlNode(doc));
                        doc.Save(fi.FullName);
                        result = true;
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Сохранение автомата",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                result = false;
            }

            return result;
        }

        public static FiniteStateMachine<StructAtom<string>, StructAtom<string>> LoadFSMFromFile()
        {
            FiniteStateMachine<StructAtom<string>, StructAtom<string>> result = null;

            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "xml-файл (*.xml)|*.xml";
                ofd.Multiselect = false;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var fi = new FileInfo(ofd.FileName);
                    if (fi.Extension == ".xml")
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(fi.FullName);
                        if (doc.ChildNodes.Count > 0)
                        {
                            var rootNode = doc.ChildNodes[0];
                            FSMXmlWorker w = new FSMXmlWorker();
                            if (rootNode.Name == w.NodeName)
                            {
                                w.ParseFromNode(rootNode);
                                result = w.value;
                            }
                            else
                                MessageBox.Show("Файл содержит некорректные данные", "Загрузка автомата",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Файл пуст", "Загрузка автомата",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Загрузка автомата",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                result = null;
            }

            return result;
        }
    }
}
