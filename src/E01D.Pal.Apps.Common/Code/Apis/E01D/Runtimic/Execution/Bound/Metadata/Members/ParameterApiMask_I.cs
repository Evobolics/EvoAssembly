using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
    public interface  ParameterApiMask_I
    {
        System.Type[] GetSystemParameterTypes(RuntimicSystemModel conversionModel, TypeReference typeReference, MethodReference methodReference);
    }
}
