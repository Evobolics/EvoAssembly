using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Ensuring.Cecil
{
    public interface CecilApiMask_I
    {
        AssignmentApiMask_I Assignment { get; }

        GatheringApiMask_I Gathering { get; }

        BoundTypeDefinitionMask_I EnsureType(ILConversion conversion, TypeReference input);
    }
}
