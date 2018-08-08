using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
    public interface TypeApiMask_I
    {


       

        EnsuringApiMask_I Ensuring { get; }

	    bool IsConverted(RuntimicSystemModel boundModel, TypeReference input);


        bool ContainsGenericMethodParameters(RuntimicSystemModel boundModel, GenericInstanceType genericInstance);
        int GetToken(BoundTypeDefinitionMask_I boundType);
    }
}
