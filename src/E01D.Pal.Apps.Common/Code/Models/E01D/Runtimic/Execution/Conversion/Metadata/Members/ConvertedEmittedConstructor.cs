using System.Reflection;
using System.Reflection.Emit;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
    public class ConvertedEmittedConstructor: ConvertedConstructor
	{
        public ConstructorBuilder ConstructorBuilder { get; set; }

        public bool IsInstanceConstructor { get; set; }

        public bool IsStaticConstructor { get; set; }

        protected override ConstructorInfo Get_UnderlyingConstructor() => ConstructorBuilder;

        public override MemberInfo UnderlyingMember => ConstructorBuilder;

        
    }
}
