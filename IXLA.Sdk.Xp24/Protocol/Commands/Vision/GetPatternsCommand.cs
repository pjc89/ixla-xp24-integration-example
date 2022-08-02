using System.Collections;
using System.IO;

namespace IXLA.Sdk.Xp24.Protocol.Commands.Vision
{
    public class GetPatternsCommand : MachineCommand
    {
        public GetPatternsCommand() : base("getpatterns", false)
        {
        }
    }
}