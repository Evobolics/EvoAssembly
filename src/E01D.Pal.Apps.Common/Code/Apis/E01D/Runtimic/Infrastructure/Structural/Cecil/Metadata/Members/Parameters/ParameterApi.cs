using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Parameters
{
	public class ParameterApi<TContainer> : CecilApiNode<TContainer>, ParameterApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public ParameterDefinition Create(ParameterDefinition inputParameter, TypeReference parameterType)
	    {
		    ParameterDefinition output = new ParameterDefinition(inputParameter.Name, inputParameter.Attributes, parameterType);

			return output;
	    }
    }
}
