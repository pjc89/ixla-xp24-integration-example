using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model
{
    public class ImageEntity : Entity
    {
        public byte[] Image { get; set; }
        public override void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("entity");
            writer.WriteAttributeString("Name", Name);
            writer.WriteAttributeString("Image", Convert.ToBase64String(Image));
            writer.WriteEndElement();
        }

        public ImageEntity() : base()
        {
        }
        public ImageEntity(string name, byte[] imageData) : this()
        {
            Name = name;
            Image = imageData;
        }
    }
}