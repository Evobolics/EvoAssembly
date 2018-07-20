using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types
{
	public class ExternalApi<TContainer> : SemanticApiNode<TContainer>, ExternalApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeReference Resolve(InfrastructureRuntimicModelMask_I model, TypeReference externalReference)
		{
			var storedReference = Cecil.Types.Getting.GetStoredTypeReference(model, externalReference);

			if (storedReference != null) return storedReference;

			if (externalReference.Scope is AssemblyNameReference assemblyNameReference)
			{
				var assemblyNode = Unified.Assemblies.Get(model, assemblyNameReference.FullName);

				if (assemblyNode == null)
				{
					throw new System.Exception("Could not resolve external reference.");
				}

				// Was the runtime was setup to redirect references from one assemlby to another?  If so, get the correct type name that is actually loaded.
				if (assemblyNode.Name != assemblyNameReference.FullName)
				{
					var assemblyQualifiedName = Cecil.Types.Naming.GetAssemblyQualifiedName(externalReference, assemblyNode.Name);

					storedReference = Cecil.Types.Getting.GetStoredTypeReference(model, assemblyQualifiedName);

					if (storedReference != null) return storedReference;

					throw new System.Exception("Could not resolve external reference.");
				}

			}

			throw new System.Exception("Could not resolve external reference.");
		}
	}
}
