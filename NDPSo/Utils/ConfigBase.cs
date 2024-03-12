using System;
using System.IO;
using System.Xml;

namespace NDPSo.Utils
{
    public class ConfigBase
    {
        private const string ROOTNODE = "/";
        private const string SECTION_ELEMENTNAME = "section";
        private const string SECTION_ATTRIBUTENAME = "name";
        private const string ENTRY_ELEMENTNAME = "entry";
        private const string ADD_ELEMENTNAME = "add";
        private const string ADD_ATTRIBUTEKEY = "key";
        private const string ADD_ATTRIBUTEVALUE = "value";
        private ConfigBase.Attribute _attribute;
        private DateTime _lastWriteTime = DateTime.MinValue;    
        private XmlDocument _doc;
        private readonly string _configFilePath = string.Empty;
        private readonly string _configPath = string.Empty;

        public ConfigBase.Attribute Attributes
        {
            get
            {
                if (this._attribute == null)
                    this._attribute = new ConfigBase.Attribute();
                this._attribute.ConfigXmlDoc = this.GetLatestDoc();
                this._attribute.ConfigFilePath = this._configFilePath;
                return this._attribute;
            }
        }

        public string this[string sectionName, string entryAttributeKey, string entryAttributeKeyValue]
        {
            get => ConfigBase.ExecuteXMLNode(this.GetLatestDoc(), "/", "section", "name", sectionName, "entry", entryAttributeKey, entryAttributeKeyValue).InnerText;
            set
            {
                ConfigBase.ExecuteXMLNode(this.GetLatestDoc(), "/", "section", "name", sectionName, "entry", entryAttributeKey, entryAttributeKeyValue).InnerText = value;
                ConfigBase.SaveDoc(this._doc, this._configFilePath);
            }
        }

        public string this[string key]
        {
            get => ConfigBase.ExecuteAttributeValue(this.GetLatestDoc(), "/" + this._configPath, "value", "add", nameof(key), key).InnerText;
            set
            {
                string encryptedValue = value;
                ConfigBase.ExecuteAttributeValue(this.GetLatestDoc(), "/" + this._configPath, nameof(value), "add", nameof(key), key).InnerText = encryptedValue;
                ConfigBase.SaveDoc(this._doc, this._configFilePath);
            }
        }

        public ConfigBase(string configFileName, string configPath)
        {
            //this._configFilePath = Path.Combine(Directory.GetCurrentDirectory(), configFileName);
            string configFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MachineXL");
            this._configFilePath = Path.Combine(configFolderPath, configFileName);
            this._configPath = configPath;
        }

        private static XmlNode GetSingleNode(XmlDocument xmlDoc, string rootElement, params string[] trioCondList)
        {
            string xpath = rootElement;
            if (trioCondList.Length % 3 != 0)
                throw new System.Exception("the params are invalid.");
            int num1;
            for (int index = 0; index < trioCondList.Length; index = num1 + 1)
            {
                int num2;
                xpath += string.Format("/{0}[@{1}='{2}']", (object)trioCondList[index], (object)trioCondList[num2 = index + 1], (object)trioCondList[num1 = num2 + 1]);
            }
            return xmlDoc.SelectSingleNode(xpath);
        }

        private static XmlNode ExecuteXMLNode(
          XmlDocument xmlDoc,
          string rootElement,
          params string[] trioCondList)
        {
            try
            {
                return ConfigBase.GetSingleNode(xmlDoc, rootElement, trioCondList) ?? throw new System.Exception("Error execute node");
            }
            catch (NullReferenceException ex)
            {
                throw new System.Exception(string.Format("Cannot find the node in config file."));
            }
            catch
            {
                throw new System.Exception("Error reading configuration file. ");
            }
        }

        private static XmlAttribute ExecuteAttributeValue(
          XmlDocument xmlDoc,
          string rootElement,
          string attributeName,
          params string[] trioCondList)
        {
            try
            {
                XmlNode xmlNode = ConfigBase.ExecuteXMLNode(xmlDoc, rootElement, trioCondList);
                if (xmlNode.Attributes[attributeName] == null)
                    throw new System.Exception("Error execute attribute");
                return xmlNode.Attributes[attributeName];
            }
            catch (NullReferenceException ex)
            {
                throw new System.Exception(string.Format("Cannot find the attribute in config file."));
            }
            catch
            {
                throw new System.Exception(string.Format("Error reading configuration file. "));
            }
        }

        private static void SaveDoc(XmlDocument xmlDoc, string configFilePath)
        {
            try
            {
                xmlDoc?.Save(configFilePath);
            }
            catch
            {
                throw new System.Exception("Error writing configuration file.");
            }
        }

         private XmlDocument GetLatestDoc()
         {
             if (File.Exists(this._configFilePath))
             {
                 FileInfo fileInfo = new FileInfo(this._configFilePath);
                 if (this._lastWriteTime != fileInfo.LastWriteTime)
                 {
                     XmlDocument xmlDocument = new XmlDocument();
                     xmlDocument.Load(this._configFilePath);
                     this._lastWriteTime = fileInfo.LastWriteTime;
                     this._doc = xmlDocument;
                 }
             }
             return this._doc;
         }

        
        public class Attribute
        {
            private XmlDocument _configXmlDoc;
            private string _configFilePath;

            public XmlDocument ConfigXmlDoc
            {
                get => this._configXmlDoc;
                set => this._configXmlDoc = value;
            }

            public string ConfigFilePath
            {
                get => this._configFilePath;
                set => this._configFilePath = value;
            }

            public string this[string sectionName, string attributeName]
            {
                get => ConfigBase.ExecuteAttributeValue(this._configXmlDoc, "/", attributeName, "section", "name", sectionName).InnerText;
                set
                {
                    ConfigBase.ExecuteAttributeValue(this._configXmlDoc, "/", attributeName, "section", "name", sectionName).InnerText = value;
                    ConfigBase.SaveDoc(this._configXmlDoc, this._configFilePath);
                }
            }

            public string this[
              string sectionName,
              string entryAttributeKey,
              string entryAttributeKeyValue,
              string entryAttributeName]
            {
                get => ConfigBase.ExecuteAttributeValue(this._configXmlDoc, "/", entryAttributeName, "section", "name", sectionName, "entry", entryAttributeKey, entryAttributeKeyValue).InnerText;
                set
                {
                    ConfigBase.ExecuteAttributeValue(this._configXmlDoc, "/", entryAttributeName, "section", "name", sectionName, "entry", entryAttributeKey, entryAttributeKeyValue).InnerText = value;
                    ConfigBase.SaveDoc(this._configXmlDoc, this._configFilePath);
                }
            }
        }
    }
}
