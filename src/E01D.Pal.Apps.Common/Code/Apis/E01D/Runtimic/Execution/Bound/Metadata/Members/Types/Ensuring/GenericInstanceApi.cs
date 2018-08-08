using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
    public class GenericApi<TContainer> : BoundApiNode<TContainer>, GenericApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		

	    public SemanticTypeDefinitionMask_I Ensure(RuntimicSystemModel semanticModel, GenericInstanceType input, BoundTypeDefinitionMask_I declaringType)
        {
	        

            var typeArguments = Members.TypeArguments.Building.Build(semanticModel, input);

            var blueprint = (BoundGenericTypeDefinitionMask_I)Execution.Types.Ensuring.EnsureBound(semanticModel, input.ElementType, null);

			if (IfAlreadyCreatedReturn(blueprint, typeArguments, out SemanticTypeDefinitionMask_I ensure)) return ensure;

	        var typeArgumentTypes = GetTypes(typeArguments, out bool hasGenericParameters);

			var underlyingType = Bound.MakeGenericType(blueprint, typeArgumentTypes);

			var bound = (BoundGenericTypeDefinition_I)Types.Creation.Create(semanticModel, input, underlyingType);

	        for (var j = 0; j < typeArguments.Length; j++)
	        {
		        var currentTypeArgument = typeArguments[j];

				bound.TypeArguments.All.Add(currentTypeArgument);
	        }

			bound.Blueprint = blueprint;

			blueprint.Instances.Add(bound);

	        


	        if (input.IsGenericInstance && underlyingType.IsGenericTypeDefinition)
	        {
				//throw new Exception("Semantic types that are generic instances but treated as a genreic type definition are not directly supported yet.");
			}

	        if (hasGenericParameters && underlyingType.IsGenericTypeDefinition)
	        {
		        // Check to see if effectively is a generic type definition.
		        // A) Do not try to get methods for types that are generic type definitions
		        
			}
			else
	        {
				Fields.Building.Generic.BuildFields(semanticModel, bound);

		        Constructors.Building.BuildConstructors(semanticModel, bound);

				Methods.Building.BuildMethods(semanticModel, bound);
			}
	  //      //Fields.Building.Generic.BuildFields_WithGenericTypeParameters(semanticModel, bound, blueprint);

			//	// Check to see if effectively is a generic type definition.
			//	// A) Do not try to get methods for types that are generic type definitions
			//	// B) Do not try to get methods for typee that are effectively generic type definitions becuase they contain
			//	//    unbound method generic parameters which can only become bound when the method arguments are filled in with 
			//	//    non-geneic parameters or generic type parmeters (not method parameters)
			//	//
			//	//    Notes:
			//	//    The issue is not creating the type, the issue is creating the methods.  The runtime does not allow you to
			//	//    ask for a list of runtime methods that have open type parameters becuase they are not invokeable.  It will give
			//	//    you the type to use as you mgiht need the type for declaring method return types or parameter types.  
			//	//     
			//	//var containsGenericMethodParameters = Cecil.Types.ContainsGenericMethodParameters(input);

		 //       if (!underlyingType.IsGenericTypeDefinition 
			//		//&& !containsGenericMethodParameters
			//		)
		 //       {
			//	Fields.Building.Generic.BuildFields(semanticModel, bound);

			//        Methods.Building.BuildMethods(semanticModel, bound);
			//}
			
	  //      else
	  //      {
		 //       Fields.Building.Generic.BuildFields(semanticModel, bound);

			//	Methods.Building.BuildMethods(semanticModel, bound);
			//}

			//
            

            

            return bound;
        }

	    

	    private Type[] GetTypes(BoundTypeDefinitionMask_I[] typeArguments, out bool hasGenericParameters)
	    {
		    Type[] result = new Type[typeArguments.Length];

		    hasGenericParameters = false;

			for (var j = 0; j < typeArguments.Length; j++)
			{
				var currentTypeArgument = typeArguments[j];

				hasGenericParameters |=currentTypeArgument.SourceTypeReference.IsGenericParameter;

				result[j] = currentTypeArgument.UnderlyingType;
			}

		    return result;
	    }


	   

	    private bool IfAlreadyCreatedReturn(BoundGenericTypeDefinitionMask_I genericBlueprint, BoundTypeDefinitionMask_I[] typeArgumentTypes,out SemanticTypeDefinitionMask_I ensure)
        {
            for (int i = 0; i < genericBlueprint.Instances.Count; i++)
            {
                var instance = genericBlueprint.Instances[i];

                var currentInstance = (BoundGenericTypeDefinitionMask_I) instance;

                var found = true;
				
                for (var j = 0; j < currentInstance.TypeArguments.All.Count; j++)
                {
	                var currentTypeArgument = currentInstance.TypeArguments.All[j];

	                if (ReferenceEquals(currentTypeArgument, typeArgumentTypes[j])) continue;

	                found = false;

	                break;
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
