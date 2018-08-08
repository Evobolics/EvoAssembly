using System;
using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public interface ModuleApiMask_I
    {

        AdditionApiMask_I Addition { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

        EnsuringApiMask_I Ensuring { get; }

        void DeclareAndDefine(SemanticModuleMask_I boundModule);

        

        SemanticModuleMask_I GetModuleEntry(ILConversion conversion, ModuleDefinition moduleDefinition);

        SemanticModuleMask_I GetModuleEntry(SemanticAssemblyMask_I assemblyEntry, ModuleDefinition moduleDefinition);

        SemanticModuleMask_I GetModuleEntry(ConvertedModule currentModuleEntry, TypeDefinition typeDefinition);
        SemanticModuleMask_I Get(ILConversion semanticAnalysis, Module module);


        bool IsCorlib(IMetadataScope scope);
        bool IsCorlib(Module module);
        ConvertedModuleNode Ensure(ILConversion conversion, ConvertedAssemblyNode conversionAssemblyNode, StructuralModuleNode structuralModule);
	    ConvertedModuleNode Get(ILConversion conversion, Guid module);
	}
}
