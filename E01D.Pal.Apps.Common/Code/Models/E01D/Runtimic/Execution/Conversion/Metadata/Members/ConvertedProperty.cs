using System.Reflection;
using System.Reflection.Emit;
using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedProperty: ConvertedMember, ConvertedPropertyMask_I
    {
        public PropertyBuilder Builder { get; set; }

        public PropertyInfo UnderlyingPropertyInfo { get; set; }

        public MemberInfo UnderlyingMember => Builder;
	    public PropertyDefinition PropertyDefinition { get; set; }
    }
}
