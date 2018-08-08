using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal
{
	/// <summary>
	/// Provides functionality to manipulate types that are generic instances - i.e. closed generics
	/// </summary>
	/// <typeparam name="TContainer"></typeparam>
	public class GenericInstanceApi<TContainer> : SemanticApiNode<TContainer>, GenericInstanceApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public TypeDefinition GetElementType(RuntimicSystemModel semanticModel, SemanticTypeDefinitionMask_I bound)
		{
			var genericInstanceType = (GenericInstanceType)bound.SourceTypeReference;

			return GetElementType(semanticModel, genericInstanceType);

		}

		public TypeDefinition GetElementType(RuntimicSystemModel model, GenericInstanceType genericInstanceType)
		{
			// ERROR - can not be a type definition when this is an external reference.
			// FIX along with the other code.
			// FYI - with fields, its is not all or nothing.  TRy test case GenericType<A, B> and then a field GenericType<string, B>, wher there is another field
			// named public A Somefield that has been filled in.  The fact that it has to copy the collection just tells me that the lookup algorithm needs to fall back
			// onto the generic base.  
			var elementType = genericInstanceType.ElementType;

			return GetElementType_Internal(model, elementType);
		}

		private TypeDefinition GetElementType_Internal(RuntimicSystemModel model, TypeReference elementType)
		{
			if (elementType.IsDefinition)
			{
				return (TypeDefinition)elementType;
			}
			else if (elementType.IsGenericInstance)
			{
				var genericInstanceType = (GenericInstanceType)elementType;

				return GetElementType_Internal(model, genericInstanceType);
			}
			else
			{
				// External Reference
				// 1) CHANGE CODE TO RESOLVE EXTERNAL REFERENCE - Make method specific for this
				// 2) Make this selement  type function resuable as we we will need it again / use the value already determeind. 
				// 1.b) The resolve external reference needs to do hte looking for assemlby thing, and make sure those types are loaded if not.
				//var reference = Infrastructure.Models.Structural.Types.External.Resolve(model, elementType); // GetStoredTypeReference
				var node = Infrastructure.Structural.Types.Ensure(model, elementType);

				return GetElementType_Internal(model, node.CecilTypeReference);

			}
		}
	}
}
