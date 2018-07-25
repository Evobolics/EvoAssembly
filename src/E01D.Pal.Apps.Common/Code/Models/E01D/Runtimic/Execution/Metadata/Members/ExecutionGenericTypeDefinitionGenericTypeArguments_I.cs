using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members
{
	public interface ExecutionGenericTypeDefinitionGenericTypeArguments_I: ExecutionGenericTypeDefinitionGenericTypeArgumentsMask_I
	{
		/// <summary>
		/// Gets or sets the type arguments that are associted with the generic type.  This cannot be a dictionary because order matters.
		/// </summary>
		new List<SemanticTypeDefinitionMask_I> All { get; set; }

		//new bool HasGenericParametersAsTypeArguments { get; set; }
	}
}
