using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface.Model
{
    public abstract class Entity
    {
        public string Name { get; set; }
        public abstract void Serialize(XmlWriter writer);
    }
}