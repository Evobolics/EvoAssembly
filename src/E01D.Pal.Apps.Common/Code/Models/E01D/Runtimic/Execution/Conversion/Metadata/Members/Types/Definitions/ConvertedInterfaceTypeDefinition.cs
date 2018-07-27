using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedInterfaceTypeDefinition:
		ConvertedReferenceTypeDefinition, 
		InterfaceType_I, 
		BoundInterfaceTypeMask_I,
	    ConvertedTypeDefinitionWithProperties_I,
		ConvertedTypeDefinitionWithEvents_I
	{
	    public override TypeKind TypeKind => base.TypeKind | TypeKind.Interface | TypeKind.SupportsInterfaceTypeList;

		public ConvertedTypeDefinitionEvents Events { get; set; } = new ConvertedTypeDefinitionEvents();
		public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

		public ConvertedTypeDefinitionProperties Properties { get; set; } = new ConvertedTypeDefinitionProperties();

		SemanticTypeEventsMask_I SemanticTypeWithEventsMask_I.Events => this.Events;

		SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

		SemanticTypePropertiesMask_I SemanticTypeWithPropertiesMask_I.Properties => this.Properties;
	}
}
