using System.Collections.Generic;
using System.IO;
using System.Xml;
using IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface
{
    public class UpdateDocumentCommand : MachineCommand
    {
        public IEnumerable<Entity> Entities { get; set; }

        public UpdateDocumentCommand(IEnumerable<Entity> entities) : base("updatedocument", true)
        {
            Entities = entities;
        }

        public override string Serialize()
        {
            using var stringWriter = new StringWriter();
            using var xmlWriter = new XmlTextWriter(stringWriter);

            xmlWriter.WriteStartElement("command");
            xmlWriter.WriteAttributeString("name", Name);

            foreach (var e in Entities)
                e.Serialize(xmlWriter);

            xmlWriter.WriteFullEndElement();

            stringWriter.Flush();
            return stringWriter.ToString();
        }
    }
}