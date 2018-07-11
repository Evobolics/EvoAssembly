using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedConstructorCallInformationMask_I: ConvertedMethodCallInformationMask_I, BoundConstructorCallInformationMask_I
    {
        new ConvertedTypeDefinition_I CallingType { get;  }
       
     
        
    }
}
