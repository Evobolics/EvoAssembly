using System;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public class GettingApi<TContainer> : BoundApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public SemanticModuleMask_I Get(RuntimicSystemModel model, System.Type type) // BELONGS HERE Because it takes in a TYPE
	    {
		    TypeReference typeReference = Models.Types.GetTypeReference(model, type);

		    return Get(model, typeReference);
	    }

	    public SemanticModuleMask_I Get(RuntimicSystemModel model, TypeReference typeReference) // BELONGS HERE Because it takes in a TYPE
	    {
		    var semanticAssembly = Assemblies.Ensuring.Ensure(model, typeReference);

			if (!semanticAssembly.IsBound())
		    {
			    Semantic.Metadata.Modules.Get(model, semanticAssembly, typeReference);
		    }

		    return Get(model, (BoundAssemblyMask_I)semanticAssembly, typeReference);
	    }

	    public BoundModuleNode Get(RuntimicSystemModel model, Guid moduleMvid)
	    {
		    return model.TypeSystems.Bound.Modules.ByVersionId[moduleMvid];
	    }

	    

		public SemanticModuleMask_I Get(RuntimicSystemModel semanticModel, BoundAssemblyMask_I boundAssembly, TypeReference typeReference)
        {
	        throw new System.Exception("Debug");
			//      if (typeReference.IsArray)
			//      {
			//       ArrayType arrayType = (ArrayType) typeReference;

			//       return Get(semanticModel, boundAssembly, arrayType.ElementType);
			//      }

			//if (boundAssembly.Modules.Count == 0)
			//         {
			//             throw new System.Exception("Expected assembly to have at least one module");
			//         }

			//      if (typeReference.Scope is ModuleDefinition moduleDefinition)
			//      {
			//       if (boundAssembly.Modules.TryGetValue(moduleDefinition.Name, out SemanticModuleMask_I boundModule))
			//       {
			//        return boundModule;
			//       }
			//      }

			//      var resolutionName =  Cecil.Types.Naming.GetResolutionName(typeReference);

			//      var node = Unified.Types.Get(semanticModel, resolutionName);

			//      return node.ModuleNode.Semantic;
		}
    }
}
