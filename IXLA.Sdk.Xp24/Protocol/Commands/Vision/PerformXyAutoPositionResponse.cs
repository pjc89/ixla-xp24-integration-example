using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Vision
{
    public class PerformXyAutoPositionResponse : MachineResponseBase
    {
        public double XOffset { get; set; }
        public double YOffset { get; set; }
        public int Correlation { get; set; }

        public PerformXyAutoPositionResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            var offsetX = reader.GetAttribute("XOffset") ?? "";
            var offsetY = reader.GetAttribute("YOffset") ?? "";
            var correlation = reader.GetAttribute("Correlation") ?? "";

            if (!string.IsNullOrEmpty(offsetX)) XOffset = double.Parse(offsetX);
            if (!string.IsNullOrEmpty(offsetY)) YOffset = double.Parse(offsetY);
            if (!string.IsNullOrEmpty(correlation)) Correlation = int.Parse(correlation);
        }
    }
}