namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface ConvertedType_I: ConvertedMember_I, ConvertedTypeMask_I
    {
	    new ConversionState ConversionState { get; set; }
	}
}
