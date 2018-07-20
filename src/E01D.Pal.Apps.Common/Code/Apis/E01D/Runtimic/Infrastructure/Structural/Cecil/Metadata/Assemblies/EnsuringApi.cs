using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Assemblies
{
	public class EnsuringApi<TContainer> : CecilApiNode<TContainer>, EnsuringApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{

		public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode)
		{
			Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

			EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);

			return referenced;
		}

		public Dictionary<string, UnifiedAssemblyNode> EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, List<UnifiedAssemblyNode> assemblyNodes)
		{
			Dictionary<string, UnifiedAssemblyNode> referenced = new Dictionary<string, UnifiedAssemblyNode>();

			for (int i = 0; i < assemblyNodes.Count; i++)
			{
				var assemblyNode = assemblyNodes[i];

				EnsureAssemblyReferences(semanticModel, assemblyNode, referenced);
			}

			return referenced;
		}

		public void EnsureAssemblyReferences(InfrastructureRuntimicModelMask_I semanticModel, UnifiedAssemblyNode assemblyNode, Dictionary<string, UnifiedAssemblyNode> referenced)
		{
			AssemblyDefinition assemblyDefinition = assemblyNode.SourceAssemblyDefinition;

			foreach (var moduleDefinition in assemblyDefinition.Modules)
			{
				foreach (var assemblyNameReference in moduleDefinition.AssemblyReferences)
				{
					var node = Ensure(semanticModel, assemblyNameReference);

					if (!referenced.TryGetValue(node.Name, out UnifiedAssemblyNode existingNode))
					{
						referenced.Add(node.Name, node);

						EnsureAssemblyReferences(semanticModel, node, referenced);
					}
					else if (!ReferenceEquals(existingNode, node))
					{
						throw new Exception("Two unified assembly nodes of the same name but not the same object reference.");
					}
				}
			}
		}

		public CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, AssemblyDefinition[] assemblies)
		{
			var set = new CecilTypeReferenceSet();

			for (int i = 0; i < assemblies.Length; i++)
			{
				var assemblyDefinition = assemblies[i];

				var output = Ensure_AssemblyDefinition(model, assemblyDefinition, set.Types);

				set.Assemblies.Add(output);
			}

			return set;
		}

		public CecilTypeReferenceSet Ensure(InfrastructureRuntimicModelMask_I model, Assembly[] assemblies)
		{
			var set = new CecilTypeReferenceSet();

			for (int i = 0; i < assemblies.Length; i++)
			{
				var assembly = assemblies[i];

				var output = Ensure(model, assembly, set.Types);

				set.Assemblies.Add(output);
			}

			return set;
		}

		/// <summary>
		/// // Ensures the assembly definition that is associated with the type reference is part of the unified model and returns it.
		/// </summary>
		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I model, TypeReference typeReference)
		{
			return Ensure(model, typeReference.Scope);
		}

		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly)
		{
			return Ensure(semanticModel, assembly, null);
		}

		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly, List<UnifiedTypeNode> types)
		{
			if (assembly.IsDynamic)
			{
				throw new Exception("The system is not setup to convert dynamic assemblies.");
			}

			string fullName = Assemblies.Naming.GetAssemblyName(assembly);

			if (Assemblies.Getting.Get(semanticModel, fullName, out UnifiedAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			return Ensure_Assembly(semanticModel, assembly, types);
		}


		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, IMetadataScope scope)
		{
			string fullName = Assemblies.Naming.GetAssemblyName(scope);

			return Ensure(semanticModel, fullName);
		}

		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, string fullName)
		{
			

			if (Assemblies.Getting.Get(semanticModel, fullName, out UnifiedAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			var assembly = Execution.Metadata.Assemblies.FindAssembly(fullName);

			// an assembly was asked for that another assembly already provides.
			if (assembly.FullName != fullName)
			{
				var correctNode = Ensure(semanticModel, assembly.FullName);

				// Add cross reference
				Unified.Assemblies.AddCrossReference(semanticModel, correctNode, fullName);
			}

			return Ensure_Assembly(semanticModel, assembly);
		}

		

		public UnifiedAssemblyNode Ensure(InfrastructureRuntimicModelMask_I semanticModel, Stream stream)
		{
			var assemblyDefinition = Assemblies.Creating.Create(semanticModel, stream);

			return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition);
		}

		private UnifiedAssemblyNode Ensure_Assembly(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly)
		{
			return Ensure_Assembly(semanticModel, assembly, null);
		}

		private UnifiedAssemblyNode Ensure_Assembly(InfrastructureRuntimicModelMask_I semanticModel, Assembly assembly, List<UnifiedTypeNode> types)
		{
			var assemblyDefinition = Assemblies.Creating.Create(semanticModel, assembly);

			return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition, types);
		}

		private UnifiedAssemblyNode Ensure_AssemblyDefinition(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			return Ensure_AssemblyDefinition(semanticModel, assemblyDefinition, null);
		}

		private UnifiedAssemblyNode Ensure_AssemblyDefinition(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, List<UnifiedTypeNode> types)
		{
			string fullName = Assemblies.Naming.GetAssemblyName(assemblyDefinition);

			if (Assemblies.Getting.Get(semanticModel, fullName, out UnifiedAssemblyNode assemblyNode))
			{
				return assemblyNode;
			}

			return Assemblies.Extending.Extend(semanticModel, assemblyDefinition, types);

			
		}
	}
}
