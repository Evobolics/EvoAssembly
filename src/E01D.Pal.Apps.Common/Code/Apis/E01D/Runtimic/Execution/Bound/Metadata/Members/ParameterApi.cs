using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members
{
	public class ParameterApi<TContainer> : BoundApiNode<TContainer>, ParameterApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public Type[] GetSystemParameterTypes(BoundRuntimicModelMask_I model, Mono.Collections.Generic.Collection<TypeReference> collection)
        {
            Type[] types = new Type[collection.Count];

            int i = 0;

            foreach (var typeReference in collection)
            {
                // The issue is that you do not know if the type really needs to be converted type.  Consider three assemblies:
                // Assembly A references Assembly B which references Assembly C
                // A - Converted.  B- Not Converted - C - Converted.
                types[i] = Models.Types.ResolveToType(model, typeReference);

                // NOTE THIS METHOD SHOULD BE IN THE FUTURE:
                //-----------------------------------------------
                // model.Container.Api.Models.Types.ResolveToType(model, typeReference);

                // Notice the reference to the Container.Api.
                // A Conversion container is a binding container.  Just has more features.  They are not nested containers.
                //-----------------------------------------------

                i++;
            }

            return types;
        }

        public Type[] GetSystemParameterTypes(BoundRuntimicModelMask_I model, MethodReference methodReference)
        {
            return GetSystemParameterTypes(model, methodReference.Parameters);
        }

        public Type[] GetSystemParameterTypes(BoundRuntimicModelMask_I model, Mono.Collections.Generic.Collection<ParameterDefinition> parameters)
        {
            Type[] types = new Type[parameters.Count];

            int i = 0;

            foreach (var parameter in parameters)
            {
                types[i] = Models.Types.ResolveToType(model, parameter.ParameterType);

                i++;
            }

            return types;
        }
    }
}
