using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
    public interface SemanticTypeWithInterfaceTypeList_I: SemanticTypeMask_I, SemanticTypeWithInterfaceTypeListMask_I
    {
        new SemanticTypeDefinitionInterfaces Interfaces { get; set; }
    }
}
