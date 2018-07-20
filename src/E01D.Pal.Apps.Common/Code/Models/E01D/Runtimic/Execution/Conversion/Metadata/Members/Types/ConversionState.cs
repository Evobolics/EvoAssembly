using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
	public class ConversionState
	{
		public BuildPhaseKind BuildPhase { get; set; }

		public List<ConvertedTypeDefinition_I> Phase2Dependencies { get; } = new List<ConvertedTypeDefinition_I>();

		/// <summary>
		/// Gets or sets all of the conversion entries that are directly dependent upon this entry.
		/// </summary>
		public List<ConvertedTypeDefinition_I> Phase2Dependents { get; } = new List<ConvertedTypeDefinition_I>();

		public Dictionary<string, ConvertedTypeDefinition_I> Phase3Dependencies { get; } = new Dictionary<string, ConvertedTypeDefinition_I>();

		/// <summary>
		/// Gets or sets all of the conversion entries that are directly dependent upon this entry.
		/// </summary>
		public Dictionary<string, ConvertedTypeDefinition_I> Phase3Dependents { get; } = new Dictionary<string, ConvertedTypeDefinition_I>();

		public bool ConstructorsDefined { get; set; }

		
	}
}
