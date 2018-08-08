using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public interface ModelApiMask_I
    {
        ModelAssembliesApiMask_I Assemblies { get; }

        ModelFieldsApiMask_I Fields { get; }

        ModelModulesApiMask_I Modules { get; }

        ModelTypesApiMask_I Types { get; }

       

        
    }
}
