using System;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Metadata.Members.Types
{
    public interface TypeApiMask_I
    {
	    StructuralTypeNode Ensure(RuntimicSystemModel model, Type type);
		StructuralTypeNode Ensure(RuntimicSystemModel runtimicSystem, TypeReference typeReference);

	    
	    StructuralTypeNode Ensure(RuntimicSystemModel runtimicSystemModel, StructuralModuleNode structuralModuleNode, TypeReference typeDefinition);

	    StructuralTypeNode Ensure(RuntimicSystemModel model, TypeReference typeReference, TypeReference declaringType, MethodReference declaringMethod);
    }
}
