using System.Globalization;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface
{
    public class MarkLayoutCommand : MachineCommand
    {
        public string Layout { get; set; }
        public double XOffset { get; set; }
        public double YOffset { get; set; }
        public double Angle { get; set; }

        public MarkLayoutCommand() : base("marklayout", true)
        {
        }

        protected override void SerializeAttributes(XmlWriter writer)
        {
            writer.WriteAttributeString("layout", Layout);
            writer.WriteAttributeString("XOffset", XOffset.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("YOffset", YOffset.ToString(CultureInfo.InvariantCulture));
            writer.WriteAttributeString("Angle", Angle.ToString(CultureInfo.InvariantCulture));
        }
    }
}