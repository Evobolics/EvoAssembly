using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters
{
	public class ParameterApi<TContainer> : ConversionApiNode<TContainer>, ParameterApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public Type[] GetSystemParameterTypes(ILConversion conversion, Collection<TypeReference> collection)
        {
            Type[] types = new Type[collection.Count];

            int i = 0;

            foreach (var typeReference in collection)
            {
                types[i] = Execution.Types.Ensuring.EnsureToType(conversion, typeReference);

                i++;
            }

            return types;
        }

        public Type[] GetSystemParameterTypes(ILConversion conversion, MethodReference methodReference)
        {
            return GetSystemParameterTypes(conversion, methodReference.Parameters);
        }

        public Type[] GetSystemParameterTypes(ILConversion conversion, List<SemanticRoutineParameterMask_I> parameters)
        {
            Type[] types = new Type[parameters.Count];

            int i = 0;

            foreach (var parameter in parameters)
            {
                types[i] = Execution.Types.Ensuring.EnsureToType(conversion, parameter.ParameterType);

                i++;
            }

            return types;
        }

        public Type[] GetSystemParameterTypes(ILConversion conversion, Collection<ParameterDefinition> parameters)
        {
            Type[] types = new Type[parameters.Count];

            int i = 0;

            foreach (var parameter in parameters)
            {
                types[i] = Execution.Types.Ensuring.EnsureToType(conversion, parameter.ParameterType);

                i++;
            }

            return types;
        }

        public Type[] GetSystemParameterTypes(ILConversion conversion, SemanticTypeMask_I[] methodEntryParameterTypes)
        {
            if (methodEntryParameterTypes == null) return null;

            Type[] types = new Type[methodEntryParameterTypes.Length];

            for (int i = 0; i < types.Length; i++)
            {
                var boundType = (BoundTypeDefinitionMask_I)methodEntryParameterTypes[i];

                

                

                if (boundType.UnderlyingType == null)
                {
                    throw new Exception("Underlying type is null");
                }

                types[i] = boundType.UnderlyingType;
            }

            return types;
        }
    }
}
