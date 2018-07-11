using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters
{
    public interface ParameterApi_I<TContainer> : ParameterApiMask_I
        where TContainer : RuntimicContainer_I<TContainer>
    {
        //Type[] GetParameters(SemanticAnalysis semanticAnalysis, MethodReference methodReference);

        //Type[] GetParameters(SemanticAnalysis semanticAnalysis, Mono.Collections.Generic.Collection<ParameterDefinition> parameters);

        //Type[] GetTypes(SemanticAnalysis semanticAnalysis, Mono.Collections.Generic.Collection<TypeReference> collection);

        //TypeDefinitionEntry[] GetTypeEntries(SemanticAnalysis semanticAnalysis, Mono.Collections.Generic.Collection<TypeReference> collection);
    }
}
