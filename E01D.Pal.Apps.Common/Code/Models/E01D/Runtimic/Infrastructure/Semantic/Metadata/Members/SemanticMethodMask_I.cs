using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members
{
    public interface SemanticMethodMask_I: SemanticRoutineMask_I
    {
        SemanticGenericParameterTypeDefinitionsMask_I TypeParameters { get;  }

        
    }
}
