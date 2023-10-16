using System.Reflection.Emit;
using System;
using System.Xml;
using System.Runtime.InteropServices;
using System.Xml.Serialization;

internal class Program
{
    private static void Main(string[] args)
    {
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.Load("http://www.ecb.int/stats/eurofxref/eurofxref-daily.xml");

        //PrintXMLContent(xmlDoc);
        //WriteToXLM();

    }

    static void PrintXMLContent(XmlDocument xmlDoc)
    {
        foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[2].ChildNodes[0].ChildNodes)
        {
            Console.WriteLine(xmlNode.Attributes["currency"].Value + ": " + xmlNode.Attributes["rate"].Value);
        }
    }

    static void WriteToXLM()
    {
        XmlDocument xmlDoc = new XmlDocument();
        XmlNode rootNode = xmlDoc.CreateElement("users");

        xmlDoc.AppendChild(rootNode);
        XmlNode userNode = xmlDoc.CreateElement("user");
        XmlAttribute attribute = xmlDoc.CreateAttribute("age");
        attribute.Value = "42";
        userNode.Attributes.Append(attribute);

        userNode.InnerText = "John Doe";
        rootNode.AppendChild(userNode);
        userNode = xmlDoc.CreateElement("user");
        attribute = xmlDoc.CreateAttribute("age");
        attribute.Value = "39";

        userNode.Attributes.Append(attribute);
        userNode.InnerText = "Jane Doe";
        rootNode.AppendChild(userNode);

        // saving the file locally
        xmlDoc.Save(@"C:\test-doc.xml");
    }


}