using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Modeling;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types
{
	public class BaseTypeApi<TContainer> : BoundApiNode<TContainer>, BaseTypeApi_I<TContainer>
        where TContainer: RuntimicContainer_I<TContainer>
    {
        public SemanticTypeMask_I GetBaseType(BoundRuntimicModelMask_I semanticModel, TypeDefinition typeDefinition)
        {
            if (typeDefinition.BaseType == null) return null;

            var resolutionName = Types.Naming.GetResolutionName(typeDefinition.BaseType);

            var result = Models.Types.Collection.Get(semanticModel, resolutionName);

            if (result != null) return result;

            return Execution.Types.Ensuring.Ensure(semanticModel, typeDefinition.BaseType, null, null);
        }
    }
}
