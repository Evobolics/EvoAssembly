using Mono.Cecil;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
	public class ILConversionAssemblyDefinitionInput: ILConversionInput
	{
		public override InputOutputKind Kind { get; } = InputOutputKind.AssemblyDefinitions;

		public AssemblyDefinition[] Assemblies { get; set; }
	}
}
