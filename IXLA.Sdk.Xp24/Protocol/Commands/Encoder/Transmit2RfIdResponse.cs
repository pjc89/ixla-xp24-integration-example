using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Encoder
{
    public class Transmit2RfIdResponse : MachineResponseBase
    {
        public byte[] ChipReply { get; set; }
        public Transmit2RfIdResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            var chipReply = reader.GetAttribute("ChipReply");
            if (chipReply is null) return;
            ChipReply = Convert.FromBase64String(chipReply);
        }
    }
}