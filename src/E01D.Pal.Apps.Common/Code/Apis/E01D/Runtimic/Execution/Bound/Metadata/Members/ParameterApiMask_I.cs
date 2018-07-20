using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface  ParameterApiMask_I
    {
        System.Type[] GetSystemParameterTypes(BoundRuntimicModelMask_I conversionModel, MethodReference methodReference);
    }
}
