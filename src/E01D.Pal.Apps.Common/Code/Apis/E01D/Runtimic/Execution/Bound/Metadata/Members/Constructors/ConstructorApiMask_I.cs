using System.Reflection;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Constructors
{
    public interface ConstructorApiMask_I
    {
		//void Declare(MethodEntry methodEntry);

		BuildingApiMask_I Building { get; }
		ConstructorInfo FindConstructorBySignature(RuntimicSystemModel conversionModel, BoundTypeDefinitionMask_I declaringType, MethodReference methodReference);
    }
}
