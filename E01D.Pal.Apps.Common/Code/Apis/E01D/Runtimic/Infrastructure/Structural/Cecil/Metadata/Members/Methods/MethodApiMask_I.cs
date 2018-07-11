using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface MethodApiMask_I
	{
		BuildingApiMask_I Building { get; }

		EnsuringApiMask_I Ensuring { get; }

		GettingApiMask_I Getting { get; }


		bool ContainsMethodGenericParameters(MethodReference methodReference);

		bool ContainsClassGenericParameters(MethodReference methodReference);
	}
}
