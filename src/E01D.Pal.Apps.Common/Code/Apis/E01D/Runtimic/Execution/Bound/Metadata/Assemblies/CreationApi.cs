using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Assemblies
{
	public class CreationApi<TContainer> : BoundApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

		/// <summary>
		/// 
		/// </summary>
		/// <param name="semanticModel"></param>
		/// <param name="assemblyDefinition"></param>
		/// <returns></returns>
		/// <remarks>The only way an semantic assembly should be created is via the use of an assembly definition.  This forces the structural model to be 
		/// updated to include the assembly definition first. </remarks>
		public BoundAssemblyMask_I CreateAssemblyEntry(RuntimicSystemModel runtimicSystem, BoundAssemblyNode assemblyNode)
        {
            var boundAssembly = new BoundAssembly()
            {
                Node = assemblyNode
            };

            return boundAssembly;
        }
    }
}
