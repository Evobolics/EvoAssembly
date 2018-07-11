using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Semantic
{
	public class ModelAssembliesApi<TContainer> : SemanticApiNode<TContainer>, ModelAssembliesApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, TypeReference typeReference)
		{	
			var assemblyName = Infrastructure.Structural.Cecil.Metadata.Assemblies.GetAssemblyName(typeReference);

			if (TryGet(model, assemblyName, out SemanticAssemblyMask_I assemblyEntry))
			{
				return assemblyEntry;
			}

			return null;
		}

		public SemanticAssemblyMask_I Get(InfrastructureModelMask_I model, string typeResolutionName)
		{
			var semanticType = Infrastructure.Models.Semantic.Types.Collection.Get(model, typeResolutionName);

			if (semanticType == null)
			{
				throw new Exception($"Assembly ensure does not support scope '{typeResolutionName}'");
			}

			return semanticType.Module.Assembly;
		}

		public bool TryGet(InfrastructureModelMask_I model, string resolutionName, out SemanticAssemblyMask_I semanticAssemblyMask)
		{
			return model.Semantic.Assemblies.ByResolutionName.TryGetValue(resolutionName, out semanticAssemblyMask);
		}
	}
}
