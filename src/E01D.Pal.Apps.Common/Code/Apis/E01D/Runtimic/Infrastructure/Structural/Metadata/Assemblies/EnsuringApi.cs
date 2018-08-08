using System;
using System.IO;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Assemblies
{
	public class EnsuringApi<TContainer> : CecilApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		

		public StructuralAssemblyNode[] Ensure(RuntimicSystemModel model, Assembly[] assemblies)
		{
			var output = new StructuralAssemblyNode[assemblies.Length];

			for (int i = 0; i < assemblies.Length; i++)
			{
				var assembly = assemblies[i];

				output[i] = Ensure(model, assembly);
			}

			return output;
		}

		[PublicApi]
		public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Assembly assembly)
		{
			if (assembly.IsDynamic)
			{
				throw new Exception("The system is not currently setup to convert dynamic assemblies to dynamic assemblies.");
			}

			var assemblies = runtimicSystemModel.TypeSystems.Structural.Assemblies;

			if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
			{
				for (int i = 0; i < assemblies.QuickReferenceCount; i++)
				{
					var tuple = assemblies.QuickReference[i];

					if (ReferenceEquals(tuple.Item1, assembly)) return tuple.Item2;
				}
			}

			if (Assemblies.Getting.Get(runtimicSystemModel, assembly.FullName, out StructuralAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			var structuralAssemblyNode = Ensure_Assembly(runtimicSystemModel, assembly);

			if (assemblies.QuickReferenceCount < assemblies.QuickReference.Length)
			{
				assemblies.QuickReference[assemblies.QuickReferenceCount++] = new Tuple<Assembly, StructuralAssemblyNode>(assembly, structuralAssemblyNode);
			}

			return structuralAssemblyNode;
		}


		[PublicApi]
		public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicSystemModel, Stream stream)
		{
			var assemblyDefiniition = AssemblyDefinition.ReadAssembly(stream);

			if (Assemblies.Getting.Get(runtimicSystemModel, assemblyDefiniition.FullName, out StructuralAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			return Ensure_AssemblyDefinition(runtimicSystemModel, assemblyDefiniition);
		}




		/// <summary>
		/// // Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		[PublicApi]
		public StructuralAssemblyNode Ensure(RuntimicSystemModel model, TypeReference typeReference)
		{
			return Ensure(model, typeReference.Scope);
		}

		[PublicApi]
		public StructuralAssemblyNode Ensure(RuntimicSystemModel semanticModel, IMetadataScope scope)
		{
			string fullName = Assemblies.Naming.GetAssemblyName(scope);

			return Ensure(semanticModel, fullName);
		}

		[PublicApi]
		public StructuralAssemblyNode Ensure(RuntimicSystemModel runtimicModel, string fullName)
		{
			if (Assemblies.Getting.Get(runtimicModel, fullName, out StructuralAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			var assembly = Execution.Metadata.Assemblies.FindAssembly(fullName);

			// an assembly was asked for that another assembly already provides.
			if (assembly.FullName != fullName)
			{
				var correctNode = Ensure(runtimicModel, assembly.FullName);

				// Add cross reference
				runtimicModel.TypeSystems.Structural.Assemblies.ByName.Add(fullName, correctNode);
			}

			return Ensure_Assembly(runtimicModel, assembly);
		}

		public StructuralAssemblyNode Ensure_Assembly(RuntimicSystemModel runtimicSystemModel, Assembly assembly)
		{
			var stream = new MemoryStream(File.ReadAllBytes(assembly.Location));

			runtimicSystemModel.Io.OpenStreams.Add(stream);

			var assemblyDefiniition = AssemblyDefinition.ReadAssembly(stream);

			return Ensure_AssemblyDefinition(runtimicSystemModel, assemblyDefiniition);
		}

		public StructuralAssemblyNode Ensure_AssemblyDefinition(RuntimicSystemModel runtimicSystemModel, AssemblyDefinition assemblyDefinition)
		{
			var assemblyNode = Infrastructure.Structural.Metadata.Assemblies.Creating.Create(runtimicSystemModel, assemblyDefinition);

			runtimicSystemModel.TypeSystems.Structural.Assemblies.ByName.Add(assemblyNode.FullName, assemblyNode);

			for (int i = 0; i < assemblyDefinition.Modules.Count; i++)
			{
				var moduleDefinition = assemblyDefinition.Modules[i];

				var structuralModuleNode = Infrastructure.Structural.Metadata.Modules.Ensure(runtimicSystemModel, assemblyNode, moduleDefinition);

				for (int j = 0; j < moduleDefinition.Types.Count; j++)
				{
					var currentType = moduleDefinition.Types[j];

					EnsureTypeAndNestedTypes(runtimicSystemModel, assemblyNode, structuralModuleNode, currentType);
				}
			}

			

			return assemblyNode;
		}

		private void EnsureTypeAndNestedTypes(RuntimicSystemModel runtimicSystemModel, StructuralAssemblyNode assemblyNode, StructuralModuleNode structuralModuleNode, TypeDefinition currentType)
		{
			var node = Infrastructure.Structural.Types.Ensure(runtimicSystemModel, structuralModuleNode, currentType);

			assemblyNode.Types.Add(node.FullName, node);

			for (int i = 0; i < currentType.NestedTypes.Count; i++)
			{
				EnsureTypeAndNestedTypes(runtimicSystemModel, assemblyNode, structuralModuleNode, currentType.NestedTypes[i]);
			}
		}
	}
}


//public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode)
//{
//	Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

//	EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);

//	return referenced;
//}

//public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, List<UnifiedAssemblyNode> assemblyNodes)
//{
//	Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

//	for (int i = 0; i < assemblyNodes.Count; i++)
//	{
//		var assemblyNode = assemblyNodes[i];

//		EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);
//	}

//	return referenced;
//}

//public void EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode, Dictionary<string, UnifiedAssemblyNode> referenced)
//{
//	AssemblyDefinition assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

//	foreach (var moduleDefinition in assemblyDefinition.Modules)
//	{
//		foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
//		{
//			var node = Ensure(semanticModel, assemblyNameReference);

//			if (!referenced.TryGetValue(node.Name, out UnifiedAssemblyNode existingNode))
//			{
//				referenced.Add(node.Name, node);

//				EnsureAssemblyReferences(semanticModel, node, referenced);
//			}
//			else if (!ReferenceEquals(existingNode, node))
//			{
//				throw new Exception("Two unified assembly nodes of the same name but not the same object reference.");
//			}
//		}
//	}
//}

//public CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, AssemblyDefinition[] assemblies)
//{
//	var set = new CecilTypeReferenceSet();

//	for (int i = 0; i < assemblies.Length; i++)
//	{
//		var assemblyDefinition = assemblies[i];

//		var output = Ensure_AssemblyDefinition(model, assemblyDefinition, set.Types);

//		set.Assemblies.Add(output);
//	}

//	return set;
//}