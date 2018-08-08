using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Modules
{
    public class BuildingApi<TContainer> : ConversionApiNode<TContainer>, BuildingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        //public void BuildOut(ILConversion conversion, SemanticModuleMask_I boundModule)
        //{
        //    var semanticModel = conversion.Model;

        //    if (!boundModule.IsConverted())
        //    {
        //        Binding.Metadata.Modules.Building.BuildOut(semanticModel, boundModule);
        //    }

        //    // If all the types have already been ensured, then no need to do anything else.
        //    if (boundModule.IsBuiltOut)
        //    {
        //        return;
        //    }

        //    var converted = (ConvertedModule_I) boundModule;

        //    converted.IsBuiltOut = true;

        //    Types.Ensuring.EnsureTypes(semanticModel, boundModule);
        //}
	  //  public ConvertedModule BuildOut(ILConversion conversion, UnifiedModuleNode moduleNode)
	  //  {
			//var convertedModule = Modules.Creation.Create(conversion, moduleNode);

		 //   moduleNode.Semantic = convertedModule;

		 //   return convertedModule;

	  //  }

	    public void Build(ILConversion conversion)
	    {
			var modules = conversion.MetadataModel.Modules.ByVersionId.Values.ToList();

		    for (int i = 0; i < modules.Count; i++)
		    {
			    var moduleNode = modules[i];

			    moduleNode.ConvertedModule = Modules.Creation.Create(conversion, moduleNode);
		    }
		}
    }
}
