using Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
    public interface TypeApiMask_I
    {


       

        EnsuringApiMask_I Ensuring { get; }

	    bool IsConverted(BoundRuntimicModelMask_I boundModel, TypeReference input);


    }
}
