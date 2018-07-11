using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
    public class InsertionApi
    {
        public void Sort(int[] input)
        {
            for (var i = 0; i < input.Length - 1; i++)
            {
                for (var j = i + 1; j > 0; j--)
                {
                    if (input[j - 1] > input[j])
                    {
                        var temp = input[j - 1];
                        input[j - 1] = input[j];
                        input[j] = temp;
                    }
                }
            }
        }
    }

    public class InsertionApi<TContainer> : SortingApiNode<TContainer, InsertionApi>, InsertionApi_I
        where TContainer : SortingContainer_I<TContainer>
    {
        public void Sort(int[] input)
        {
            Underlying.Sort(input);
        }

    }
}
