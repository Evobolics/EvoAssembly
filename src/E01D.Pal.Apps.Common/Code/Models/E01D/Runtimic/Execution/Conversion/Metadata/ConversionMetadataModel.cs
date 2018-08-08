namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata
{
    public class ConversionMetadataModel
    {
        public ConversionAssemblyModel Assemblies { get; set; } = new ConversionAssemblyModel();

        public ConversionModuleModel Modules { get; set; } = new ConversionModuleModel();

        public ConversionTypeModel Types { get; set; } = new ConversionTypeModel();
    }
}
