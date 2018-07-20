using System;
using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Types
{
	public interface EnsuringApiMask_I
	{
		CecilTypeReferenceSet EnsureReferences(InfrastructureRuntimicModelMask_I model, Type[] types);

		CecilTypeReferenceSet EnsureReferences(InfrastructureRuntimicModelMask_I model, List<TypeReference> types);



		TypeReference EnsureReference(InfrastructureRuntimicModelMask_I model, Type type);
	}
}
