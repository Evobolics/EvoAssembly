using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering;
using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;
using GatheringApiMask_I = Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring.Gathering.GatheringApiMask_I;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Ensuring
{
	public class EnsuringApi<TContainer> : ConversionApiNode<TContainer>, EnsuringApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        [ValueSetDynamically]
        public ArrayApi_I<TContainer> Arrays { get; set; }

        ArrayApiMask_I EnsuringApiMask_I.Arrays => Arrays;

        

        [ValueSetDynamically]
        public DotNetApi<TContainer> DotNet { get; set; }

        DotNetApiMask_I EnsuringApiMask_I.DotNet => DotNet;

        [ValueSetDynamically]
        public EnumApi_I<TContainer> Enums { get; set; }

        EnumApiMask_I EnsuringApiMask_I.Enums => Enums;

        public GenericApi_I<TContainer> Generic { get; set; }

        GenericInstancesApiMask_I EnsuringApiMask_I.Generic => Generic;

        public GenericParameterApi_I<TContainer> GenericParameters { get; set; }

        GenericParameterApiMask_I EnsuringApiMask_I.GenericParameters => GenericParameters;

        public Gathering.GatheringApi<TContainer> Gathering { get; set; }

        GatheringApiMask_I EnsuringApiMask_I.Gathering => Gathering;

        public NonGenericInstanceApi_I<TContainer> NonGenericInstances { get; set; }

        NonGenericInstanceApiMask_I EnsuringApiMask_I.NonGenericInstances => NonGenericInstances;

	    public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, System.Type type)
	    {
			var typeReference = Models.Types.GetTypeReference(conversion, type, out SemanticTypeDefinitionMask_I possibleSemanticType);

		    return EnsureBound(conversion, typeReference, possibleSemanticType);
	    }

	    public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference, SemanticTypeDefinitionMask_I possibleSemanticType)
	    {
		    if (possibleSemanticType != null && possibleSemanticType is BoundTypeDefinitionMask_I bound1)
		    {
			    return bound1;
		    }

		    return EnsureBound(conversion, typeReference);
	    }

		public BoundTypeDefinitionMask_I EnsureBound(ILConversion conversion, TypeReference typeReference)
	    {
		    SemanticTypeMask_I semanticMask = Ensure(conversion, typeReference, null);

		    if (!(semanticMask is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception($"Expected the resolved semantic type of type '{semanticMask.GetType()}' to be a bound type definition.");
		    }

		    return bound;
	    }

	    public System.Type EnsureToType(ILConversion conversion, TypeReference typeReference, out BoundTypeDefinitionMask_I boundType)
	    {
		    boundType = EnsureBound(conversion, typeReference);

		    return EnsureToType(conversion, boundType);
	    }

	    public System.Type EnsureToType(ILConversion conversion, TypeReference typeReference)
	    {
		    var boundType = EnsureBound(conversion, typeReference);

		    return EnsureToType(conversion, boundType);
	    }

	    public System.Type EnsureToType(ILConversion conversion, SemanticTypeDefinitionMask_I semanticType)
	    {
		    if (!(semanticType is BoundTypeDefinitionMask_I bound))
		    {
			    throw new Exception("A semantic type must be a bound type to be resolved to a runtime type.");
		    }

		    return EnsureToType(conversion, bound);
	    }

		// TODO: Rename to GetRuntimeType
		public System.Type EnsureToType(ILConversion conversion, BoundTypeDefinitionMask_I semanticType)
	    {
		    return Binding.Models.Types.ResolveToType(conversion.Model, semanticType);
	    }

		public void Ensure(ILConversion conversion, ConvertedTypeDefinition_I semanticType)
	    {
		    var semanticModel = conversion.Model;

		    if (conversion.Configuration.IsConvertingTypeSet)
		    {
			    var resolutionName = Types.Naming.GetResolutionName(semanticType);

			    if (!semanticModel.Semantic.Types.ConvertedTypes.TryGetValue(resolutionName, out ConvertedTypeDefinition_I converted))
			    {
				    semanticModel.Semantic.Types.ConvertedTypes.Add(resolutionName, semanticType);
			    }
			    else
			    {
				    throw new System.Exception(
					    "Adding more than one converted type with the same full name.  This cannot be done with a single type set.");
			    }
		    }

		    Infrastructure.Models.Semantic.Types.Ensure(semanticModel, semanticType);
	    }



	    /// <summary>
	    /// Ensure the type is part of the model.  If it is not present, it figures out if it needs to be converted or bound, and proceeds accordingly.  If a module needs to be 
	    /// created it is.
	    /// </summary>
	    /// <param name="conversion">The current conversion.</param>
	    /// <param name="typeReference">The type reference that is being ensured that is part of the semantic model.</param>
	    /// <returns></returns>
	    public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, TypeReference typeReference, SemanticTypeDefinitionMask_I subType)
	    {
		    // Check to see if this input is to be converted, or needs to be relegated to bound only.
		    if (!Models.IsConverted(conversion, typeReference))
		    {
			    return Binding.Metadata.Members.Types.Ensuring.Ensure(conversion.Model, typeReference);
		    }

		    // Get the module to ensure that the type is part of the module.
		    var semanticModule = Modules.Ensuring.EnsureAssignedModule(conversion, typeReference);

		    // If the input is converted, then the module needs to be convertible due to the need to have a module builder.  
		    if (!(semanticModule is ConvertedModule_I convertedModule))
		    {
			    throw new Exception("The semantic model has deemed the type is convertible, but the module passed into the Ensure method is not convertible.  The module " +
			                        "needs to be convertible due to the need of having a module builder.");
		    }

		    // Search the entire model to see if the semantic type entry exists.  If is is added to the module, it will add 
		    return Types.Ensuring.Ensure(conversion, convertedModule, typeReference, null);
	    }

		/// <summary>
		/// Ensures the type has been added to the module.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="module">The module that is going to house the type.  This should be a convertible module if the type is being converted as the 
		/// converter will need a module builder. </param>
		/// <param name="input"></param>
		/// <returns></returns>
		public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I module, Type input)
		{
			Infrastructure.Structural.Cecil.Metadata.Assemblies.Ensure(conversion.Model, input.Assembly);

            var typeReference = Models.Types.GetTypeReference(conversion, input);

            return Ensure(conversion, module, typeReference, null);
        }

	    /// <summary>
	    /// Ensures the type has been added to the module.
	    /// </summary>
	    /// <param name="conversion"></param>
	    /// <param name="convertedModule">The module that is going to house the type.  This should be a convertible module if the type is being converted as the 
	    /// converter will need a module builder. </param>
	    /// <param name="input"></param>
	    /// <param name="declaringType"></param>
	    public SemanticTypeDefinitionMask_I Ensure(ILConversion conversion, ConvertedModule_I convertedModule, TypeReference input, ConvertedTypeDefinition_I declaringType)
        {
            // The choice was made to seperate out the various cases.  This enables each one to be developed seperately without having ot worry about how code 
            // changes will affect the other cases.  It does have some duplication of code, but not much.  This keeps the code cleaner and easier to read.

            if(input.IsGenericParameter)
            {
                // You cannot create a generic parameter directly.  It is created when its parent type creates it.
                return GenericParameters.Ensure(conversion, convertedModule, (GenericParameter)input);
            }

            if (input.IsArray)
            {
                return Arrays.Ensure(conversion, convertedModule, input, declaringType);
            }
	        

			if (input.IsGenericInstance)
            {
                return Generic.Ensure(conversion, convertedModule, input, declaringType);
            }

            return NonGenericInstances.Ensure(conversion, convertedModule, input, declaringType);

            
        }

        

        

       

    }
}
