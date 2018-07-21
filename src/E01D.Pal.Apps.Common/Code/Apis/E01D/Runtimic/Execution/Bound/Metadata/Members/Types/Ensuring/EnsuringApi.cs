using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : BoundApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {

		#region Api(s)

		//public ArrayApi_I<TContainer> Arrays { get; set; }

	 //   ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;



	   

	   
	    public EnumApi_I<TContainer> Enums { get; set; }

	    EnumApiMask_I EnsuringApiMask_I.Enums => Enums;

	    public GenericApi_I<TContainer> GenericInstances { get; set; }

	    GenericInstanceApiMask_I EnsuringApiMask_I.GenericInstances => GenericInstances;

	    public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

	    

	    public NonGenericApi_I<TContainer> NonGenericInstances { get; set; }

	    NonGenericInstanceApiMask_I EnsuringApiMask_I.NonGenericInstances => NonGenericInstances;

	    //public PointerApi_I<TContainer> Pointers { get; set; }

	    //PointerApiMask_I EnsuringApiMask_I.Pointers => Pointers;

	    public RequiredModifierApi_I<TContainer> RequiredModifiers { get; set; }

	    RequiredModifierApiMask_I EnsuringApiMask_I.RequiredModifiers => RequiredModifiers;

		#endregion

		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, BoundEnsureContext context)
        {
	        if (context.TypeReference.IsGenericParameter) // DOES NOT USE UNDERLYING TYPE OR DECLARING TYPE
	        {
		        // You cannot create a generic parameter directly.  It is created when its parent type creates it.
		        return GenericParameters.Ensure(semanticModel, context.TypeReference);
	        }

	        //if (context.TypeReference.IsArray)
	        //{
		       // return Arrays.Ensure(semanticModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
	        //}

	        //if (context.TypeReference.IsPointer)
	        //{
		       // return Pointers.Ensure(semanticModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
	        //}

			// Prior to this point, the underlying type could have been fetched from a generic type or generic method.  After this point, it is not possible.

			if (context.UnderlyingType == null)
	        {
		        context.UnderlyingType = Models.Types.GetUnderlyingType(semanticModel, context.TypeReference);
		        
	        }

			if (context.DeclaringType == null && context.UnderlyingType?.DeclaringType != null)
	        {
		        if (context.TypeReference.IsRequiredModifier)
		        {
					// Call back to the execution's type system so it can determine where to make the type
			        context.DeclaringType = (BoundTypeDefinitionMask_I)Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, context.TypeReference.GetElementType(), context.UnderlyingType.DeclaringType, null);
				}
		        else
		        {
					// Call back to the execution's type system so it can determine where to make the type
			        context.DeclaringType = (BoundTypeDefinitionMask_I)Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, context.TypeReference.DeclaringType, context.UnderlyingType.DeclaringType, null);
				}
	        }

			

			if (context.TypeReference.IsGenericInstance)
	        {
		        return GenericInstances.Ensure(semanticModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
	        }

			
	        


			if (context.TypeReference.IsRequiredModifier)
	        {
		        return RequiredModifiers.Ensure(semanticModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
	        }
	        if (context.TypeReference.IsDefinition)
	        {
		        return NonGenericInstances.Ensure(semanticModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
	        }

	        throw new Exception("Should never have happened.  External references are now handled prior to calling this method bye the execution ensuring mechanism.");

			// External 
			//var internalTypReference = Models.Types.External.Resolve(semanticModel, context.TypeReference);


			//return Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, internalTypReference, context.UnderlyingType, context.DeclaringType);




		}


		public void EnsureTypes(BoundRuntimicModelMask_I semanticModel, BoundModule_I boundModule)
		{
			var types = boundModule.SourceModuleDefinition.Types;

			for (int i = 0; i < types.Count; i++)
			{
				var typeDefinition = types[i];

				Execution.Types.Ensuring.Ensure(semanticModel, typeDefinition, null, null);
			}
		}

	}
}
