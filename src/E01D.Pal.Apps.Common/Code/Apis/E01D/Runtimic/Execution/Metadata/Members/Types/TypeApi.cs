using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types
{
	public class TypeApi<TContainer> : ExecutionApiNode<TContainer>, TypeApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {

		public EnsuringApi_I<TContainer> Ensuring { get; set; }

        EnsuringApiMask_I TypeApiMask_I.Ensuring => Ensuring;


		public bool IsConverted(BoundRuntimicModelMask_I boundModel, TypeReference typeReference)
		{
			string assemlbyName = Cecil.Metadata.Assemblies.Naming.GetAssemblyName(typeReference);

			var assemblyNode = Unified.Assemblies.Get(boundModel, assemlbyName);

			

			if (assemblyNode.IsConverted) return true;

			if (typeReference.IsGenericInstance) // The generic instance needs to be a converted one, if it has a parameter that is converted.
			{
				var instanceType = (GenericInstanceType) typeReference;

				for (int i = 0; i < instanceType.GenericArguments.Count; i++)
				{
					if (IsConverted(boundModel, instanceType.GenericArguments[i])) return true;
				}
			}

			return false;

			
		}









	}
}
