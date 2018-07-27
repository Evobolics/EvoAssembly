using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedRoutineMask_I:ConvertedMemberMask_I, BoundRoutineDefinitionMask_I
    {
        //MethodReference MethodReference { get; }
    }
}
