using System;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface EnsuringApiMask_I
	{
		TypeReference EnsureInternalTypeReference(InfrastructureModelMask_I model, TypeReference typeReference);

		TypeReference ResolveExternalTypeReference(InfrastructureModelMask_I model, TypeReference externalReference);

		TypeReference EnsureInternalTypeReference(InfrastructureModelMask_I model, Type input);
	}
}
