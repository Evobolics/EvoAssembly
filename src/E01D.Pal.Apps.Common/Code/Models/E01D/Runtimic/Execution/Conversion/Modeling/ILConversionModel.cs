using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Models;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling
{
	public class ILConversionModel: ILConversionModelMask_I
	{
		public ILConversionModelAssemblies Assemblies { get; set; } = new ILConversionModelAssemblies();

		public ILConversionModelModules Modules { get; set; } = new ILConversionModelModules();


		public ILConversionSemanticModelTypes Types { get; set; } = new ILConversionSemanticModelTypes();

		SemanticModelAssembliesMask_I SemanticModelMask_I.Assemblies => Assemblies;

		SemanticModelModulesMask_I SemanticModelMask_I.Modules => Modules;



		SemanticModelTypesMask_I SemanticModelMask_I.Types => Types;
	}
}
