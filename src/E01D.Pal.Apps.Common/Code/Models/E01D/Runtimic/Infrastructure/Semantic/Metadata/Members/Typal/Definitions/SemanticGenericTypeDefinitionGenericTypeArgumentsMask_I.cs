using System.Collections.Generic;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions
{
	public interface SemanticGenericTypeDefinitionGenericTypeArgumentsMask_I
	{
		/// <summary>
		/// Gets or sets the type arguments that are associted with the generic type.  This cannot be a dictionary because order matters.
		/// </summary>
		List<SemanticTypeDefinitionMask_I> All { get; }

		bool HasGenericParametersAsTypeArguments { get;  }
	}
}
