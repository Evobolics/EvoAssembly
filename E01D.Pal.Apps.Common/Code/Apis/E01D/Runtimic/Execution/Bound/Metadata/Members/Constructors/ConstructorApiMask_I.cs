using System.Reflection;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors.Building;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Constructors
{
    public interface ConstructorApiMask_I
    {
		//void Declare(MethodEntry methodEntry);

		BuildingApiMask_I Building { get; }
		ConstructorInfo FindConstructorBySignature(InfrastructureModelMask_I conversionModel, BoundTypeDefinitionMask_I declaringType, MethodReference methodReference);
    }
}
