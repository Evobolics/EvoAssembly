using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface BoundConstructorCallInformationMask_I: BoundMethodCallInformationMask_I
    {
        BoundTypeDefinitionWithConstructorsMask_I DeclaringTypeWithConstructors { get; }

        

        
    }
}
