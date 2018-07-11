using Root.Code.Models.E01D.Containment;

namespace Root.Code.Apis.E01D
{
    /// <summary>
    /// Represents an api that does not have a container.  This is very useful when creating api instances that are associated with 
    /// domains.
    /// </summary>
    public class Api
    {
    }
    public class Api<TContainer> : Api_I<TContainer>
        where TContainer : Container_I
    {
        public TContainer Container { get; set; }

        Container_I Api_I.Container => Container;
    }

    public class Api<TContainer, TUnderlying> : Api<TContainer>
        where TContainer : Container_I
    {
        public TUnderlying Underlying { get; set; }
    }
}
