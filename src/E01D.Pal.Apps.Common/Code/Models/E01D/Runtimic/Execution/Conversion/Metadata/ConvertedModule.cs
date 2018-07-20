using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConvertedModule: ConvertedMetadata, ConvertedModule_I
    {


        

        public SemanticAssemblyMask_I Assembly { get; set; }


        public bool IsBuiltOut { get; set; }
        public ModuleDefinition SourceModuleDefinition { get; set; }

        public ModuleBuilder ModuleBuilder { get; set; }

        

        public ConvertedModuleTypes_I Types { get; set; } = new ConvertedModuleTypes();

        SemanticModuleTypes_I SemanticModuleMask_I.Types => Types;


	    public Dictionary<long, BoundMethodDefinitionMask_I> MethodsByMetadataToken
	    {
		    get
		    {
			    throw new System.NotSupportedException("This feature is not supported by converted modules.  RVAs are not set for methods yet.");
		    }
	    }

	    public Dictionary<long, BoundConstructorDefinitionMask_I> ConstructorsByMetadataToken
	    {
		    get
		    {
			    throw new System.NotSupportedException("This feature is not supported by converted modules.  RVAs are not set for methods yet.");
		    }
	    }
	}
}
