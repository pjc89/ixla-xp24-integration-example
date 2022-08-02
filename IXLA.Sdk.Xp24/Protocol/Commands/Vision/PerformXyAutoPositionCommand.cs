using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Vision
{
    public class PerformXyAutoPositionCommand : MachineCommand
    {
        public string PatternName { get; set; }
        public PerformXyAutoPositionCommand() : base("autoposition", false)
        {
        }

        protected override void SerializeAttributes(XmlWriter writer)
        {
            writer.WriteAttributeString("PatternName", PatternName);
        }
    }
}