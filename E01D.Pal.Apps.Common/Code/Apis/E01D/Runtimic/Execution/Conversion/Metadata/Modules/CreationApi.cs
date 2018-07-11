using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
	public class CreationApi<TContainer> : ConversionApiNode<TContainer>, CreationApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
		

		public SemanticModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry)
		{
			return CreateModuleEntry(entry, null);
		}

		public SemanticModuleMask_I CreateModuleEntry(BoundAssemblyMask_I entry, ModuleDefinition moduleDefinition)
		{
			var name = moduleDefinition != null ? moduleDefinition.Name : entry.Name;

		    SemanticModuleMask_I module;

            if (entry.IsConverted() && ((entry is ConvertedAssembly_I convertedAssembly)))
			{
			    module = new ConvertedModule()
			    {
			        ModuleBuilder = convertedAssembly.AssemblyBuilder.DefineDynamicModule(name),
                    Name = name,
			        Assembly = convertedAssembly,
			        SourceModuleDefinition = moduleDefinition,
			        Conversion = convertedAssembly.Conversion,
			    };
            }
		    else if (entry.IsEmitted() && ((entry is EmittedAssembly_I emittedAssembly)))
		    {
		        throw new NotSupportedException();
		    }
			else if (entry is BoundAssembly_I boundAssembly)
            {
                module = this.Binding.Metadata.Modules.Creation.CreateModuleEntry(entry, moduleDefinition);
            }
            else
            {
                throw new NotSupportedException();
            }

			return module;
		}
	}
}
