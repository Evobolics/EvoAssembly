using System;
using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;
using Root.Code.Models.E01D.Runtimic.Unified;
using Root.Code.Models.E01D.Runtimic.Unified.Metadata.Members.Types;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata
{
	public interface ModuleApiMask_I
	{
		void Extend(RuntimicSystemModel semanticModel, UnifiedAssemblyNode assemblyNode);

		void Extend(RuntimicSystemModel semanticModel, UnifiedAssemblyNode assemblyNode, List<UnifiedTypeNode> types);
		StructuralModuleNode Ensure(RuntimicSystemModel runtimicSystem, StructuralAssemblyNode structuralAssemblyNode, Guid moduleModuleVersionId);
		bool Find(AssemblyDefinition cecilAssemblyDefinition, Guid moduleVersionId, out ModuleDefinition moduleDefinition);
	}
}
