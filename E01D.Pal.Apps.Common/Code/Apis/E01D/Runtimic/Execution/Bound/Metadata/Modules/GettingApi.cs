using System.Linq;
using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Models;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Binding.Metadata.Modules
{
    public class GettingApi<TContainer> : BindingApiNode<TContainer>, GettingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
	    public SemanticModuleMask_I Get(InfrastructureModelMask_I model, System.Type type) // BELONGS HERE Because it takes in a TYPE
	    {
		    TypeReference typeReference = Models.Types.GetTypeReference(model, type);

		    return Get(model, typeReference);
	    }

	    public SemanticModuleMask_I Get(InfrastructureModelMask_I model, TypeReference typeReference) // BELONGS HERE Because it takes in a TYPE
	    {
		    var semanticAssembly = Assemblies.Ensuring.Ensure(model, typeReference);

		    Assemblies.Building.BuildOut(model, semanticAssembly);

			if (!semanticAssembly.IsBound())
		    {
			    Semantic.Metadata.Modules.Get(model, semanticAssembly, typeReference);
		    }

		    return Get(model, (BoundAssembly_I)semanticAssembly, typeReference);
	    }

		public SemanticModuleMask_I Get(InfrastructureModelMask_I semanticModel, BoundAssemblyMask_I modulesAssembly, TypeReference typeReference)
        {
			if (modulesAssembly.Modules.Count == 0)
            {
                throw new System.Exception("Expected assembly to have at least one module");
            }

            if (modulesAssembly.Modules.Count == 1)
            {
                return modulesAssembly.Modules.Values.FirstOrDefault();
            }

			//Infrastructure.Structural.

	        //if (typeReference.IsDefinition || typeReference.IsPrimitive || typeReference.IsGenericInstance)
	        //{

	        //}
	        //if (typeReference.IsArray)
	        //{
		       // ArrayType arrayType = (ArrayType)typeReference;

		       // return Ensure(semanticModel, semanticAssembly, arrayType.ElementType);
	        //}
	        //else
	        //{
		       // return EnsureModuleFromAssembly(semanticModel, typeReference);
	        //}

			throw new System.Exception("More than one module not supported at this time.");



        }
    }
}
