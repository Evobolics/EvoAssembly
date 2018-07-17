using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
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

		public ArrayApi_I<TContainer> Arrays { get; set; }

	    ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;



	   

	   
	    public EnumApi_I<TContainer> Enums { get; set; }

	    EnumApiMask_I EnsuringApiMask_I.Enums => Enums;

	    public GenericApi_I<TContainer> GenericInstances { get; set; }

	    GenericInstanceApiMask_I EnsuringApiMask_I.GenericInstances => GenericInstances;

	    public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

	    

	    public NonGenericApi_I<TContainer> NonGenericInstances { get; set; }

	    NonGenericInstanceApiMask_I EnsuringApiMask_I.NonGenericInstances => NonGenericInstances;

	    public PointerApi_I<TContainer> Pointers { get; set; }

	    PointerApiMask_I EnsuringApiMask_I.Pointers => Pointers;

	    public RequiredModifierApi_I<TContainer> RequiredModifiers { get; set; }

	    RequiredModifierApiMask_I EnsuringApiMask_I.RequiredModifiers => RequiredModifiers;

		#endregion

		/// <summary>
		/// Ensures the type is part of the module.
		/// </summary>
		public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, TypeReference input, System.Type underlyingType, BoundTypeDefinitionMask_I declaringType)
        {
	        if (input.FullName == "System.Action`1<System.Reflection.Emit.ILGenerator>")
	        {
		        
	        }

	        // Should be Tabular.Cecil.
	        if (Cecil.Types.IsExternal(input))
	        {
		        input = Models.Types.External.Resolve(semanticModel, input);
	        }

	        if (input.Name == "Api`1" && input.IsGenericInstance)
	        {
		        
	        }

			if (underlyingType == null)
	        {
		        underlyingType = Models.Types.GetUnderlyingType(semanticModel, input);
		        
	        }

			if (declaringType == null && underlyingType?.DeclaringType != null)
	        {
		        if (input.IsRequiredModifier)
		        {
					// Call back to the execution's type system so it can determine where to make the type
					declaringType = (BoundTypeDefinitionMask_I)Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, input.GetElementType(), underlyingType.DeclaringType, null);
				}
		        else
		        {
			        // Call back to the execution's type system so it can determine where to make the type
					declaringType = (BoundTypeDefinitionMask_I)Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, input.DeclaringType, underlyingType.DeclaringType, null);
				}
	        }

			if (input.IsArray)
	        {
		        return Arrays.Ensure(semanticModel, input, declaringType, underlyingType);
	        }

	        if (input.IsGenericInstance)
	        {
		        return GenericInstances.Ensure(semanticModel, input, declaringType, underlyingType);
	        }

			if (input.IsGenericParameter)
	        {
		        // You cannot create a generic parameter directly.  It is created when its parent type creates it.
		        return GenericParameters.Ensure(semanticModel, input);
	        }
	        if (input.IsPointer)
	        {
		        return Pointers.Ensure(semanticModel, input, declaringType, underlyingType);
	        }


			if (input.IsRequiredModifier)
	        {
		        return RequiredModifiers.Ensure(semanticModel, input, declaringType, underlyingType);
	        }
	        if (input.IsDefinition)
	        {
		        return NonGenericInstances.Ensure(semanticModel, input, declaringType, underlyingType);
	        }

			// Extenral 
	        var internalTypReference = Models.Types.External.Resolve(semanticModel, input);

	        return Execution.Metadata.Members.Types.Ensuring.Ensure(semanticModel, internalTypReference, underlyingType, declaringType);



	       
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
