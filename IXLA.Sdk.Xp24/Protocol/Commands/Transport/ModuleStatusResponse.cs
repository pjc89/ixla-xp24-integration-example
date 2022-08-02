using System.Xml;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Transport
{
    public class ModuleStatusResponse : MachineResponseBase
    {
        public bool Laser { get; set; }
        public bool Display { get; set; }
        public bool Interface { get; set; }
        public bool Vision { get; set; }
        public bool Barcode { get; set; }

        public bool All => Laser && Display && Interface && Vision && Barcode;

        public ModuleStatusResponse(MachineCommand command) : base(command)
        {
        }

        public override void DeserializeAttributes(XmlReader reader)
        {
            reader.MoveToElement();
            while (reader.NodeType != XmlNodeType.Element)
                reader.Read();

            var innerElements = reader.ReadSubtree();
            while (innerElements.Read())
            {
                if (innerElements.Name == "module" && innerElements.NodeType == XmlNodeType.Element)
                {
                    var moduleName = innerElements.GetAttribute("name")?.Trim().ToLower();
                    var status = innerElements.GetAttribute("status")?.Trim().ToLower() == "true";
                    switch (moduleName)
                    {
                        case "barcode":
                            Barcode = status;
                            break;
                        case "vision":
                            Vision = status;
                            break;
                        case "laser":
                            Laser = status;
                            break;
                        case "interface":
                            Interface = status;
                            break;
                        case "display":
                            Display = status;
                            break;
                    }
                }
            }
        }
    }
}