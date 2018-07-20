using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface MethodApiMask_I
	{
		BuildingApiMask_I Building { get; }

		EnsuringApiMask_I Ensuring { get; }

		GettingApiMask_I Getting { get; }


		bool ContainsMethodGenericParameters(MethodReference methodReference);

		bool ContainsClassGenericParameters(MethodReference methodReference);

		MethodDefinition ResolveReferenceToNonSignatureDefinition(StructuralRuntimicModelMask_I model, MethodReference methodReference);

		MethodReference ResolveSignatureReferenceToFullReference(StructuralRuntimicModelMask_I model,
			TypeReference currentType, MethodDefinition currentMethod, MethodReference signatureMethodReference);

		bool AreSame(MethodReference methodDefinition, MethodReference methodReference);
	}
}
