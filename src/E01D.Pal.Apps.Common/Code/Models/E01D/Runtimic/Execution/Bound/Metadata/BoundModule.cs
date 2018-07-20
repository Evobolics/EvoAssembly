using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
    public class BoundModule: BoundMetadata, BoundModule_I
    {
        public SemanticAssemblyMask_I Assembly { get; set; }

        public bool IsBuiltOut { get; set; }

        //SemanticAssemblyMask_I SemanticModuleMask_I.Assembly => Assembly;

        public ModuleDefinition SourceModuleDefinition { get; set; }
        public SemanticModuleTypes_I Types { get; set; } = new BoundModuleTypes();

	    public Dictionary<long, BoundMethodDefinitionMask_I> MethodsByMetadataToken { get; set; } =
		    new Dictionary<long, BoundMethodDefinitionMask_I>();

	    public Dictionary<long, BoundConstructorDefinitionMask_I> ConstructorsByMetadataToken { get; set; } =
		    new Dictionary<long, BoundConstructorDefinitionMask_I>();
	}
}
