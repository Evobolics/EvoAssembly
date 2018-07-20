using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Unified
{
    public class AssemblyApi<TContainer> : UnifiedApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    

	    public void Add(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode node)
	    {
		    Add(model, node, node.Name);
	    }

	    public void Add(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode node, string name)
	    {
		    if (!model.Unified.Assemblies.Definitions.TryGetValue(name, out UnifiedAssemblyNodeSet set))
		    {
			    set = new UnifiedAssemblyNodeSet()
			    {
				    Name = name
				};

			    model.Unified.Assemblies.Definitions.Add(name, set);
		    }

		    if (set.First == null)
		    {
			    set.First = node;
			    set.Last = node;
		    }
		    else
		    {
			    set.Last.Next = node;
			    set.Last = node;
		    }


	    }

		public UnifiedAssemblyNode Create(UnifiedRuntimicModelMask_I model, AssemblyDefinition assemblyDefinition)
		{
			var resolutionName = GetResolutionName(assemblyDefinition);

			return new UnifiedAssemblyNode()
		    {
				Name = resolutionName,

				SourceAssemblyDefinition = assemblyDefinition
		    };
	    }


		public UnifiedAssemblyNode Extend(UnifiedRuntimicModelMask_I model, AssemblyDefinition assemblyDefinition)
		{
			var node = Create(model, assemblyDefinition);

			Add(model, node);

			return node;
		}

	    public void AddCrossReference(UnifiedRuntimicModelMask_I model, UnifiedAssemblyNode node, string crossReferenceKey)
	    {
		    Add(model, node, crossReferenceKey);
	    }

		public UnifiedAssemblyNode Get(UnifiedRuntimicModelMask_I model, string resolutionName)
	    {
		    if (!model.Unified.Assemblies.Definitions.TryGetValue(resolutionName, out UnifiedAssemblyNodeSet set))
		    {
			    return null;
		    }

		    if (set.First == set.Last)
		    {
			    return set.First;
		    }
		    else
		    {
			    throw new System.Exception("Multiple type nodes of the same name are not fully suppported yet.");
		    }
	    }

		public string GetResolutionName(AssemblyDefinition assemblyDefinition)
		{
			return assemblyDefinition.FullName;
		}
	}
}
