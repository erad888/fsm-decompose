using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using FSM;
using LogicUtils;

namespace ImportExport
{
    public class StatePartitionXmlWorker:IXmlWorker
    {
        public StatePartitionXmlWorker()
        {
        }

        public StatePartitionXmlWorker(Partition<FSMState<StructAtom<string>, StructAtom<string>>> ortPartitionsSet)
        {
            value = ortPartitionsSet;
        }

        public FiniteStateMachine<StructAtom<string>, StructAtom<string>> FSM { get; set; }
        private Partition<FSMState<StructAtom<string>, StructAtom<string>>> value = null;

        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            return CreateXmlNode(doc, NodeName);
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            if (doc == null) throw new ArgumentNullException("doc");

            XmlNode result = doc.CreateElement(nodeName);

            foreach (var block in value)
            {
                var blockNode = doc.CreateElement("Block");
                foreach (var state in block)
                {
                    StateXmlWorker w = new StateXmlWorker(state);
                    blockNode.AppendChild(w.CreateXmlNode(doc));
                }
                result.AppendChild(blockNode);
            }

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");
            if(this.FSM == null) throw new NullReferenceException("FSM");

            value = new Partition<FSMState<StructAtom<string>, StructAtom<string>>>();

            try
            {
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    if (childNode.Name.ToLower() == "block")
                    {
                        HashSet<FSMState<StructAtom<string>, StructAtom<string>>> block = new HashSet<FSMState<StructAtom<string>, StructAtom<string>>>();
                        for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                        {
                            var childChildNode = childNode.ChildNodes[j];
                            StateXmlWorker w = new StateXmlWorker();
                            w.FSM = this.FSM;
                            if (childChildNode.Name == w.NodeName)
                            {
                                w.ParseFromNode(childChildNode);
                                var state = w.Value as FSMState<StructAtom<string>, StructAtom<string>>;
                                if(state != null)
                                {
                                    var exState = FSM.StateSet.First(s => s.KeyName == state.KeyName);
                                    if(exState == null)
                                        state = exState;
                                    block.Add(state);
                                }
                            }
                        }
                        value.Add(block);
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
            get { return "Partition"; }
        }

        #endregion
    }
}
