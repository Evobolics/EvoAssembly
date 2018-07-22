using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : ExecutionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public ArrayApi_I<TContainer> Arrays { get; set; }

	    ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;

	    public ByReferenceApi_I<TContainer> ByReferences { get; set; }

	    ByReferenceApiMask_I EnsuringApiMask_I.ByReferences => ByReferences;

	    public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

		public PointerApi_I<TContainer> Pointers { get; set; }

	    PointerApiMask_I EnsuringApiMask_I.Pointers => Pointers;

        public System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    return EnsureToType(model, typeReference, out BoundTypeDefinitionMask_I boundType);
	    }

	    public System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
		    return EnsureToType(model, typeReference, null, out boundType);
	    }

	    public System.Type EnsureToType(BoundRuntimicModelMask_I model, TypeReference typeReference, System.Type underlyingType, out BoundTypeDefinitionMask_I boundType)
	    {
		    var context = new BoundEnsureContext()
		    {
			    UnderlyingType = underlyingType,
			    TypeReference = typeReference
		    };

		    return EnsureToType(model, context, out boundType);
        }

	    public System.Type EnsureToType(BoundRuntimicModelMask_I model, BoundEnsureContext context)
	    {
		    return EnsureToType(model, context, out BoundTypeDefinitionMask_I boundType);
	    }

		public System.Type EnsureToType(BoundRuntimicModelMask_I model, BoundEnsureContext context, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = EnsureBound(model, context);

		    return EnsureToType(boundType);

	    }

		public System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType)
	    {
		    return EnsureToType(semanticType, out BoundTypeDefinitionMask_I resultingBound);
	    }

	    public System.Type EnsureToType(SemanticTypeDefinitionMask_I semanticType, out BoundTypeDefinitionMask_I resultingBound)
	    {
		    // Can only build and bake types that are definitions.  References cannot be turned into full types.
		    if (!(semanticType is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception("A semantic type must be a bound type to be resolved to a runtime type.");
		    }

		    resultingBound = bound;

		    return EnsureToType(bound);
	    }

	    public System.Type EnsureToType(BoundTypeDefinitionMask_I boundType)
	    {
		    var underlyingType = boundType.UnderlyingType;

		    if (underlyingType == null)
		    {
			    throw new System.Exception("Expected the underlying type to be filled in with a instance of a runtime type.");
		    }

		    return underlyingType;
	    }

		public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I model, TypeReference typeReference)
	    {
		    // Done collecting arguments, now use context.
		    var context = new BoundEnsureContext()
		    {
			    UnderlyingType = null,
			    TypeReference = typeReference
		    };

		    return EnsureBound(model, context);
        }

	    public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I model, System.Type type)
	    {
		    // Done collecting arguments, now use context.
		    var context = new BoundEnsureContext()
		    {
			    UnderlyingType = type,
			    TypeReference = null
		    };

		    return EnsureBound(model, context);
	    }

	    public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I model, TypeReference typeReference, System.Type type)
	    {
		    // Done collecting arguments, now use context.
		    var context = new BoundEnsureContext()
		    {
			    UnderlyingType = type,
			    TypeReference = typeReference
		    };

		    return EnsureBound(model, context);
        }


        public BoundTypeDefinitionMask_I EnsureBound(BoundRuntimicModelMask_I model, BoundEnsureContext context)
	    {
		    var semanticMask = Ensure(model, context);

		    if (!(semanticMask is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
		    }

		    return bound;
	    }

        /// <summary>
        /// Ensures the type is part of the module.
        /// </summary>
        /// <param name="semanticModel"></param>
        /// <param name="semanticModule"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I semanticModel, Type input)
	    {
			var typeReference = Bound.Models.Types.GetTypeReference(semanticModel, input);

		    return Ensure(semanticModel, typeReference, input, null);
	    }

	    public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, TypeReference typeReference,
		    System.Type underlyingType, BoundTypeDefinitionMask_I declaringType)
	    {
		    var context = new BoundEnsureContext()
		    {
			    UnderlyingType = underlyingType,
			    TypeReference = typeReference,
                DeclaringType= declaringType
            };

		    return Ensure(boundModel, context);
	    }

	    public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, BoundEnsureContext context)
		{
            // Make sure valid search criteria is set.
			if (context.TypeReference == null && context.UnderlyingType == null)
			{
				throw new Exception("Cannot ensure a type without an either at type reference to locate or a type to locate.");
			}

			if (context.TypeReference?.FullName == "Root.Testing.Resources.Models.E01D.Runtimic.Execution.Emitting.Conversion.Inputs.Types.Custom1Attribute")
			{
				
			}

			if (context.TypeReference.FullName ==
			    "Root.Code.Containers.E01D.Runtimic.RuntimicContainer_I`1<TContainer>"
			)
			{

			}

			// The entire ensure algorithm works on making sure a semantic type exists for a type reference.  If a type reference is not passed in, 
			// then the only other arugument 
			if (context.TypeReference == null)
			{
				context.TypeReference = Infrastructure.Models.Semantic.Types.GetTypeReference(boundModel, context.UnderlyingType, out SemanticTypeDefinitionMask_I possibleSemanticType);

				if (possibleSemanticType != null && possibleSemanticType is BoundTypeDefinitionMask_I bound1)
				{
					return bound1;
				}
			}
			// If the type reference is an external reference, then it needs to be resolved to a type reference that is associated with one of the loaded
			// assemblies prior to determining if the type reference needs to be treated as a converted type or a bound type.
            else if(Cecil.Types.IsExternal(context.TypeReference))
			{
				// came from bound
				context.TypeReference = Infrastructure.Models.Structural.Types.External.Resolve(boundModel, context.TypeReference);
			}
			

			// Move ByRef
			// Move Pointer

			if (context.TypeReference.IsByReference)
			{
				
				return ByReferences.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
			}

			if (context.TypeReference.IsPointer)
			{
				return Pointers.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
			}

			// Move Array - needs to come after by ref and pointer as either can wrap an array type.
			if (context.TypeReference.IsArray)
			{
				return Arrays.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
			}

			if (context.TypeReference.IsGenericParameter)
			{
				// You cannot create a generic parameter directly.  It is created when its parent type creates it.
				return GenericParameters.Ensure(boundModel, context);
			}

			// Check to see if this input is to be converted, or needs to be relegated to bound only.
			if (Types.IsConverted(boundModel, context.TypeReference)) // The call does not belong to the conversion code because 
			{
				var conversionModel = (ILConversionRuntimicModel)boundModel;

				return Conversion.Metadata.Members.Types.Ensuring.Ensure(conversionModel.Conversion, context.TypeReference, (ConvertedTypeDefinition_I)context.DeclaringType);

			}
			else
			{
				return Bound.Metadata.Members.Types.Ensuring.Ensure(boundModel, context);
			}
			
		}











	}
}
