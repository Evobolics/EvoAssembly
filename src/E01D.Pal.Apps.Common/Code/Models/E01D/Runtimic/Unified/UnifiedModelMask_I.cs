namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public interface UnifiedModelMask_I
	{

		/// <summary>
		/// Gets or sets the last id issued by the unified modeling system (UMS).  
		/// </summary>
		long LastId { get; }

		/// <summary>
		/// Gets or sets the primary bound model.  This contains all of the assemblies that are permentantly bound in memory.
		/// </summary>
		UnifiedMetadataModel BoundModel { get; }

		/// <summary>
		/// Gets or sets the conversion models that have been created and are in memory.
		/// </summary>
		UnifiedMetadataModel[] ConversionModels { get; }

		/// <summary>
		/// Gets or sets the semantic models that are in memory that are ready to be turned into converted or bound models.
		/// </summary>
		UnifiedMetadataModel[] SemanticModels { get; }

	}
}
