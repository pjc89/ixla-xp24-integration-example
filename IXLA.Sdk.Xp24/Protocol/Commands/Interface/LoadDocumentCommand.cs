using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface
{
    public class LoadDocumentCommand : MachineCommand
    {
        public string TemplateName { get; set; }
        public string Template { get; set; }
        public int Rotation { get; set; }

        public LoadDocumentCommand(string layoutName, byte[] data, int rotation = default) : base("loaddocument", true)
        {
            TemplateName = layoutName;
            Template = Convert.ToBase64String(data);
            Rotation = rotation;
        }

        protected override void SerializeAttributes(XmlWriter writer)
        {
            writer.WriteAttributeString(
                localName: "Template",
                value: Template
            );

            writer.WriteAttributeString(
                localName: "TemplateName",
                value: TemplateName
            );

            if (Rotation != default)
            {
                writer.WriteAttributeString(
                    localName: "Rotation",
                    value: Rotation.ToString()
                );
            }
        }
    }
}