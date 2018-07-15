using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface  ParameterApiMask_I
    {
        System.Type[] GetSystemParameterTypes(InfrastructureRuntimicModelMask_I conversionModel, MethodReference methodReference);
    }
}
