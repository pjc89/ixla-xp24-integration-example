using System;
using System.Collections.Generic;
using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Vision
{
    public class GetPatternsResponse : MachineResponseBase
    {
        public IEnumerable<string> Patterns { get; set; } = Array.Empty<string>();

        public GetPatternsResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            var patternsList = reader.GetAttribute("patterns")?.Trim();
            if (patternsList is null) return;
            Patterns = patternsList.Split(";");
        }
    }
}