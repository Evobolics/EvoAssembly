namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticTypeDefinitionWithTypeParameters_I: SemanticTypeDefinitionWithTypeParametersMask_I
    {
        new SemanticGenericParameterTypeDefinitionsMask_I TypeParameters { get; set; }
    }
}
