using PeterSoft.SonarQube.Connector.Models;
using System;
using System.Collections.Generic;
using PeterSoft.SonarQube.Connector.Client;
using System.Xml;
using Newtonsoft.Json;
namespace PeterSoft.SonarQube.Connector.Services
{
    internal class DuplicationsShowService : ServiceBase<Duplicates>, IDuplicationsShowService
    {
        public DuplicationsShowService(IRestClient restClient, IRestParameters restParameters) : base(restClient, restParameters, @"duplications/show")
        {
        }

        public IDuplicationsShowService SetFileKey(string fileKey)
        {
            SetParameter("fileKey", fileKey);
            return this;
        }

        public IDuplicationsShowService SetUUID(string uuid)
        {
            SetParameter("uuid", uuid);
            return this;
        }

        /// <summary>
        /// The response returned by DuplicationsShow is incorrect JSON, but it can be transformed to valid by
        /// first converting it to xml, then creating correct nodes, and finally write it back to JSON
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        protected override string TransFormResponse(string response)
        {
            XmlDocument doc = JsonConvert.DeserializeXmlNode(response, "root");

            var filesSection = doc.GetElementsByTagName("files")[0];
            List<XmlNode> wrongNodes = GatherWrongFileNodes(filesSection);
            CreateCorrectNodes(doc, wrongNodes);
            RemoveWrongFileNodes(filesSection, wrongNodes);
            filesSection.ParentNode.RemoveChild(filesSection);

            return JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented, true);
        }

        private static void RemoveWrongFileNodes(XmlNode filesSection, List<XmlNode> newNodes)
        {
            newNodes.ForEach(c => filesSection.RemoveChild(c));
        }

        private static void CreateCorrectNodes(XmlDocument doc, List<XmlNode> newNodes)
        {
            foreach (XmlNode child in newNodes)
            {
                XmlElement newElement = doc.CreateElement("files");
                foreach (XmlNode node in child.ChildNodes)
                {
                    newElement.AppendChild(node.Clone());
                }
                doc.DocumentElement.AppendChild(newElement);
            }
        }

        private static List<XmlNode> GatherWrongFileNodes(XmlNode filesSection)
        {
            var newNodes = new List<XmlNode>();
            foreach (XmlElement child in filesSection.ChildNodes)
            {
                newNodes.Add(child);
            }

            return newNodes;
        }
    }
}