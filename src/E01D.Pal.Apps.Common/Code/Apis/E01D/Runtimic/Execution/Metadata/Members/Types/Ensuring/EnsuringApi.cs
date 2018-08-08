using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Structural.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : ExecutionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    public ArrayApi_I<TContainer> Arrays { get; set; }

	    ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;

	    public ByReferenceApi_I<TContainer> ByReferences { get; set; }

	    ByReferenceApiMask_I EnsuringApiMask_I.ByReferences => ByReferences;

	    public DefinitionTypeApi_I<TContainer> DefinitionTypes { get; set; }

	    DefinitionTypeApiMask_I EnsuringApiMask_I.DefinitionTypes => DefinitionTypes;

	    public GenericInstanceTypeApi_I<TContainer> GenericInstanceTypes { get; set; }

	    GenericInstanceTypeApiMask_I EnsuringApiMask_I.GenericInstanceTypes => GenericInstanceTypes;

		public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

		public PointerApi_I<TContainer> Pointers { get; set; }

	    PointerApiMask_I EnsuringApiMask_I.Pointers => Pointers;

        public System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference)
	    {
		    return EnsureToType(model, typeReference, out BoundTypeDefinitionMask_I boundType);
	    }

	    public System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
		    return EnsureToType(model, typeReference, null, out boundType);
	    }

	    public Type EnsureToType(ILConversion conversion, TypeReference typeReference)
	    {
		    return EnsureToType(conversion, typeReference, out BoundTypeDefinitionMask_I boundType);
	    }

		public Type EnsureToType(ILConversion conversion, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
			var context = new ExecutionEnsureContext()
		    {
				Conversion = conversion,
			    RuntimicSystem = conversion.RuntimicSystem,
			    TypeReference = typeReference
		    };

		    return EnsureToType(context, out boundType);
		}

		public System.Type EnsureToType(RuntimicSystemModel model, TypeReference typeReference, System.Type underlyingType, out BoundTypeDefinitionMask_I boundType)
	    {
		    var context = new ExecutionEnsureContext()
		    {
				RuntimicSystem = model,
				UnderlyingType = underlyingType,
			    TypeReference = typeReference
		    };

		    return EnsureToType(context, out boundType);
        }

	    

	    public System.Type EnsureToType(ExecutionEnsureContext context)
	    {
		    return EnsureToType(context, out BoundTypeDefinitionMask_I boundType);
	    }

		public System.Type EnsureToType(ExecutionEnsureContext context, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = EnsureBound(context);

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

	    public BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext newContext, TypeReference genericArgument)
	    {
		    newContext.TypeReference = genericArgument;

		    return EnsureBound(newContext);
		}

	    public BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext context, TypeReference genericArgument, bool cloneContext)
	    {
		    if (cloneContext)
		    {
			    context = Execution.Types.Ensuring.CloneEnvironmentParameters(context);
		    }

		    context.TypeReference = genericArgument;

		    return EnsureBound(context);
	    }

	    public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference)
	    {
		    // Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
			    RuntimicSystem = conversion.RuntimicSystem,
			    Conversion = conversion,
			    TypeReference = typeReference
		    };

		    return EnsureBound(context);
	    }


		public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference,
		    ConvertedTypeDefinition_I declaringType)
	    {
			// Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
			    RuntimicSystem = conversion.RuntimicSystem,
				Conversion = conversion,
			    DeclaringType = declaringType,
			    TypeReference = typeReference
		    };

		    return EnsureBound(context);
		}

		public BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel model, TypeReference typeReference)
	    {
		    // Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
				RuntimicSystem = model,
				UnderlyingType = null,
			    TypeReference = typeReference
		    };

		    return EnsureBound(context);
        }

	    public BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel model, System.Type type)
	    {
		    // Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
			    RuntimicSystem = model,
				UnderlyingType = type,
			    TypeReference = null
		    };

		    return EnsureBound(context);
	    }

	    public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, System.Type type)
	    {
		    // Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
			    RuntimicSystem = conversion.RuntimicSystem,
				Conversion = conversion,

			    UnderlyingType = type,
			    TypeReference = null
		    };

		    return EnsureBound(context);
	    }

		public BoundTypeDefinitionMask_I EnsureBound(RuntimicSystemModel model, TypeReference typeReference, System.Type type)
	    {
		    // Done collecting arguments, now use context.
		    var context = new ExecutionEnsureContext()
		    {
			    RuntimicSystem = model,
				UnderlyingType = type,
			    TypeReference = typeReference
		    };

		    return EnsureBound(context);
        }


        public BoundTypeDefinitionMask_I EnsureBound(ExecutionEnsureContext context)
	    {
		    var semanticMask = Ensure(context).Type;

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
        public ExecutionTypeDefinitionMask_I Ensure(RuntimicSystemModel runtimicModel, Type input)
	    {
		    return Ensure(runtimicModel, null, input, null);
	    }



	    public ExecutionTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference typeReference,
		    System.Type underlyingType, BoundTypeDefinitionMask_I declaringType)
	    {
		    var context = new ExecutionEnsureContext()
		    {
			    UnderlyingType = underlyingType,
			    TypeReference = typeReference,
			    DeclaringType = declaringType,
			    RuntimicSystem = conversion.RuntimicSystem,
				Conversion = conversion
			};

		    return Ensure(context).Type;
	    }

		public ExecutionTypeDefinitionMask_I Ensure(RuntimicSystemModel runtimicModel, TypeReference typeReference,
		    System.Type underlyingType, BoundTypeDefinitionMask_I declaringType)
	    {
		    var context = new ExecutionEnsureContext()
		    {
			    UnderlyingType = underlyingType,
			    TypeReference = typeReference,
                DeclaringType= declaringType,
				RuntimicSystem = runtimicModel
			};

		    return Ensure(context).Type;
	    }



		//public SemanticTypeDefinitionMask_I Ensure(BoundRuntimicModelMask_I boundModel, ExecutionEnsureContext context)
		//{
		//          // Make sure valid search criteria is set.
		//	if (context.TypeReference == null && context.UnderlyingType == null)
		//	{
		//		throw new Exception(
		//			"A bound or converted type entry cannot be ensured without either a 'metadata type definition/reference' " +
		//			"or a 'runtime type' (System.Type).");
		//	}



		//	// The entire ensure algorithm works on making sure a semantic type exists for a type reference.  If a type reference is not passed in, 
		//	// then the only other arugument to ensure that the type is ensure is the runtime type.
		//	if (context.TypeReference == null)
		//	{
		//		context.TypeReference = Infrastructure.Models.Semantic.Types.GetTypeReference(boundModel, context.UnderlyingType, out SemanticTypeDefinitionMask_I possibleSemanticType);

		//		if (possibleSemanticType != null && possibleSemanticType is BoundTypeDefinitionMask_I bound1)
		//		{
		//			return bound1;
		//		}
		//	}


		//	// Now that it known that the type reference Ensures an entry in the unified model.
		//	var unifiedNode = Unified.Types.Ensure(boundModel, context.TypeReference);

		//	// If the type reference is by reference node, an underlying pointer node, an array node or a generic parameter node,
		//	// then it is a secondary node.  The primary node will need to be looked up first, and the secondary node will need to be determined second.
		//	// Only once the secondary node is resolved can a bound or converted execution type be associated with the unified model.
		//	if (unifiedNode.IsPrimary)
		//	{
		//		// Check to see if this input is to be converted, or needs to be relegated to bound only.
		//		if (Types.IsConverted(boundModel, context.TypeReference)) // The call does not belong to the conversion code because 
		//		{
		//			var conversionModel = (ILConversionRuntimicModel)boundModel;

		//			return Conversion.Metadata.Members.Types.Ensuring.Ensure(conversionModel.Conversion, context.TypeReference, (ConvertedTypeDefinition_I)context.DeclaringType);

		//		}
		//		else
		//		{
		//			return Bound.Metadata.Members.Types.Ensuring.Ensure(boundModel, context);
		//		}
		//	}
		//	else
		//	{
		//		return EnsureSecondaryNode(boundModel, context);
		//	}



		//}

		public ExecutionTypeNode_I Ensure(ILConversion conversion, TypeReference typeReference, ConvertedTypeDefinition_I declaringType)
		{
			var context = new ExecutionEnsureContext()
			{
				DeclaringType = declaringType,
				TypeReference = typeReference,
				Conversion = conversion,
				RuntimicSystem = conversion.RuntimicSystem
			};

			return Ensure(context);
		}

	    public ExecutionEnsureContext CloneEnvironmentParameters(ExecutionEnsureContext context)
	    {
		    return new ExecutionEnsureContext()
		    {
			    RuntimicSystem = context.RuntimicSystem,
			    Conversion = context.Conversion
		    };
	    }

	    public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context, TypeReference genericArgument, bool cloneContext)
	    {
		    if (cloneContext)
		    {
			    context = Execution.Types.Ensuring.CloneEnvironmentParameters(context);
		    }

		    context.TypeReference = genericArgument;

		    return Ensure(context);
	    }

		/// <summary>
		/// Ensures the execution type system has a type entry for the specified type reference, type, or structural input type node.
		/// </summary>
		/// <param name="context"></param>
		public ExecutionTypeNode_I Ensure(ExecutionEnsureContext context)
	    {
			//if (inputType.InputStructuralNode.CecilTypeReference.Name != "<Module>")
			//{
			//	Execution.Types.Ensuring.Ensure(conversion.RuntimicSystem, inputType);
			//}

			if (context?.TypeReference?.FullName ==
			    "System.Collections.Generic.Dictionary`2<System.String,Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.SemanticTypeMask_I>"
			)
			{

			}

			// Step 1 - Get Strcutral input type node
			if (context.StructuralInputTypeNode == null)
		    {
			    if (context.TypeReference != null)
			    {
				    context.StructuralInputTypeNode = Infrastructure.Structural.Types.Ensure(context.RuntimicSystem, context.TypeReference, null, context.MethodReference);
				}
			    else if (context.UnderlyingType != null)
			    {
					context.StructuralInputTypeNode = Infrastructure.Structural.Types.Ensure(context.RuntimicSystem, context.UnderlyingType);
			    }
			    else
			    {
					throw new Exception("A bound or converted type entry cannot be ensured without either a 'metadata type definition/reference' " +
					                    "or a 'runtime type' (System.Type).");
				}
			}

		    if (context.TypeReference == null)
		    {
			    context.TypeReference = context.StructuralInputTypeNode.CecilTypeReference;
		    }

		    var metadataToken = context.StructuralInputTypeNode.MetadataToken;

		    context.RowId = metadataToken & 0x00FFFFFF;

		    
			// Step 3 - Build out the execution node
			if (context.StructuralInputTypeNode.IsByReferenceType)
			{
				return ByReferences.Ensure(context);
			}

			// Depends upon the underlying unified entry
			if (context.StructuralInputTypeNode.IsPointerType)
			{
				return Pointers.Ensure(context);
			}

			// Depends upon the underlying unified entry
			if (context.StructuralInputTypeNode.IsArrayType)
			{
				return Arrays.Ensure(context);
			}
		    

		    // Depends upon the underlying unified entry
		    if (context.StructuralInputTypeNode.IsGenericParameter)
		    {
			    // You cannot create a generic parameter directly.  It is created when its parent type creates it.
			    return GenericParameters.Ensure(context);
		    }

		    

		    context.IsConverted = IsConverted(context);

		    if (context.StructuralInputTypeNode.IsGenericInstance)
		    {
			    // You cannot create a generic parameter directly.  It is created when its parent type creates it.
			    return GenericInstanceTypes.Ensure(context);
		    }

			return DefinitionTypes.Ensure(context);
		}

	    

	    private BoundTypeNode EnsureBoundNode(ExecutionEnsureContext context, StructuralTypeNode structuralInputTypeNode)
	    {
		    throw new NotImplementedException();
	    }

		//private ConversionTypeNode EnsureConversionNode(ExecutionEnsureContext context, StructuralTypeNode structuralInputTypeNode)
	 //   {
		//    var metadataToken = structuralInputTypeNode.MetadataToken;

		//	var rowId = metadataToken & 0x00FFFFFF;

		//    bool isDerived = rowId < 1;

		//    if (isDerived)
		//    {
		//	    if (structuralInputTypeNode.IsPointerType)
		//	    {
		//		    var pointerStemType = Ensure(context, structuralInputTypeNode.StemType);

		//		    if (pointerStemType.PointerType != null)
		//		    {
		//			    return pointerStemType.PointerType;
		//		    }

		//		    pointerStemType.PointerType = new ConversionTypeNode()
		//		    {
		//			    IsPointerType = true,
		//			    StemType = pointerStemType,
		//			    IsDerived = true,
		//			    MetadataToken = metadataToken,
		//			    InputStructuralNode = structuralInputTypeNode
		//			};

		//		    return pointerStemType.PointerType;
		//	    }

		//	    if (structuralInputTypeNode.IsByReferenceType)
		//	    {
		//		    var byRefStemType = EnsureConversionNode(context, structuralInputTypeNode.StemType);

		//		    if (byRefStemType.ByReferenceType != null)
		//		    {
		//			    return byRefStemType.ByReferenceType;
		//		    }

		//		    byRefStemType.ByReferenceType = new ConversionTypeNode()
		//		    {
		//			    IsByReferenceType = true,
		//			    StemType = byRefStemType,
		//			    IsDerived = true,
		//				MetadataToken = metadataToken,
		//			    InputStructuralNode = structuralInputTypeNode
		//			};

		//		    return byRefStemType.ByReferenceType;
		//	    }

		//	    throw new Exception("Derived type (arrays, generics?) not handled");


		//    }

		//    var structuralAssembly = Conversion.Metadata.Assemblies.EnsureNode(context.Conversion, structuralInputTypeNode.Module.Assembly);

		//    var convertedModuleNode = Conversion.Metadata.Modules.Ensure(context.Conversion, structuralAssembly, structuralInputTypeNode.Module);

		//    var tableId = (int)(metadataToken & 0xFF000000);

		//    if (!convertedModuleNode.Tables.TryGetValue(tableId, out ConvertedTypeTable table))
		//    {
		//	    table = new ConvertedTypeTable();

		//	    convertedModuleNode.Tables.Add(tableId, table);
		//    }

		//    if (table.ByRow.TryGetValue(rowId, out ConversionTypeNode conversionTypeNode))
		//    {
		//	    return conversionTypeNode;
		//    }

		//	// Have a derived type
		//	// Have a non-derived type / thus stored type


		//    conversionTypeNode = new ConversionTypeNode()
		//    {
		//	    InputStructuralNode = structuralInputTypeNode,
		//	    MetadataToken = metadataToken,
		//		Module = convertedModuleNode,
		//		Assembly = structuralAssembly
		//	};

		//    table.ByRow.Add(rowId, conversionTypeNode);

		//    return conversionTypeNode;
		//}

	    private bool IsConverted(ExecutionEnsureContext context)
	    {
		    var isConverted = context.IsConverted;

		    if (isConverted != null)
		    {
			    return isConverted.Value;
		    }

		    if (context.Conversion == null)
		    {
			    return false;
		    }

			var result = IsConverted(context.Conversion, context.StructuralInputTypeNode);

		    context.IsConverted = result;

		    return result;
	    }

	    public bool IsConverted(ILConversion conversion, StructuralTypeNode structuralNode)
	    {
		    if (!structuralNode.IsDerived)
		    {
			    return conversion.MetadataModel.Assemblies.BySourceName.ContainsKey(structuralNode.Module.Assembly.FullName);
			}

		    if (!structuralNode.IsGenericInstance)
			{
				return IsConverted(conversion, structuralNode.StemType);
			}

			if (IsConverted(conversion, structuralNode.StemType)) return true;

			StructuralGenericInstanceTypeNode genericInstance = (StructuralGenericInstanceTypeNode) structuralNode;

			for (int i = 0; i < genericInstance.GenericArguments.Length; i++)
			{
				if (IsConverted(conversion, genericInstance.GenericArguments[i])) return true;
			}

			return false;
		}


	   

	    public void Ensure(ILConversionRuntimicModel model, ConversionTypeNode inputType)
	    {
		    
	    }

	    private SemanticTypeDefinitionMask_I EnsureSecondaryNode(RuntimicSystemModel boundModel, ExecutionEnsureContext context)
	    {
			//// Depends upon the underlying unified entry
		 //   if (context.TypeReference.IsByReference)
		 //   {
			//    return ByReferences.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
		 //   }

		 //   // Depends upon the underlying unified entry
		 //   if (context.TypeReference.IsPointer)
		 //   {
			//    return Pointers.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
		 //   }

		 //   // Depends upon the underlying unified entry
		 //   if (context.TypeReference.IsArray)
		 //   {
			//    return Arrays.Ensure(boundModel, context.TypeReference, context.DeclaringType, context.UnderlyingType);
		 //   }

		 //   // Depends upon the underlying unified entry
		 //   if (context.TypeReference.IsGenericParameter)
		 //   {
			//    // You cannot create a generic parameter directly.  It is created when its parent type creates it.
			//    return GenericParameters.Ensure(boundModel, context);
		 //   }

		    throw new Exception("The type reference is not configured to be associated with a secondary node.");
	    }
    }
}
