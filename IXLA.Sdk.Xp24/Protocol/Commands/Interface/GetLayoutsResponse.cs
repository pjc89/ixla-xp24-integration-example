using System;
using System.Collections.Generic;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Interface
{
    public class GetLayoutsResponse : MachineResponseBase
    {
        public IEnumerable<string> Layouts { get; set; } = Array.Empty<string>();
        public GetLayoutsResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            var list = reader.GetAttribute("layouts");
            if (string.IsNullOrEmpty(list)) return;
            Layouts = list.Split(";");
        }
    }
}