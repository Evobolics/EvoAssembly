using System;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : BindingApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
	    
	    public ArrayApi_I<TContainer> Arrays { get; set; }

	    ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;



	   

	   
	    public EnumApi_I<TContainer> Enums { get; set; }

	    EnumApiMask_I EnsuringApiMask_I.Enums => Enums;

	    public GenericApi_I<TContainer> GenericInstances { get; set; }

	    GenericInstanceApiMask_I EnsuringApiMask_I.GenericInstances => GenericInstances;

	    public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

	    GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

	    //public Gathering.GatheringApi<TContainer> Gathering { get; set; }

	    //GatheringApiMask_I EnsuringApiMask_I.Gathering => Gathering;

	    public NonGenericApi_I<TContainer> NonGenericInstances { get; set; }

	    NonGenericInstanceApiMask_I EnsuringApiMask_I.NonGenericInstances => NonGenericInstances;

	    public PointerApi_I<TContainer> Pointers { get; set; }

	    PointerApiMask_I EnsuringApiMask_I.Pointers => Pointers;

	    public RequiredModifierApi_I<TContainer> RequiredModifiers { get; set; }

	    RequiredModifierApiMask_I EnsuringApiMask_I.RequiredModifiers => RequiredModifiers;

	    public BoundTypeDefinitionMask_I EnsureBound(InfrastructureModelMask_I semanticModel, System.Type type)
	    {
		    var typeReference = Models.Types.GetTypeReference(semanticModel, type);

		    return EnsureBound(semanticModel, typeReference, type);
	    }


	    public BoundTypeDefinitionMask_I EnsureBound(InfrastructureModelMask_I semanticModel, TypeReference typeReference, System.Type type)
	    {
		    var semanticMask = Ensure(semanticModel, typeReference, type);

		    if (!(semanticMask is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
		    }

		    return bound;
	    }

		public void Ensure(InfrastructureModelMask_I semanticModel, SemanticTypeDefinitionMask_I semanticType)
	    {
		    Infrastructure.Models.Semantic.Types.Ensure(semanticModel, semanticType);
	    }

	    public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, TypeReference typeReference)
	    {
		    return Ensure(semanticModel, typeReference, null);
	    }

	    public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, TypeReference typeReference, Type underlyingType)
	    {
		    // Should be Tabular.Cecil.
		    if (Cecil.IsExternal(typeReference))
		    {
			    typeReference = Models.Types.External.Resolve(semanticModel, typeReference);
		    }

		    // The issue is that you do not know if the type really needs to be converted type.  Consider three assemblies:
		    // Assembly A references Assembly B which references Assembly C
		    // A - Converted.  B- Not Converted - C - Converted.
		    if (semanticModel.IsConverted())
		    {
			    var conversion = ((ILConversionExecutionModel)semanticModel).Conversion;

			    return Conversion.Metadata.Members.Types.Ensuring.Ensure(conversion, typeReference, null);
		    }

		    // Get the module to ensure that the type is part of the module.
		    var semanticModule = Modules.Getting.Get(semanticModel, typeReference);

		    if (!semanticModule.IsBound())
		    {
			    var result = Semantic.Metadata.Members.Types.Ensuring.Ensure(semanticModel, semanticModule, typeReference);

			    throw new Exception("Need to fix return type.");
		    }

		    

		    // Search the entire model to see if the semantic type entry exists.  If is is added to the module, it will add 
		    return Ensure(semanticModel, (BoundModule_I)semanticModule, typeReference, null, underlyingType);
	    }

	    public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, Type type)
	    {
		    var typeReference = Models.Types.GetTypeReference(semanticModel, type);

		    var module = Modules.Getting.Get(semanticModel, type);

		    return Types.Ensuring.Ensure(semanticModel, (BoundModule_I)module, typeReference, null, type);
	    }

		

        /// <summary>
        /// Ensures the type is part of the module.
        /// </summary>
        /// <param name="semanticModel"></param>
        /// <param name="semanticModule"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, System.Type input)
        {
            var typeReference = Models.Types.GetTypeReference(semanticModel, input);

            return Ensure(semanticModel, boundModule, typeReference, null, input);
        }

        /// <summary>
        /// Ensures the type is part of the module.
        /// </summary>
        public SemanticTypeDefinitionMask_I Ensure(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule, TypeReference input, BoundTypeDefinitionMask_I declaringType, System.Type underlyingType)
        {

	        if (input.FullName == "System.Diagnostics.Tracing.ConcurrentSet`2")
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
					
					declaringType = (BoundTypeDefinitionMask_I)Ensure(semanticModel, boundModule, input.GetElementType(), null, underlyingType.DeclaringType);
				}
		        else
		        {
			        declaringType = (BoundTypeDefinitionMask_I)Ensure(semanticModel, boundModule, input.DeclaringType, null, underlyingType.DeclaringType);
				}
		        

	        }

	        

			if (input.IsGenericParameter)
	        {
		        // You cannot create a generic parameter directly.  It is created when its parent type creates it.
		        return GenericParameters.Ensure(semanticModel, boundModule, input);
	        }

	        if (input.IsArray)
	        {
		        return Arrays.Ensure(semanticModel, boundModule, input, declaringType, underlyingType);
	        }
	        if (input.IsGenericInstance)
	        {
		        return GenericInstances.Ensure(semanticModel, boundModule, input, declaringType, underlyingType);
	        }
	        if (input.IsPointer)
	        {
		        return Pointers.Ensure(semanticModel, boundModule, input, declaringType, underlyingType);
	        }
	        if (input.IsRequiredModifier)
	        {
		        return RequiredModifiers.Ensure(semanticModel, boundModule, input, declaringType, underlyingType);
	        }
	        if (input.IsDefinition)
	        {
		        return NonGenericInstances.Ensure(semanticModel, boundModule, input, declaringType, underlyingType);
	        }

			// Extenral 
	        var internalTypReference = Models.Types.External.Resolve(semanticModel, input);

	        return Ensure(semanticModel, boundModule, internalTypReference, declaringType, underlyingType);



	       
        }


		public void EnsureTypes(InfrastructureModelMask_I semanticModel, BoundModule_I boundModule)
		{
			var types = boundModule.SourceModuleDefinition.Types;

			for (int i = 0; i < types.Count; i++)
			{
				var typeDefinition = types[i];

				Ensure(semanticModel, boundModule, typeDefinition, null, null);
			}
		}

	}
}
