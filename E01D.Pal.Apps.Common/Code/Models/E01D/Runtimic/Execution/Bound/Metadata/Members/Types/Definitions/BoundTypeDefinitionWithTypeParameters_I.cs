namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundTypeDefinitionWithTypeParameters_I: BoundTypeDefinitionWithTypeParametersMask_I
    {
        new BoundGenericParameterTypeDefinitions_I TypeParameters { get; }
    }
}
