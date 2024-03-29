﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using DecomposeLib;
using FSM;
using LogicUtils;

namespace ImportExport
{
    public class NetXmlWorker:IXmlWorker
    {
        public NetXmlWorker()
        {
        }

        public NetXmlWorker(FSMNet<StructAtom<string>, StructAtom<string>> net)
        {
            value = net;
        }

        FSMNet<StructAtom<string>, StructAtom<string>> value = null;

        #region IXmlWorker Members

        public XmlNode CreateXmlNode(XmlDocument doc)
        {
            return CreateXmlNode(doc, NodeName);
        }

        public XmlNode CreateXmlNode(XmlDocument doc, string nodeName)
        {
            if (doc == null) throw new ArgumentNullException("doc");

            XmlNode result = doc.CreateElement(nodeName);
            
            FSMXmlWorker w1 = new FSMXmlWorker(value.FSM);
            result.AppendChild(w1.CreateXmlNode(doc, "FSM"));

            var partitionsNode = doc.CreateElement("OrtPartitionsSet");
            foreach (var partition in value.DecomposeAlg.OrtPartitionsSet)
            {
                StatePartitionXmlWorker w2 = new StatePartitionXmlWorker(partition);
                partitionsNode.AppendChild(w2.CreateXmlNode(doc));
            }
            result.AppendChild(partitionsNode);

            return result;
        }

        public void ParseFromNode(XmlNode node)
        {
            if (node == null) throw new ArgumentNullException("node");

            try
            {
                for (int i = 0; i < node.ChildNodes.Count; ++i)
                {
                    var childNode = node.ChildNodes[i];
                    if (childNode.Name.ToLower() == "fsm")
                    {
                        FSMXmlWorker w = new FSMXmlWorker();
                        w.ParseFromNode(childNode);
                        var fsm = w.Value as FiniteStateMachine<StructAtom<string>, StructAtom<string>>;
                        if(fsm != null)
                            value = new FSMNet<StructAtom<string>, StructAtom<string>>(fsm);

                        break;
                    }
                }

                if (value != null)
                {
                    for (int i = 0; i < node.ChildNodes.Count; ++i)
                    {
                        var childNode = node.ChildNodes[i];
                        if (childNode.Name.ToLower() == "ortpartitionsset")
                        {
                            for (int j = 0; j < childNode.ChildNodes.Count; ++j)
                            {
                                var childChildNode = childNode.ChildNodes[j];
                                StatePartitionXmlWorker w = new StatePartitionXmlWorker();
                                w.FSM = value.FSM;

                                if (childChildNode.Name == w.NodeName)
                                {
                                    w.ParseFromNode(childChildNode);
                                    var partition = w.Value as Partition<FSMState<StructAtom<string>, StructAtom<string>>>;
                                    if (partition != null)
                                    {
                                        if (value.DecomposeAlg == null)
                                            value.DecomposeAlg = new DecompositionAlgorithm<StructAtom<string>, StructAtom<string>>(value.FSM);

                                        value.DecomposeAlg.AddPI(partition);
                                    }
                                }
                            }
                            break;
                        }
                    }

                    if (value.DecomposeAlg != null)
                        value = value.DecomposeAlg.Solve();
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
            get { return "Net"; }
        }

        #endregion


        public static bool SaveNetToFile(FSMNet<StructAtom<string>, StructAtom<string>> net)
        {
            if (net == null) throw new ArgumentNullException("net");

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
                        NetXmlWorker w = new NetXmlWorker(net);
                        doc.AppendChild(w.CreateXmlNode(doc));
                        doc.Save(fi.FullName);
                        result = true;
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Сохранение сети",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                result = false;
            }

            return result;
        }

        public static FSMNet<StructAtom<string>, StructAtom<string>> LoadNetFromFile()
        {
            FSMNet<StructAtom<string>, StructAtom<string>> result = null;

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
                            NetXmlWorker w = new NetXmlWorker();
                            if (rootNode.Name == w.NodeName)
                            {
                                w.ParseFromNode(rootNode);
                                result = w.value;
                            }
                            else
                                MessageBox.Show("Файл содержит некоррекные данные", "Загрузка сети",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                            MessageBox.Show("Файл пуст", "Загрузка сети",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Загрузка сети",
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
