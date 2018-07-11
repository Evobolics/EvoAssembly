using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public interface ConvertedBuiltMethod_I: ConvertedBuiltMethodMask_I, ConvertedMemberWithTypeParameters_I
    {
	    new ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; }
	}
}
