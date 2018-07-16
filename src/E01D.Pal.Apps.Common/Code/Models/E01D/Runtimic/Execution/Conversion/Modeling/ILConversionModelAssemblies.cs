using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
    public class ILConversionModelAssemblies: ILConversionModelAssembliesMask_I
	{

	    public Dictionary<string, SemanticAssemblyMask_I> ByResolutionName { get; set; } = new Dictionary<string, SemanticAssemblyMask_I>();

		public Dictionary<string, ConvertedAssembly_I> Collectible { get; set; } = new Dictionary<string, ConvertedAssembly_I>();

		public List<SemanticAssemblyMask_I> InDependencyOrder { get; set; }

		Dictionary<string, ConvertedAssembly_I> ILConversionModelAssembliesMask_I.Collectible => throw new System.NotImplementedException();
	}
}
