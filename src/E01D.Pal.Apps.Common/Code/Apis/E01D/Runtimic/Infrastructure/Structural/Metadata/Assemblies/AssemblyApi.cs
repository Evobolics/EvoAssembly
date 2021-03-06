﻿using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies
{
    public class AssemblyApi<TContainer> : CecilApiNode<TContainer>, AssemblyApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		public CreatingApi_I<TContainer> Creating { get; set; }

		CreatingApiMask_I AssemblyApiMask_I.Creating => Creating;

		public EnsuringApi_I<TContainer> Ensuring { get; set; }

		EnsuringApiMask_I AssemblyApiMask_I.Ensuring => Ensuring;

		///// <summary>
		///// The goal here is to make sure there is a structural assembly node loaded into the runtimic system model that is 
		///// associated with the inputed assembly.
		///// </summary>
		///// <param name="runtimicSystemModel"></param>
		///// <param name="assembly"></param>
		///// <returns></returns>
		//public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Assembly assembly)
		//{
		//	if (assembly.IsDynamic)
		//	{
		//		throw new Exception("The system is not currently setup to convert dynamic assemblies to dynamic assemblies.");
		//	}

		//	StructuralAssemblyNode structuralAssemblyNode = null;

		//	var assemblies = runtimicSystemModel.TypeSystems.Structural.Assemblies;

		//	if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
		//	{
		//		for (int i = 0; i < assemblies.QuickReferenceCount; i++)
		//		{
		//			var tuple = assemblies.QuickReference[i];

		//			if (ReferenceEquals(tuple.Item1, assembly)) return tuple.Item2;
		//		}
		//	}
			
		//	// Assemblies are one of the few thinsg that should be identified by name.  
		//	string fullName = Assemblies.Naming.GetAssemblyName(assembly);

		//	if (assemblies.ByName.TryGetValue(fullName, out structuralAssemblyNode))
		//	{
		//		return structuralAssemblyNode;
		//	}

		//	structuralAssemblyNode = this.Assemblies.Creating.Create(runtimicSystemModel, assembly);

		//	if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
		//	{
		//		assemblies.QuickReference[assemblies.QuickReferenceCount++] = new Tuple<Assembly, StructuralAssemblyNode>(assembly, structuralAssemblyNode);
		//	}

		//	return structuralAssemblyNode;

		//}

	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, AssemblyDefinition assembly)
	 //   {
			

		//    StructuralAssemblyNode structuralAssemblyNode = null;

		//    var assemblies = runtimicSystemModel.TypeSystems.Structural.Assemblies;

		//    //if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
		//    //{
		//	   // for (int i = 0; i < assemblies.QuickReferenceCount; i++)
		//	   // {
		//		  //  var tuple = assemblies.QuickReference[i];

		//		  //  if (ReferenceEquals(tuple.Item1, assembly)) return tuple.Item2;
		//	   // }
		//    //}

		//    // Assemblies are one of the few thinsg that should be identified by name.  
		//    string fullName = Assemblies.Naming.GetAssemblyName(assembly);

		//    if (assemblies.ByName.TryGetValue(fullName, out structuralAssemblyNode))
		//    {
		//	    return structuralAssemblyNode;
		//    }

		//    structuralAssemblyNode = this.Assemblies.Creating.Create(runtimicSystemModel, assembly);

		//    //if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
		//    //{
		//	   // assemblies.QuickReference[assemblies.QuickReferenceCount++] = new Tuple<Assembly, StructuralAssemblyNode>(assembly, structuralAssemblyNode);
		//    //}

		//    return structuralAssemblyNode;
		//}

	 //   //public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode)
	 //   //{
	 //   //	Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

	 //   //	EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);

	 //   //	return referenced;
	 //   //}

	 //   //public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, List<UnifiedAssemblyNode> assemblyNodes)
	 //   //{
	 //   //	Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

	 //   //	for (int i = 0; i < assemblyNodes.Count; i++)
	 //   //	{
	 //   //		var assemblyNode = assemblyNodes[i];

	 //   //		EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);
	 //   //	}

	 //   //	return referenced;
	 //   //}

	 //   //public void EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode, Dictionary<string, UnifiedAssemblyNode> referenced)
	 //   //{
	 //   //	AssemblyDefinition assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

	 //   //	foreach (var moduleDefinition in assemblyDefinition.Modules)
	 //   //	{
	 //   //		foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
	 //   //		{
	 //   //			var node = Ensure(semanticModel, assemblyNameReference);

	 //   //			if (!referenced.TryGetValue(node.Name, out UnifiedAssemblyNode existingNode))
	 //   //			{
	 //   //				referenced.Add(node.Name, node);

	 //   //				EnsureAssemblyReferences(semanticModel, node, referenced);
	 //   //			}
	 //   //			else if (!ReferenceEquals(existingNode, node))
	 //   //			{
	 //   //				throw new Exception("Two unified assembly nodes of the same name but not the same object reference.");
	 //   //			}
	 //   //		}
	 //   //	}
	 //   //}

	 //   //public CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, AssemblyDefinition[] assemblies)
	 //   //{
	 //   //	var set = new CecilTypeReferenceSet();

	 //   //	for (int i = 0; i < assemblies.Length; i++)
	 //   //	{
	 //   //		var assemblyDefinition = assemblies[i];

	 //   //		var output = Ensure_AssemblyDefinition(model, assemblyDefinition, set.Types);

	 //   //		set.Assemblies.Add(output);
	 //   //	}

	 //   //	return set;
	 //   //}

	 //   public StructuralAssemblyNode[] Ensure(RuntimicSystemModel model, Assembly[] assemblies)
	 //   {
		//    var output = new StructuralAssemblyNode[assemblies.Length];

		//    for (int i = 0; i < assemblies.Length; i++)
		//    {
		//	    var assembly = assemblies[i];

		//	    output[i] = Ensure(model, assembly);
		//    }

		//    return output;
	 //   }

	 //   [PublicApi]
	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Assembly assembly)
	 //   {
		//    if (Assemblies.Getting.Get(runtimicSystemModel, assembly.FullName, out StructuralAssemblyNode assemblyNode))
		//    {
		//	    return assemblyNode;
		//    }

		//    return Ensure_Assembly(runtimicSystemModel, assembly);
	 //   }


	 //   [PublicApi]
	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Stream stream)
	 //   {
		//    var assemblyDefiniition = AssemblyDefinition.ReadAssembly(stream);

		//    if (Assemblies.Getting.Get(runtimicSystemModel, assemblyDefiniition.FullName, out StructuralAssemblyNode assemblyNode))
		//    {
		//	    return assemblyNode;
		//    }

		//    return Ensure_AssemblyDefinition(runtimicSystemModel, assemblyDefiniition);

		//    //throw new Exception("Fix");
		//    //var assemblyDefinition = Assemblies.Creating.Create(semanticModel, stream);

		//    //return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition);
	 //   }




	 //   /// <summary>
	 //   /// // Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
	 //   /// </summary>
	 //   [PublicApi]
	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel model, TypeReference typeReference)
	 //   {
		//    return Ensure(model, typeReference.Scope);
	 //   }

	 //   [PublicApi]
	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel semanticModel, IMetadataScope scope)
	 //   {
		//    string fullName = Assemblies.Naming.GetAssemblyName(scope);

		//    return Ensure(semanticModel, fullName);
	 //   }

	 //   [PublicApi]
	 //   public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicModel, string fullName)
	 //   {
		//    if (Assemblies.Getting.Get(runtimicModel, fullName, out StructuralAssemblyNode assemblyNode))
		//    {
		//	    return assemblyNode;
		//    }

		//    var assembly = Execution.Metadata.Assemblies.FindAssembly(fullName);

		//    // an assembly was asked for that another assembly already provides.
		//    if (assembly.FullName != fullName)
		//    {
		//	    var correctNode = Ensure(runtimicModel, assembly.FullName);

		//	    // Add cross reference
		//	    runtimicModel.TypeSystems.Structural.Assemblies.ByName.Add(fullName, correctNode);
		//    }

		//    return Ensure_Assembly(runtimicModel, assembly);
	 //   }

	 //   public StructuralAssemblyNode Ensure_Assembly(RuntimicSystemModel runtimicSystemModel, Assembly assembly)
	 //   {
		//    var stream = new MemoryStream(File.ReadAllBytes(assembly.Location));

		//    runtimicSystemModel.Io.OpenStreams.Add(stream);

		//    var assemblyDefiniition = AssemblyDefinition.ReadAssembly(stream);

		//    return Ensure_AssemblyDefinition(runtimicSystemModel, assemblyDefiniition);
	 //   }

	 //   public StructuralAssemblyNode Ensure_AssemblyDefinition(RuntimicSystemModel runtimicSystemModel, AssemblyDefinition assemblyDefinition)
	 //   {
		//    var node = Assemblies.Creating.Create(runtimicSystemModel, assemblyDefinition);

		//    runtimicSystemModel.TypeSystems.Structural.Assemblies.ByName.Add(node.FullName, node);

		//    return node;
	 //   }
	}
}
