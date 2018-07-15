using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Assemblies
{
    public interface BuildingApiMask_I
    {
        //SemanticAssemblyMask_I BuildOut(ILConversion conversion, AssemblyNameReference nameReference);
	    void Build(ILConversion conversion);
    }
}
