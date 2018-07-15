using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Models.Structural
{
	public class StructuralApi<TContainer> : SemanticApiNode<TContainer>, StructuralApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public StructuralModulesApi_I<TContainer> Modules { get; set; }

		public new StructuralTypesApi_I<TContainer> Types { get; set; }


		StructuralModulesApiMask_I StructuralApiMask_I.Modules => Modules;

		StructuralTypesApiMask_I StructuralApiMask_I.Types => Types;

		public void AddAssemblyDefinition(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition)
		{
			throw new Exception("Debug");

			//if (assemblyDefinition == null) return;

			//if (semanticModel.Structural.Assemblies.Definitions.ContainsKey(assemblyDefinition.FullName)) return;

			//semanticModel.Structural.Assemblies.Definitions.Add(assemblyDefinition.FullName, assemblyDefinition);

			//for (int i = 0; i < assemblyDefinition.Modules.Count; i++)
			//{
			//	var module = assemblyDefinition.Modules[i];

			//	for (int j = 0; j < module.Types.Count; j++)
			//	{
			//		var type = module.Types[j];



			//		if (type.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.SimpleGenericClass`1")
			//		{

			//		}

			//		Ensure(semanticModel, assemblyDefinition, module, type);

			//		if (!type.HasNestedTypes) continue;

			//		for (int k = 0; k < type.NestedTypes.Count; k++)
			//		{
			//			var nestedType = type.NestedTypes[k];

			//			Ensure(semanticModel, assemblyDefinition, module, nestedType);
			//		}
			//	}
			//}
		}

		public void Ensure(InfrastructureRuntimicModelMask_I semanticModel, AssemblyDefinition assemblyDefinition, ModuleDefinition module, TypeDefinition typeDefinition)
		{
			if (assemblyDefinition == null) throw new System.ArgumentNullException();
			if (module == null) throw new System.ArgumentNullException();
			if (typeDefinition == null) throw new System.ArgumentNullException();

			string resolutionName = Infrastructure.Structural.Naming.GetResolutionName(typeDefinition);

			var entry = Unified.Types.Get(semanticModel, resolutionName);

			if (entry == null)
			{
				//Cecil.Types.Adding.Add(semanticModel, assemblyDefinition, module, typeDefinition);
				throw new Exception("Debug");
			}
		}
	}
}
