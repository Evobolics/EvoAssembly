using System.Reflection;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members
{
	public abstract class ConvertedMethod: ConvertedRoutine, ConvertedMethodMask_I, ConvertedMemberWithTypeParameters_I
	{
		public MethodAttributes MethodAttributes { get; set; }

		

		public override MemberInfo UnderlyingMember => UnderlyingMethod_Get();
		public MethodInfo UnderlyingMethod => UnderlyingMethod_Get();

		protected abstract MethodInfo UnderlyingMethod_Get();

		// TODO: // turn into extension method
		public override bool IsConstructor() => false;

		// TODO: // turn into extension method
		public override bool IsMethod() => true;

		public ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; } = new ConvertedGenericParameterTypeDefinitions();


		ConvertedGenericParameterTypeDefinitionsMask_I ConvertedMemberWithTypeParametersMask_I.TypeParameters => TypeParameters;

		BoundGenericParameterTypeDefinitionsMask_I BoundMemberWithTypeParametersMask_I.TypeParameters => TypeParameters;

		SemanticGenericParameterTypeDefinitionsMask_I SemanticMethodMask_I.TypeParameters => TypeParameters;
	}
}
