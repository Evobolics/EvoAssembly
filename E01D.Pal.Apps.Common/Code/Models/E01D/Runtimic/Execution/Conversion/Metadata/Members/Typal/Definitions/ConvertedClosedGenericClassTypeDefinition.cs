using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
	public class ConvertedClosedGenericClassTypeDefinition: SemanticTypeWithInterfaceTypeListMask_I
    {
        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;
    }
}
