using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering
{
    public interface DotNetApiMask_I
    {
        //AssignmentApiMask_I Assignment { get; }

        DotNet.GatheringApiMask_I Gathering { get; }

        BoundTypeDefinitionMask_I EnsureType(ILConversion conversion, System.Type input);

    }
}
