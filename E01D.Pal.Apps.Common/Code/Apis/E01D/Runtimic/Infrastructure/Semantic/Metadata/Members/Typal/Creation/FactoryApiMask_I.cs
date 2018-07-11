using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Creation
{
    public interface FactoryApiMask_I
    {
        object CreateType
        <
            TGenericStructTypeDefinition,
            TGenericDelegateTypeDefinition,
            TGenericClassTypeDefinition,
            TGenericInterfaceTypeDefinition,
            TGenericNestedStructTypeDefinition,
            TGenericNestedDelegateTypeDefinition,
            
            TGenericNestedClassTypeDefinition,
            TGenericNestedInterfaceTypeDefinition,
            TNestedEnumTypeDefinition,
            TNestedStructTypeDefinition,
            TNestedDelegateTypeDefinition,
            
            TNestedClassTypeDefinition,
            TNestedInterfaceTypeDefinition,
            TSimpleClTypeDefinition,
            TEnumTypeDefinition,
            TStructTypeDefinition,
            TDelegateTypeDefinition,
            TArrayTypeDefinition,
            TClassTypeDefinition,
            TInterfaceTypeDefinition,
	        TPointerTypeDefinition,
	        TRequiredModifierTypeDefinition>(SemanticTypeInformation typeInformation)
            where TGenericNestedStructTypeDefinition : new()
            where TGenericNestedDelegateTypeDefinition : new()
            
            where TGenericNestedClassTypeDefinition : new()
            where TGenericNestedInterfaceTypeDefinition : new()
            
            where TGenericStructTypeDefinition : new()
            where TGenericDelegateTypeDefinition : new()
            where TGenericClassTypeDefinition : new()
            where TGenericInterfaceTypeDefinition : new()
            where TNestedEnumTypeDefinition : new()
            where TNestedStructTypeDefinition : new()
            where TNestedDelegateTypeDefinition : new()
            
            where TNestedClassTypeDefinition : new()
            where TNestedInterfaceTypeDefinition : new()
            where TSimpleClTypeDefinition : new()
            where TEnumTypeDefinition : new()
            where TStructTypeDefinition : new()
            where TDelegateTypeDefinition : new()
            where TArrayTypeDefinition : new()
            where TClassTypeDefinition : new()
            where TInterfaceTypeDefinition : new()
			where TPointerTypeDefinition: new()
	        where TRequiredModifierTypeDefinition : new();

	}
}
