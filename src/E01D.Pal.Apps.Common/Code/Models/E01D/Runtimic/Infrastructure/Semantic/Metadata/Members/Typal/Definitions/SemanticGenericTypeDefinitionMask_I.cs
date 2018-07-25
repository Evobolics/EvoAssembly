using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
    public interface SemanticGenericTypeDefinitionMask_I: SemanticTypeDefinitionWithTypeParametersMask_I, GenericTypeMask_I, SemanticTypeDefinitionMask_I
	{
        SemanticGenericTypeDefinitionMask_I Blueprint { get; }

        /// <summary>
        /// Gets or sets the generic instances  that are associated with this type.  
        /// This type should only contain instances if the generic is an open type.
        /// </summary>
        List<SemanticGenericTypeDefinitionMask_I> Instances { get; }

		SemanticGenericTypeDefinitionGenericTypeArgumentsMask_I TypeArguments { get; }


		///// <summary>
		///// Gets or sets the type arguments that are associted with the generic type.  This cannot be a dictionary because order matters.
		///// </summary>
		//List<SemanticTypeDefinitionMask_I> TypeArguments { get; }


	}
}
