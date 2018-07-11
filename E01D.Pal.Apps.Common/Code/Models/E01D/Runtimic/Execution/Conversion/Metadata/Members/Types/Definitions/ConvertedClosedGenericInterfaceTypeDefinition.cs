using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
	public class ConvertedClosedGenericInterfaceTypeDefinition: SemanticTypeWithInterfaceTypeList_I
    {
        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;
        public Dictionary<string, SemanticNodeBaseMask_I> Dependencies { get; }
        public Dictionary<string, SemanticNodeBaseMask_I> Dependents { get; }
        public RuntimicKind RuntimicKind { get; }
        public object ObjectNetwork { get; set; }
        public string Name { get; }
        public string AssemblyQualifiedName { get; }
        public string FullName { get; }
        public TypeKind TypeKind { get; }
        public SemanticModuleMask_I Module { get; }
        public Dictionary<string, SemanticTypeMask_I> NestedTypes { get; }

	    public string ResolutionName { get; set; }
	}
}
