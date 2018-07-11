using Root.Code.Apis.E01D.Runtimic.Execution.Conversion;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building.GenericInstances;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building
{
	public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public GenericInstanceApi_I<TContainer> GenericInstances { get; set; }

		GenericInstanceApiMask_I BuildingApiMask_I.GenericInstances => GenericInstances;

		public MethodDefinitionApi_I<TContainer> MethodDefinitions { get; set; }

		MethodDefinitionApiMask_I BuildingApiMask_I.MethodDefinitions => MethodDefinitions;
	}
}
