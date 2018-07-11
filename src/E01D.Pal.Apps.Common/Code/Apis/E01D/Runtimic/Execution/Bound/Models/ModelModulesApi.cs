using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Models
{
    public class ModelModulesApi<TContainer> : BindingApiNode<TContainer>, ModelModulesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

        

	    

        //public SemanticModuleMask_I GetModule(InfrastructureModelMask_I semanticModel, SemanticAssemblyMask_I modulesAssembly, TypeReference typeReference)
        //{
        //    if (modulesAssembly.Modules.Count == 0)
        //    {
        //        throw new Exception("Expected assembly to have at least one module");
        //    }

        //    if (modulesAssembly.Modules.Count == 1)
        //    {
        //        return modulesAssembly.Modules.Values.FirstOrDefault();
        //    }

        //    throw new Exception("More than one module not supported at this time.");



        //}
    }
}
