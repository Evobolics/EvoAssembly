using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundMethodCallInformationMask_I
    {
        BoundTypeDefinitionMask_I CallingType { get;  }
        BoundTypeDefinitionMask_I DeclaringType { get;  }
        MethodReference MethodReference { get;  }
        
    }
}
