using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedConstructorCallInformation: ConvertedMethodCallInformation, ConvertedConstructorCallInformationMask_I
    {
        public BoundTypeDefinitionWithConstructorsMask_I DeclaringTypeWithConstructors { get; set; }
        
        public bool CallingBaseConstructor { get; set; }

        public bool DeclaringTypeHasTypeArgumentsThatAreTypeParameters { get; set; }
    }
}
