using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Encoder
{
    public class Transmit2RfIdCommand : MachineCommand
    {
        public byte[] Apdu { get; set; }
        public Transmit2RfIdCommand(byte[] apdu) : base("transmit2rfid", false)
        {
            Apdu = apdu;
        }

        protected override void SerializeAttributes(XmlWriter writer)
        {
            writer.WriteStartAttribute("APDU");
            writer.WriteValue(Convert.ToBase64String(Apdu));
            writer.WriteEndAttribute();
        }
    }
}