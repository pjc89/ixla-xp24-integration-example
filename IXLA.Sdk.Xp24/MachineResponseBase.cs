using System.Xml;

namespace IXLA.Sdk.Xp24
{
    public class MachineResponseBase
    {
        public MachineCommand Command { get; }

        public bool Valid { get; private set; }
        public bool Executed { get; private set; }
        public string Error { get; set; }

        public MachineResponseBase(MachineCommand command)
        {
            Command = command;
        }

        /// <summary>
        /// Deserialize Message properties from an XML response
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="isValidation"></param>
        public virtual void Hydrate(XmlReader reader, bool isValidation)
        {
            // isValidation true is used to signal that this is the first message we receive
            // from the server every time we send a command. We expect to receive 
            // <command valid="true/false" ... > plus some attributes in case of sync commands 
            if (isValidation)
            {
                // we do the trim/tolower here because the server serializes the responses
                // in a weird way that breaks standard XmlSerialization for booleans
                // sadly this legacy stuff that we cannot change right now because it would 
                // break existing client implementations.
                Valid = reader.GetAttribute("valid")?.Trim().ToLower() == "true";
                
                // only async send the executed attribute
                // Valid = false for sync commands means the command was not 
                // executed 
                Executed = Valid;
                Error = reader.GetAttribute("error");
                if (!Command.IsAsync) DeserializeAttributes(reader);
                return;
            }

            // read the executed attribute. 
            Executed = reader.GetAttribute("executed")?.Trim().ToLower() == "true";
            Error = reader.GetAttribute("error");
            DeserializeAttributes(reader);
        }

        /// <summary>
        /// Subclasses of MachineResponseBase should override this method to parse
        /// response specific properties
        /// </summary>
        /// <param name="reader"></param>
        public virtual void DeserializeAttributes(XmlReader reader)
        {
        }
    }
}