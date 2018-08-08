using Root.Code.Enums.E01D.Runtimic;

namespace Root.Code.Models.E01D.Runtimic.Unified
{
	public class UnifiedRuntimicModel: UnifiedRuntimicModelMask_I
	{
		public RuntimicKind RuntimicKind { get; }
		public object ObjectNetwork { get; set; }
		public UnifiedModelMask_I Unified { get; }
	}
}
