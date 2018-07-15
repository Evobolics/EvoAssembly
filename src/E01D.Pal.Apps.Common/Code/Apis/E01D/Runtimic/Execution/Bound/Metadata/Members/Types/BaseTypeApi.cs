using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class BaseTypeApi<TContainer> : BindingApiNode<TContainer>, BaseTypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public SemanticTypeMask_I GetBaseType(InfrastructureRuntimicModelMask_I semanticModel, BoundModule_I boundModule, TypeDefinition typeDefinition)
        {
            if (typeDefinition.BaseType == null) return null;

            var resolutionName = Types.Naming.GetResolutionName(typeDefinition.BaseType);

            var result = Models.Types.Collection.Get(semanticModel, resolutionName);

            if (result != null) return result;

            //TypeDefinition baseTypeDefinition = Models.Resolve(typeDefinition.BaseType);

            return Types.Ensuring.Ensure(semanticModel, boundModule, typeDefinition.BaseType, null, null);
        }
    }
}
