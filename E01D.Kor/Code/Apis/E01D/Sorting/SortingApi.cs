using Root.Code.Attributes.E01D;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
    public class SortingApi
    {
        public BubbleApi Bubble { get; set; } = new BubbleApi();


        public InsertionApi Insertion { get; set; } = new InsertionApi();

        
        public QuickApi Quick { get; set; } = new QuickApi(); 
    }

    public class SortingApi<TContainer> : SortingApiNode<TContainer>, SortingApi_I<TContainer>
        where TContainer : SortingContainer_I<TContainer>
    {
        [ValueSetDynamically]
        public BubbleApi<TContainer> Bubble { get; set; }

        [ValueSetDynamically]
        public InsertionApi<TContainer> Insertion { get; set; }

        [ValueSetDynamically]
        public QuickApi<TContainer> Quick { get; set; }

        BubbleApi_I SortingApiMask_I.Bubble => Bubble;

        InsertionApi_I SortingApiMask_I.Insertion => Insertion;

        QuickApiMask_I SortingApiMask_I.Quick => Quick;
    }
}
