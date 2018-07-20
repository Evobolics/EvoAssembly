using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
    public class GenericParameterApi<TContainer> : ConversionApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, GenericParameter parameter)
        {
            

            if (parameter.DeclaringType != null)
            {
				var resolutionName = Types.Naming.GetResolutionName(parameter.DeclaringType);

	            var semanticType = Models.Types.GetOrThrow(conversion.Model, resolutionName);

	            if (!semanticType.IsGeneric())
	            {
		            throw new Exception("Expected the resolved semantic type to be a generic type.");
	            }

	            SemanticGenericTypeDefinitionMask_I generic = (SemanticGenericTypeDefinitionMask_I)semanticType;

	            if (!generic.TypeParameters.ByName.TryGetValue(parameter.Name,
		            out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
	            {
		            throw new Exception($"Expected the generic type to have a type parameter named {parameter.Name}.");
	            }

	            if (!semanticTypeParameter.IsBound())
	            {
		            throw new Exception("Expected the generic parameter type to be a bound type.");
	            }

	            return (BoundTypeDefinitionMask_I)semanticTypeParameter;
			}
            else
            {
				if (!(parameter.DeclaringMethod is MethodDefinition methodDefinition))
	            {
		            throw new Exception("Expected a method definition");
	            }

	            var declaringType = methodDefinition.DeclaringType;

	            var resolutionName = Types.Naming.GetResolutionName(declaringType);

	            var semanticType = Models.Types.GetOrThrow(conversion.Model, resolutionName);

	            if (!(semanticType is BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods))
	            {
		            throw new Exception("Trying to add a method to a type that does not support methods.");
	            }

	            var method = Binding.Metadata.Members.Methods.Getting.FindMethodByDefinition(conversion.Model, convertedTypeWithMethods, methodDefinition);

	            if (!method.TypeParameters.ByName.TryGetValue(parameter.Name,out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
	            {
		            throw new Exception($"Expected the generic method to have a type parameter named {parameter.Name}.");
	            }

	            if (!semanticTypeParameter.IsBound())
	            {
		            throw new Exception("Expected the generic parameter type to be a bound type.");
	            }

	            return (BoundTypeDefinitionMask_I)semanticTypeParameter;

				
			}
		}
    }
}
