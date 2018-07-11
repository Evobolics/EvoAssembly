using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public class FindingApi<TContainer> : ConversionApiNode<TContainer>, FindingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public TypeMatchingApi_I<TContainer> TypeMatching { get; set; }

        TypeMatchingApiMask_I FindingApiMask_I.TypeMatching => TypeMatching;

        public ParameterMatchingApi_I<TContainer> ParameterMatching { get; set; }

        ParameterMatchingApiMask_I FindingApiMask_I.ParameterMatching => ParameterMatching;

        





        
    }
}
