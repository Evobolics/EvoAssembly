using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public class NamingApi<TContainer> : BoundApiNode<TContainer>, NamingApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public string GetResolutionName(AssemblyNameReference assemblyNameReference)
        {
            return assemblyNameReference.FullName;
        }

        public string GetResolutionName(AssemblyDefinition assemblyDefinition)
        {
            return assemblyDefinition.FullName;
        }
    }
}
