using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model
{
    public class UpdateBarcodeEntity : Entity
    {
        public string Code { get; set; }
        public override void Serialize(XmlWriter writer)
        {
            writer.WriteStartElement("entity");
            writer.WriteAttributeString("Name", Name);
            writer.WriteAttributeString("Code", Code);
            writer.WriteEndElement();
        }

        public UpdateBarcodeEntity() : base()
        {
        }
        public UpdateBarcodeEntity(string name, string code) : this()
        {
            Name = name;
            Code = code;
        }
    }
}