using System.IO;
using System.Xml;

namespace IXLA.Sdk.Xp24
{
    public class MachineCommand
    {
        public bool IsAsync { get; }
        public string Name { get; }

        public MachineCommand(string name, bool isAsync = false)
        {
            IsAsync = isAsync;
            Name = name;
        }

        public virtual string Serialize()
        {
            using var stringWriter = new StringWriter();
            using var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartElement("command");
            xmlWriter.WriteAttributeString("name", Name);
            SerializeAttributes(xmlWriter);
            xmlWriter.WriteEndElement();

            stringWriter.Flush();
            return stringWriter.ToString();
        }

        protected virtual void SerializeAttributes(XmlWriter writer)
        {
        }
    }
}