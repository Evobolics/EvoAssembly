namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public interface ConvertedTypeDefinitionWithTypeParameters_I: ConvertedTypeDefinitionWithTypeParametersMask_I, ConvertedTypeDefinition_I
    {
        new ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; }
    }
}
