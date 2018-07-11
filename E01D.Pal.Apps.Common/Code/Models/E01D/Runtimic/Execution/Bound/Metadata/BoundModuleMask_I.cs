using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata
{
	public interface BoundModuleMask_I : SemanticModuleMask_I
	{
		Dictionary<long, BoundConstructorDefinitionMask_I> ConstructorsByMetadataToken { get; }

		Dictionary<long, BoundMethodDefinitionMask_I> MethodsByMetadataToken { get; }

		
	}
}
