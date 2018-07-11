using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
    public class BubbleApi
    {
        public void Sort(int[] input)
        {
            for (int i = 0; i <= input.Length - 2; i++)
            {
                for (int j = 0; j <= input.Length - 2; j++)
                {
                    if (input[j] > input[j + 1])
                    {
                        var t = input[j + 1];
                        input[j + 1] = input[j];
                        input[j] = t;
                    }
                }
            }
        }
    }

    public class BubbleApi<TContainer> : SortingApiNode<TContainer, BubbleApi>, BubbleApi_I
        where TContainer : SortingContainer_I<TContainer>
    {
        public void Sort(int[] input)
        {
            Underlying.Sort(input);
        }
    }
}
