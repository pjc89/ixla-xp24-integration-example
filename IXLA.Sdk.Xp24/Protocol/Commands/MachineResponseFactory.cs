using System;
using System.Collections.Generic;
using IXLA.Sdk.Xp24.Protocol.Commands.Encoder;
using IXLA.Sdk.Xp24.Protocol.Commands.Interface;
using IXLA.Sdk.Xp24.Protocol.Commands.Status;
using IXLA.Sdk.Xp24.Protocol.Commands.Transport;

namespace IXLA.Sdk.Xp24.Protocol.Commands
{
    public class MachineResponseFactory
    {
        private static readonly Dictionary<Type, Type> _commandResponseMap = new();
        static MachineResponseFactory()
        {
            _commandResponseMap.Add(typeof(ResetCommand), typeof(ResetResponse));
            _commandResponseMap.Add(typeof(MachineStatusCommand), typeof(MachineStatusResponse));

            _commandResponseMap.Add(typeof(Connect2RfIdCommand), typeof(Connect2RfIdResponse));
            _commandResponseMap.Add(typeof(Transmit2RfIdCommand), typeof(Transmit2RfIdResponse));
            _commandResponseMap.Add(typeof(LoadPassportCommand), typeof(LoadPassportResponse));
            _commandResponseMap.Add(typeof(EjectCommand), typeof(EjectResponse));

            _commandResponseMap.Add(typeof(GetLayoutsCommand), typeof(GetLayoutsResponse));
            _commandResponseMap.Add(typeof(LoadDocumentCommand), typeof(LoadDocumentResponse));
            _commandResponseMap.Add(typeof(MarkLayoutCommand), typeof(MarkLayoutResponse));
        }
    }
}