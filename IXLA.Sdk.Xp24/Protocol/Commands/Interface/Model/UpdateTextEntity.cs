using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model
{
    public class UpdateTextEntity : Entity
    {
        public string Text { get; set; }
        public override void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("entity");
            writer.WriteAttributeString("Name", Name);
            writer.WriteAttributeString("Text", Text);
            writer.WriteEndElement();
        }

        public UpdateTextEntity() : base()
        {
        }
        public UpdateTextEntity(string name, string text) : this()
        {
            Name = name;
            Text = text;
        }
    }
}