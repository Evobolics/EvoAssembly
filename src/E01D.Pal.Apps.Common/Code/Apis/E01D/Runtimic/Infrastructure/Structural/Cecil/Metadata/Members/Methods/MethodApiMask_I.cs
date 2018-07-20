using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface MethodApiMask_I
	{
		BuildingApiMask_I Building { get; }

		EnsuringApiMask_I Ensuring { get; }

		GettingApiMask_I Getting { get; }


		

		

		MethodDefinition ResolveReferenceToNonSignatureDefinition(StructuralRuntimicModelMask_I model, MethodReference methodReference);

		bool AreSame(StructuralRuntimicModelMask_I model, Collection<ParameterDefinition> a,
			Collection<ParameterDefinition> b, MethodReference bMethod);

		bool AreSame(StructuralRuntimicModelMask_I model, MethodReference methodDefinition,
			MethodReference methodReference, bool resolveTypeParametersIfPresentInMethodB);

		TypeReference ResolveTypeParameterIfPresent(StructuralRuntimicModelMask_I model, MethodReference calledMethod,
			TypeReference typeToResolve);
	}
}
