using System;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
    public class GenericParameterApi<TContainer> : ConversionApiNode<TContainer>, GenericParameterApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, BoundEnsureContext context)
			
        {
	        GenericParameter parameter = (GenericParameter)context.TypeReference;
			
			if (parameter.DeclaringType != null)
            {
	            SemanticTypeMask_I semanticDeclaringType;

	            if (context.DeclaringType != null)
	            {
		            semanticDeclaringType = context.DeclaringType;
	            }
	            else
	            {
		            var resolutionName = Types.Naming.GetResolutionName(parameter.DeclaringType);

					semanticDeclaringType = Models.Types.GetOrThrow(boundModel, resolutionName);
	            }

	            if (!(semanticDeclaringType is SemanticGenericTypeDefinitionMask_I genericDeclaringType))
	            {
		            throw new Exception($"Expected the resolved semantic type to be a generic type of {typeof(SemanticGenericTypeDefinitionMask_I)}.");
	            }

	            if (genericDeclaringType.TypeParameters.ByName.TryGetValue(parameter.Name, out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
	            {
					if (!semanticTypeParameter.IsBound())
		            {
			            throw new Exception("Expected the generic parameter type to be a bound type.");
		            }

		            return (BoundTypeDefinitionMask_I)semanticTypeParameter;
				}

	            var typeParameter = CreateGenericParameter(genericDeclaringType);

				typeParameter.Attributes = Cecil.Metadata.Members.GenericParameters.GetTypeParameterAttributes(parameter);
	            typeParameter.Name = parameter.Name;
	            typeParameter.FullName = parameter.FullName;
	            typeParameter.Position = parameter.Position;
	            typeParameter.TypeParameterKind = GetTypeParameterKind(parameter.Type);
	            typeParameter.Definition = parameter;
	            typeParameter.SourceTypeReference = parameter;

	            //genericDeclaringType.TypeParameters.ByName.Add(parameter.Name, typeParameter);

				return typeParameter;
			}
            else
            {
				if (!(parameter.DeclaringMethod is MethodDefinition methodDefinition))
	            {
		            throw new Exception("Expected a method definition");
	            }

	            TypeReference declaringType;

                if (methodDefinition.DeclaringType != null)
                {
	                declaringType = methodDefinition.DeclaringType;
                }
	            else
	            {
		            if (context.MethodReference == null)
		            {
			            
		            }

		            declaringType = context.MethodReference.DeclaringType;
	            }


	            var resolutionName = Types.Naming.GetResolutionName(declaringType);

                var semanticType = Models.Types.GetOrThrow(boundModel, resolutionName);

	            if (!(semanticType is BoundTypeDefinitionWithMethodsMask_I convertedTypeWithMethods))
	            {
		            throw new Exception("Trying to add a method to a type that does not support methods.");
	            }

	            var method = Bound.Metadata.Members.Methods.Getting.FindMethodByDefinition(boundModel, convertedTypeWithMethods, methodDefinition);

	            if (method.TypeParameters.ByName.TryGetValue(parameter.Name,out SemanticGenericParameterTypeDefinitionMask_I semanticTypeParameter))
	            {
					if (!semanticTypeParameter.IsBound())
		            {
			            throw new Exception("Expected the generic parameter type to be a bound type.");
		            }

		            return (BoundTypeDefinitionMask_I)semanticTypeParameter;
				}

	            var typeParameter = CreateGenericParameter(semanticType);

	            typeParameter.Attributes = Cecil.Metadata.Members.GenericParameters.GetTypeParameterAttributes(parameter);
	            typeParameter.Name = parameter.Name;
	            typeParameter.FullName = parameter.FullName;
	            typeParameter.Position = parameter.Position;
	            typeParameter.TypeParameterKind = GetTypeParameterKind(parameter.Type);
	            typeParameter.Definition = parameter;
	            typeParameter.SourceTypeReference = parameter;
	            typeParameter.DeclaringTypeDefinitionEntry = convertedTypeWithMethods;

	            //method.TypeParameters.ByName.Add(parameter.Name, typeParameter);

	            return typeParameter;
            }
		}

	    private static ExecutionTypeParameterDefinition_I CreateGenericParameter(SemanticTypeMask_I genericDeclaringType)
	    {
		    if (genericDeclaringType.IsConverted())
		    {
			    return new ConvertedGenericParameterTypeDefinition();
		    }
		    else
		    {
			    return new BoundGenericParameterTypeDefinition();
		    }
		    
	    }

	    private TypeParameterKind GetTypeParameterKind(GenericParameterType type)
	    {
		    switch (type)
		    {
			    case GenericParameterType.Type:
				    return TypeParameterKind.Type;
			    case GenericParameterType.Method:
				    return TypeParameterKind.Method;
			    default:
			    {
				    throw new Exception(
					    $"Expected either a type parameter kind of type or method, but not {type.ToString()}");
			    }
		    }
	    }
	}
}
