using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class ParameterApi<TContainer> : BoundApiNode<TContainer>, ParameterApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
       

        public Type[] GetSystemParameterTypes(BoundRuntimicModelMask_I model, MethodReference methodReference)
        {
            Collection<ParameterDefinition> parameters = methodReference.Parameters;

            Type[] types = new Type[parameters.Count];

            int i = 0;

            foreach (var parameter in parameters)
            {
                types[i] = Execution.Types.Ensuring.EnsureToType(model, parameter.ParameterType);

                i++;
            }

            return types;
        }

       
    }
}
