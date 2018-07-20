using System;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Rocks;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
    public class ModelTypesApi<TContainer> : SemanticApiNode<TContainer>, ModelTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public CollectionApi_I<TContainer> Collection { get; set; }
		CollectionApiMask_I ModelTypesApiMask_I.Collection => Collection;

		
		

		public void Ensure(InfrastructureRuntimicModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
        {
            if (semanticType == null)
            {
                throw new Exception("Cannot add a semantic type that is null");
            }

			string resolutionName = Types.Naming.GetResolutionName(semanticType);

            if (semanticType.Module.Assembly == null)
            {
                throw new Exception("Every semantic module should have a semantic assembly assigned to it.");
            }

            var entry = Unified.Types.Get(semanticModel, resolutionName);

            if (entry?.SemanticType == null)
            {
				Unified.Types.Update(semanticModel, semanticType);
            }
        }

        

        

        

        public ModuleDefinition GetModuleFromType(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
        {
            var node = Unified.Types.Get(semanticModel, resolutionName);

            return node?.ModuleNode.ModuleDefinition;
        }




	    public TypeReference GetTypeReference(InfrastructureRuntimicModelMask_I model, Type input)
	    {
		    return GetTypeReference(model, input, out SemanticTypeDefinitionMask_I semanticType);

	    }

		/// <summary>
		/// 
		/// </summary>
		/// <param name="model"></param>
		/// <param name="input"></param>
		/// <param name="semanticType"></param>
		/// <returns></returns>
		/// <remarks>Used when ensuring a bound type and it needs to get the semanticType from the type reference as soon as it resolves the type to the type reference.</remarks>
	    public TypeReference GetTypeReference(InfrastructureRuntimicModelMask_I model, Type input, out SemanticTypeDefinitionMask_I semanticType)
        {
	        string resolutionName = Binding.Metadata.Members.Types.Naming.GetResolutionName(input);

            TypeReference typeDefinition = Cecil.Types.Getting.GetStoredTypeReference(model, resolutionName, out UnifiedTypeNode basicNode);

	        semanticType = basicNode?.SemanticType;

			if (typeDefinition != null) return typeDefinition;

            if (!input.IsGenericType)
            {
                throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
            }

            var genericArguments = input.GenericTypeArguments;

            if (genericArguments.Length < 1)
            {
                throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
            }

            var genericTypeDefinition = input.GetGenericTypeDefinition();

            var genericTypeDefinition1 = GetTypeReference(model, genericTypeDefinition);

            var genericArgumentReferences = new TypeReference[genericArguments.Length];

            for (int i = 0; i < genericArguments.Length; i++)
            {
                genericArgumentReferences[i] = GetTypeReference(model, genericArguments[i]);
            }

            var result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

            return result;
        }

	    

		public Type ResolveToType(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType)
        {
            throw new Exception("resolving a semantic type to a run time is not supported.  A semantic type is designed to be used to create runtime type.  Right now automatic" +
                                "compile support is not present.");
        }


       


    }
}
