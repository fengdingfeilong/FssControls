using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Wpf.Controls.Demo
{
    public class ModuleHelper
    {
        private static List<ModuleInfo> BuildModel(XmlNodeList nodes)
        {
            var result = new List<ModuleInfo>();
            if (nodes == null || nodes.Count == 0)
                return result;
            foreach (XmlNode node in nodes)
            {
                var model = new ModuleInfo();
                if (node.Attributes["MenuName"] != null)
                    model.MenuName = node.Attributes["MenuName"].Value;
                if (node.Attributes["AssemblyFile"] != null)
                    model.AssemblyFile = node.Attributes["AssemblyFile"].Value;
                if (node.Attributes["ClassName"] != null)
                    model.ClassName = node.Attributes["ClassName"].Value;
                if (node.Attributes["StartMethod"] != null)
                    model.StartMethod = node.Attributes["StartMethod"].Value;
                model.ModuleChildren.AddRange(BuildModel(node.ChildNodes));
                result.Add(model);
            }
            return result;
        }

        public static List<ModuleInfo> GetModuleInfo()
        {
            if (File.Exists("ModuleConfig.xml"))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("ModuleConfig.xml");
                var root = doc.DocumentElement;
                var modules = BuildModel(root.ChildNodes);
                return modules;
            }
            return null;
        }

    }
}
