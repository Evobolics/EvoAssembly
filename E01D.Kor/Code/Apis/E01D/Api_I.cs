using Root.Code.Models.E01D.Containment;

namespace Root.Code.Apis.E01D
{
    public interface Api_I
    {
        Container_I Container { get; }
    }

    public interface Api_I<TContainer>:Api_I
    {
        new TContainer Container { get; set; }
    }
}
