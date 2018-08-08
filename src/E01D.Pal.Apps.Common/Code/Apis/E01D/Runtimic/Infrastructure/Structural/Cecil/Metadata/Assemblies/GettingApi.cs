using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class GettingApi<TContainer> : CecilApiNode<TContainer>, GettingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		

		public StructuralAssemblyNode Get(RuntimicSystemModel runtimicModel, string resolutionName)
		{
			if (Get(runtimicModel, resolutionName, out StructuralAssemblyNode node))
			{
				return node;
			}

			return null;
		}

		public bool Get(RuntimicSystemModel runtimicModel, string resolutionName, out StructuralAssemblyNode node)
		{
			return runtimicModel.TypeSystems.Structural.Assemblies.ByName.TryGetValue(resolutionName, out node);
		}
	}
}
