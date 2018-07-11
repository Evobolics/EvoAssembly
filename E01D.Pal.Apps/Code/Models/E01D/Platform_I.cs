using Root.Code.Apis.E01D.Pal;

namespace Root.Code.Models.E01D
{
    public interface Platform_I
    {
        /// <summary>
        /// Gets or sets the api associated with the system.
        /// </summary>
        PalAppApi_I Api { get; }
    }
}
