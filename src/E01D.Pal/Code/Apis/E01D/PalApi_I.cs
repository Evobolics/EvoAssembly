using Root.Code.Apis.E01D.Activation;
using Root.Code.Apis.E01D.Consoles;

namespace Root.Code.Apis.E01D
{
    public interface PalApi_I
    {

        

        PalActivationApi_I Activation { get; }
        

        PalConsoleApi_I Consoles { get; }
    }
}
