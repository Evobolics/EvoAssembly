using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Collections.Generic;
using Root.Code.Models.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public interface MethodApiMask_I
	{
		BuildingApiMask_I Building { get; }

		EnsuringApiMask_I Ensuring { get; }

		GettingApiMask_I Getting { get; }


		

		

		MethodDefinition ResolveReferenceToNonSignatureDefinition(RuntimicSystemModel model, MethodReference methodReference);

		bool AreSame(RuntimicSystemModel model, Collection<ParameterDefinition> a,
			Collection<ParameterDefinition> b, MethodReference bMethod);

		bool AreSame(RuntimicSystemModel model, MethodReference methodDefinition,
			MethodReference methodReference, bool resolveTypeParametersIfPresentInMethodB);

		//TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, MethodReference calledMethod,
		//	TypeReference typeToResolve);

		TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, MethodReference calledMethod,
			TypeReference typeToResolve);

		TypeReference ResolveTypeParameterIfPresent(RuntimicSystemModel model, TypeReference[] genericInstanceTypeArguments, TypeReference typeToResolve);

		string GetResolutionName(MethodReference gpDeclaringMethod);
	}
}
