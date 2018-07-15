using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Infrastructure.Structural
{
	public interface StructuralRuntimicModelMask_I:UnifiedRuntimicModelMask_I
	{
		StructuralModelMask_I Structural { get; }
	}
}
