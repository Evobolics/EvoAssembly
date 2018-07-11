using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public class ConvertedGenericNestedStructTypeDefinition: ConvertedNestedStructTypeDefinition, ConvertedGenericTypeDefinition_I
    {
        public BoundGenericTypeDefinitionMask_I Blueprint { get; set; }

		SemanticGenericTypeDefinitionMask_I SemanticGenericTypeDefinitionMask_I.Blueprint => Blueprint;

        /// <summary>
        /// Gets or sets the generic instances  that are associated with this type.  
        /// This type should only contain instances if the generic is an open type.
        /// </summary>
        public List<SemanticGenericTypeDefinitionMask_I> Instances { get; set; } =
            new List<SemanticGenericTypeDefinitionMask_I>();

        public GenericTypeKind GenericKind { get; set; }

        public TypeReference GenericTypeDefinition { get; set; }

        public GenericInstanceType SourceGenericInstanceType { get; set; }

        public TypeDefinition SourceGenericTypeDefinition { get; set; }

		/// <summary>
	    /// Gets or sets the type arguments that are associted with the generic type.  This cannot be a dictionary because order matters.
	    /// </summary>
	    public ConvertedGenericTypeDefinitionGenericTypeArguments_I TypeArguments { get; set; } = new ConvertedGenericTypeDefinitionGenericTypeArguments();

	    BoundGenericTypeDefinitionGenericTypeArgumentsMask_I BoundGenericTypeDefinitionMask_I.TypeArguments => TypeArguments;

	    SemanticGenericTypeDefinitionGenericTypeArgumentsMask_I SemanticGenericTypeDefinitionMask_I.TypeArguments => TypeArguments;

		public override TypeKind TypeKind => base.TypeKind | TypeKind.Generic;

        public ConvertedGenericParameterTypeDefinitions_I TypeParameters { get; set; } = new ConvertedGenericParameterTypeDefinitions();


        SemanticGenericParameterTypeDefinitionsMask_I SemanticTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;
        BoundGenericParameterTypeDefinitionsMask_I BoundTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;
        ConvertedGenericParameterTypeDefinitionsMask_I ConvertedTypeDefinitionWithTypeParametersMask_I.TypeParameters => TypeParameters;
    }
}
