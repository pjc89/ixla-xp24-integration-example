#nullable enable
using System;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Status
{
    public class MachineStatusResponse : MachineResponseBase
    {
        public LaserStatus LaserStatus { get; set; }
        public InterfaceStatus InterfaceStatus { get; set; }
        public TransportStatus TransportStatus { get; set; }
        
        public MachineStatusResponse(MachineCommand command) : base(command)
        {
        }
        
        public override void DeserializeAttributes(XmlReader reader)
        {
            if (Enum.TryParse<TransportStatus>(reader.GetAttribute("transportstatus") ?? "", true, out var transportStatus))
                TransportStatus = transportStatus;
            if (Enum.TryParse<LaserStatus>(reader.GetAttribute("laserstatus") ?? "", true, out var laserStatus))
                LaserStatus = laserStatus;
            if (Enum.TryParse<InterfaceStatus>(reader.GetAttribute("interfacestatus") ?? "", true, out var interfaceStatus))
                InterfaceStatus = interfaceStatus;
        }
    }
}