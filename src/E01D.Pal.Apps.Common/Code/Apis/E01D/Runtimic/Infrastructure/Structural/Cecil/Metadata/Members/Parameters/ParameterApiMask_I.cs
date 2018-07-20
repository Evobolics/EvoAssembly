using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters
{
    public interface  ParameterApiMask_I
    {
	    ParameterDefinition Create(ParameterDefinition inputParameter, TypeReference parameterType);
    }
}
