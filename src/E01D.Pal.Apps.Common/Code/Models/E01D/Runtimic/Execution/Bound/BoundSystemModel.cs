using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound
{
	public class BoundSystemModel
	{
		public BoundAssemblyModel Assemblies { get; set; } = new BoundAssemblyModel();

		public BoundModuleModel Modules { get; set; } = new BoundModuleModel();
	}
}
