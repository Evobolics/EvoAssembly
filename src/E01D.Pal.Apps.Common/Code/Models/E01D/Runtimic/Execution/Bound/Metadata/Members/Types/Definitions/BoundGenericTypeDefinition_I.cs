using System.Collections.Generic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundGenericTypeDefinition_I: BoundTypeDefinitionWithTypeParameters_I, BoundGenericTypeDefinitionMask_I, GenericType_I, BoundTypeDefinition_I
	{
        new BoundGenericTypeDefinitionMask_I Blueprint { get; set; }
        GenericInstanceType SourceGenericInstanceType { get; set; }

        /// <summary>
        /// Gets or sets the generic instances  that are associated with this type.  
        /// This type should only contain instances if the generic is an open type.
        /// </summary>
        new List<SemanticGenericTypeDefinitionMask_I> Instances { get; set; }

        

		new BoundGenericTypeDefinitionGenericTypeArguments_I TypeArguments { get; set; }
	}
}
