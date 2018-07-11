namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public interface ConvertedTypeDefinitionWithTypeParameters_I: ConvertedTypeDefinitionWithTypeParametersMask_I
    {
        new ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; }
    }
}
