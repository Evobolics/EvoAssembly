
using Root.Code.Attributes.E01D;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members;

namespace Root.Code.Apis.E01D.Activation
{
    public interface PalActivationApi_I
    {
        T CreateInstance<T>();

        object CreateInstance(Type_I type);

        [Task("Need to remove once it is easy to create a pal type from a type.")]
        object CreateInstance(System.Type type);
    }
}
