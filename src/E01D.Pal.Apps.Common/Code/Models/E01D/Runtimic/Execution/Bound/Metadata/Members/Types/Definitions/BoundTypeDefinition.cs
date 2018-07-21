using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundTypeDefinition: BoundType, BoundTypeDefinition_I//, BoundTypeWithInterfaceTypeListMask_I
    {
		public BoundTypeDefinitionMask_I BaseType { get; set; }

	    SemanticTypeDefinitionMask_I SemanticTypeDefinitionMask_I.BaseType => BaseType;

		public override TypeKind TypeKind { get; set; } = TypeKind.Definition;

	    

		//public BoundTypeDefinitionInterfacesMask_I Interfaces { get; set; } = new BoundTypeDefinitionInterfaces();

		//SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;


	    
	    SemanticModuleMask_I SemanticTypeDefinitionMask_I.Module => base.Module;

	    //public Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get; set; } =
		   // new Dictionary<int, SemanticArrayTypeDefinitionMask_I>();
    }
}
