using System;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic.Types
{
    public class ModelTypesApi<TContainer> : SemanticApiNode<TContainer>, ModelTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public CollectionApi_I<TContainer> Collection { get; set; }
		CollectionApiMask_I ModelTypesApiMask_I.Collection => Collection;

		
		

		public void Ensure(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
        {
            if (semanticType == null)
            {
                throw new Exception("Cannot add a semantic type that is null");
            }

			string resolutionName = Types.Naming.GetResolutionName(semanticType);

		

            // This property is needed to preventing multiple entries.
            if (semanticType.SourceModuleDefinition == null)
            {
                throw new Exception("Every semantic type should have a source module definition assigned.  This is the module that provided the data for the semantic type.");
            }

            if (semanticType.Module == null)
            {
                throw new Exception("Every semantic type should have a semantic module assigned to it.");
            }

            if (semanticType.Module.Assembly == null)
            {
                throw new Exception("Every semantic module should have a semantic assembly assigned to it.");
            }

            var entry = Infrastructure.Models.Unified.Types.GetSemanticEntry(semanticModel, resolutionName);

            if (entry?.SemanticType == null)
            {
				Collection.Add(semanticModel, semanticType);
            }
        }

        

        

        

        public ModuleDefinition GetModuleFromType(InfrastructureModelMask_I semanticModel, string resolutionName)
        {
            var node = Infrastructure.Models.Unified.Types.GetSemanticEntry(semanticModel, resolutionName);

            return node?.SourceModuleDefinition;
        }




	    public TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input)
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
	    public TypeReference GetTypeReference(InfrastructureModelMask_I model, Type input, out SemanticTypeDefinitionMask_I semanticType)
        {
	        string resolutionName = Binding.Metadata.Members.Types.Naming.GetResolutionName(input);

            TypeReference typeDefinition = Infrastructure.Models.Structural.Types.Collection.GetStoredTypeReference(model, resolutionName, out semanticType);

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

        public Type ResolveToType(InfrastructureModelMask_I model, SemanticTypeDefinitionMask_I semanticType)
        {
            throw new Exception("resolving a semantic type to a run time is not supported.  A semantic type is designed to be used to create runtime type.  Right now automatic" +
                                "compile support is not present.");
        }


       


    }
}
