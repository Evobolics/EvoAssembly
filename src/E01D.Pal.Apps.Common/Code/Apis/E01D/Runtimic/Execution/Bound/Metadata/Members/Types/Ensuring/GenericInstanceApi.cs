using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class GenericApi<TContainer> : BoundApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type type)
        {
            BoundTypeDefinition bound = Types.Creation.Create(semanticModel, input, type);

            Type[] typeArgumentTypes = Members.TypeArguments.Building.Build(semanticModel, bound, type);

	        bool hasGenericParameters = HasGenericParameters(typeArgumentTypes);

            var blueprint = EnsureGenericBlueprint(semanticModel, bound);

	        BoundGenericTypeDefinition_I genericBlueprint = null;

			if (blueprint != null)
	        {
		        genericBlueprint = (BoundGenericTypeDefinition_I) blueprint;

		        if (IfAlreadyCreatedReturn(genericBlueprint, typeArgumentTypes, out SemanticTypeDefinitionMask_I ensure)) return ensure;

		        bound.UnderlyingType = Binding.MakeGenericType(blueprint, typeArgumentTypes);

		        genericBlueprint.Instances.Add((BoundGenericTypeDefinitionMask_I)bound);
			}
			else
			{
				bound.UnderlyingType = type;
			}

	        if (hasGenericParameters)
	        {
				Fields.Building.Generic.BuildFields_WithGenericTypeParameters(semanticModel, bound, genericBlueprint); 

			}
	        else
	        {
		        Fields.Building.Generic.BuildFields(semanticModel, bound);
			}

            

            

            return bound;
        }

	    public BoundTypeDefinitionMask_I EnsureGenericBlueprint(BoundRuntimicModelMask_I semanticModel, BoundTypeDefinition bound)
	    {
		    if (!bound.IsGeneric()) return null;

		    var generic = (BoundGenericTypeDefinition_I)bound;

		    

		    TypeDefinition typeDefinition = Types.GenericInstances.GetElementType(semanticModel, bound);
			

		    var genericTypeDefinition = bound.UnderlyingType.GetGenericTypeDefinition();

		    var semanticBlueprint = Types.Ensuring.Ensure(semanticModel, typeDefinition, genericTypeDefinition);

		    if (!(semanticBlueprint is BoundGenericTypeDefinitionMask_I boundBlueprint))
		    {
			    throw new Exception("When creating a conversion model, the base type needs to be a bound type.");
		    }

		    generic.Blueprint = boundBlueprint;

		    return boundBlueprint;
	    }

		private bool HasGenericParameters(Type[] typeArgumentTypes)
	    {
		    for (int i = 0; i < typeArgumentTypes.Length; i++)
		    {
			    var typeArgument = typeArgumentTypes[i];

			    if (typeArgument.IsGenericParameter) return true;
		    }

		    return false;
	    }

	    private bool IfAlreadyCreatedReturn(BoundGenericTypeDefinition_I genericBlueprint, Type[] typeArgumentTypes,out SemanticTypeDefinitionMask_I ensure)
        {
            for (int i = 0; i < genericBlueprint.Instances.Count; i++)
            {
                var instance = genericBlueprint.Instances[i];

                var currentInstance = (BoundGenericTypeDefinition_I) instance;

                bool found = true;

                for (int j = 0; j < currentInstance.TypeArguments.All.Count; j++)
                {
                    var underlyingType = ((BoundTypeDefinitionMask_I) currentInstance.TypeArguments.All[j]).UnderlyingType;

                    if (!ReferenceEquals(underlyingType, typeArgumentTypes[j]))
                    {
                        found = false;

                        break;
                    }
                }

                if (found)
                {
                    ensure = currentInstance;
                    return true;   
                }
            }
            ensure = null;
            return false;
        }
    }
}
