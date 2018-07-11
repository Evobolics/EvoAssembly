using System;
using System.Linq;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Modeling
{
    public class ModelModulesApi<TContainer> : ConversionApiNode<TContainer>, ModelModulesApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        

        public SemanticModuleMask_I GetModule(ILConversion conversion, SemanticAssemblyMask_I modulesAssembly, TypeReference typeReference)
        {
            if (modulesAssembly.Modules.Count == 0)
            {
                throw new Exception("Expected assembly to have at least one module");
            }

            if (modulesAssembly.Modules.Count == 1)
            {
                return modulesAssembly.Modules.Values.FirstOrDefault();
            }

            throw new Exception("More than one module not supported at this time.");



        }
    }
}
