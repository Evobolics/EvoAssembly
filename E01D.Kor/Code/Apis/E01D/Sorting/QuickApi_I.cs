using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Sorting;

namespace Root.Code.Apis.E01D.Sorting
{
    public interface QuickApi_I<TContainer>: QuickApiMask_I
        where TContainer : SortingContainer_I<TContainer>
    {
    }
}
