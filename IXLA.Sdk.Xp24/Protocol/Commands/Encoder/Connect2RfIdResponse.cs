using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Encoder
{
    public class Connect2RfIdResponse : MachineResponseBase
    {
        public byte[] Atr { get; set; }
        public Connect2RfIdResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            var atr = reader.GetAttribute("ATR");
            if (string.IsNullOrEmpty(atr)) return;
            Atr = Convert.FromBase64String(atr);
        }
    }
}