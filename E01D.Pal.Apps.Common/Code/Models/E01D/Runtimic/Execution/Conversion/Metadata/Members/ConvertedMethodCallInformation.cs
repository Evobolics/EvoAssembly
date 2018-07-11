using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedMethodCallInformation: ConvertedMethodCallInformationMask_I
    {
        public ConvertedTypeDefinition_I CallingType { get; set; }
        BoundTypeDefinitionMask_I BoundMethodCallInformationMask_I.CallingType => CallingType;

        public BoundTypeDefinitionMask_I DeclaringType { get; set; }
        public MethodReference MethodReference { get; set; }
        
    }
}
