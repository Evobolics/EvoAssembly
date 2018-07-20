using System;
using System.Collections.Generic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class GettingApi<TContainer> : CecilApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public List<AssemblyDefinition> GetAssemblies(InfrastructureRuntimicModelMask_I semanticModel, List<TypeReference> inputTypes)
		{
			throw new System.NotImplementedException();
		}

		public UnifiedAssemblyNode Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName)
		{
			if (Get(semanticModel, resolutionName, out UnifiedAssemblyNode node))
			{
				return node;
			}

			return null;
		}

		public bool Get(InfrastructureRuntimicModelMask_I semanticModel, string resolutionName, out UnifiedAssemblyNode node)
		{
			if (!semanticModel.Unified.Assemblies.Definitions.TryGetValue(resolutionName, out UnifiedAssemblyNodeSet set))
			{
				node = null;
				return false;
			}

			if (set.First == set.Last)
			{
				node = set.First;
				return true;
			}

			throw new Exception("Currently support for multiple assemblies with the same name is not supported.");
		}
	}
}
