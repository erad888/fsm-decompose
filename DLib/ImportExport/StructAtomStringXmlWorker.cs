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


        public static bool SaveInputSeqToFile(IEnumerable<StructAtom<string>> inputs)
        {
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
                        XmlNode rootNode = doc.CreateElement("InputSequence");
                        foreach (var input in inputs)
                        {
                            StructAtomStringXmlWorker w = new StructAtomStringXmlWorker(input);
                            rootNode.AppendChild(w.CreateXmlNode(doc));
                        }
                        doc.AppendChild(rootNode);
                        doc.Save(fi.FullName);
                        result = true;
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Сохранение входной последовательности",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                result = false;
            }

            return result;
        }

        public static IEnumerable<StructAtom<string>> LoadInputSeqFromFile()
        {
            List<StructAtom<string>> result = new List<StructAtom<string>>();

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
                            if (rootNode.Name.ToLower() == "inputsequence")
                            {
                                for(int i = 0; i < rootNode.ChildNodes.Count; ++i)
                                {
                                    var childChildNode = rootNode.ChildNodes[i];
                                    StructAtomStringXmlWorker w = new StructAtomStringXmlWorker();
                                    w.ParseFromNode(childChildNode);
                                    if (w.value != null)
                                        result.Add(w.value);
                                }
                            }
                        }
                        else
                            MessageBox.Show("Файл пуст", "Загрузка входной последовательности",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Файл должен иметь расширение .xml", "Загрузка входной последовательности",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception exc)
            {
                result.Clear();
            }

            return result;
        }
    }
}
