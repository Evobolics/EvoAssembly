using System;
using System.Reflection;
using Mono.Cecil;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public class ModuleApi<TContainer> : ConversionApiNode<TContainer>, ModuleApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    
	    public AdditionApi_I<TContainer> Addition { get; set; }

        
        public BuildingApi_I<TContainer> Building { get; set; }

        
		public CreationApi_I<TContainer> Creation { get; set; }

        
        public EnsuringApi_I<TContainer> Ensuring { get; set; }

        AdditionApiMask_I ModuleApiMask_I.Addition => Addition;

        BuildingApiMask_I ModuleApiMask_I.Building => Building;

        CreationApiMask_I ModuleApiMask_I.Creation => Creation;

        EnsuringApiMask_I ModuleApiMask_I.Ensuring => Ensuring;



        

	    

        

		/// <summary>
		/// Declare all the modules and its members, and then define the members by filling in instructions.
		/// </summary>
		/// <param name="moduleEntry"></param>
        public void DeclareAndDefine(SemanticModuleMask_I moduleEntry)
		{
		    

            //moduleEntry.Types.InDependencyOrder = ILConversion.Types.DeclareAll(moduleEntry);

			// If the module is not converted, then there is no need to build out the rest of the model at this time, as
			// the remainder ofthe information can be fetched from the type system directly as it is required.
            if (!moduleEntry.IsConverted()) return;

            //ILConversion.Fields.DeclareAll(moduleEntry);

            //ILConversion.Methods.DeclareAll(moduleEntry);

            //ILConversion.Properties.DeclareAll(moduleEntry);

            //ILConversion.Events.DeclareAll(moduleEntry);

            //ILConversion.Instructions.DeclareAll(moduleEntry);

            //ILConversion.Semantic.Types.CreateAll(moduleEntry);
        }

       

        

        public SemanticModuleMask_I GetModuleEntry(ILConversion conversion, ModuleDefinition moduleDefinition)
        {
            // Get the module for the type creation.  If the type is orginal or mscorlib, then treated specially.
            var assemblyEntry = Assemblies.Getting.GetAssembly(conversion, moduleDefinition.Assembly);

            return GetModuleEntry(assemblyEntry, moduleDefinition);
        }

        public SemanticModuleMask_I GetModuleEntry(SemanticAssemblyMask_I assemblyEntry, ModuleDefinition moduleDefinition)
        {
            // If corelib, set to false.
            // check exclusion list, set to false.

            if (!assemblyEntry.Modules.TryGetValue(moduleDefinition.Name, out SemanticModuleMask_I moduleEntry))
            {
                throw new Exception("Module not found");
            }

            return moduleEntry;
        }

        public SemanticModuleMask_I GetModuleEntry(ConvertedModule currentModuleEntry, TypeDefinition typeDefinition)
        {
            if (typeDefinition.Module == currentModuleEntry.SourceModuleDefinition)
            {
                return currentModuleEntry;
            }

            return Modules.GetModuleEntry(currentModuleEntry.Conversion, typeDefinition.Module);
        }

        public SemanticModuleMask_I Get(ILConversion conversion, Module module)
        {
            Assembly assembly = module.Assembly;

            var assemblyEntry = Assemblies.Getting.GetAssembly(conversion, assembly);

            if (!assemblyEntry.Modules.TryGetValue(module.ScopeName, out SemanticModuleMask_I moduleEntry))
            {
                throw new Exception("Module not found");
            }

            return moduleEntry;
        }

        public bool IsCorlib(IMetadataScope scope)
        {
            if (scope is AssemblyNameReference assemblyNameReference)
            {
                return assemblyNameReference.FullName.StartsWith("mscorlib");
            }
            return scope.Name.StartsWith("mscorlib");
        }

        public bool IsCorlib(System.Reflection.Module module)
        {
            return module.Name.StartsWith("mscorlib");
        }
    }
}
