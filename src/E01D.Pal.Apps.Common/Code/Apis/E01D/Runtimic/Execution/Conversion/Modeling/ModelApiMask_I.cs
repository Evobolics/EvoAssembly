using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling.Types;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

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
