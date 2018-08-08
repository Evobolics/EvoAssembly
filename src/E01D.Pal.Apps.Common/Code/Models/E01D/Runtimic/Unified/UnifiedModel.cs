namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public abstract class UnifiedModel: UnifiedModelMask_I
	{


		/// <summary>
		/// Gets or sets the last id issued by the unified modeling system (UMS).  
		/// </summary>
		public long LastId { get; set; }

		/// <summary>
		/// Gets or sets the primary bound model.  This contains all of the assemblies that are permentantly bound in memory.
		/// </summary>
		public UnifiedMetadataModel BoundModel { get; set; }

		/// <summary>
		/// Gets or sets the conversion models that have been created and are in memory.
		/// </summary>
		public UnifiedMetadataModel[] ConversionModels { get; set; }

		/// <summary>
		/// Gets or sets the semantic models that are in memory that are ready to be turned into converted or bound models.
		/// </summary>
		public UnifiedMetadataModel[] SemanticModels { get; set; }



		
	}
}
