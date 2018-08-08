using System;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
    public class StructuralTypesApi<TContainer> : SemanticApiNode<TContainer>, StructuralTypesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public CollectionApi_I<TContainer> Collection { get; set; }
		CollectionApiMask_I StructuralTypesApiMask_I.Collection => Collection;

		public ExternalApi_I<TContainer> External { get; set; }
		ExternalApiMask_I StructuralTypesApiMask_I.External => External;

		
        

        

        

        public ModuleDefinition GetModuleFromType(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
        {
	        throw new System.Exception("Debug");
			//         var node = Unified.Types.Get(semanticModel, resolutionName);

			//return node?.ModuleNode?.ModuleDefinition;
		}

        

       


        //public TypeReference GetTypeReference(InfrastructureRuntimicModelMask_I model, Type input)
        //{
	       // string resolutionName = Binding.Metadata.Members.Types.Naming.GetResolutionName(input);

        //    TypeReference typeDefinition = Collection.GetStoredTypeReference(model, resolutionName);

        //    if (typeDefinition != null) return typeDefinition;

        //    if (!input.IsGenericType)
        //    {
        //        throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
        //    }

        //    var genericArguments = input.GenericTypeArguments;

        //    if (genericArguments.Length < 1)
        //    {
        //        throw new Exception($"Type definition for {input.AssemblyQualifiedName} is not loaded.");
        //    }

        //    var genericTypeDefinition = input.GetGenericTypeDefinition();

        //    var genericTypeDefinition1 = GetTypeReference(model, genericTypeDefinition);

        //    var genericArgumentReferences = new TypeReference[genericArguments.Length];

        //    for (int i = 0; i < genericArguments.Length; i++)
        //    {
        //        genericArgumentReferences[i] = GetTypeReference(model, genericArguments[i]);
        //    }

        //    var result = genericTypeDefinition1.MakeGenericInstanceType(genericArgumentReferences);

        //    return result;
        //}

        public Type ResolveToType(InfrastructureRuntimicModelMask_I model, SemanticTypeDefinitionMask_I semanticType)
        {
            throw new Exception("resolving a semantic type to a run time is not supported.  A semantic type is designed to be used to create runtime type.  Right now automatic" +
                                "compile support is not present.");
        }


       


    }
}
