using System;
using System.Reflection;
using Root.Code.Attributes.E01D;

namespace Root.Code.Apis.E01D
{
    public interface PalAssemblyApi_I
    {
        // by using task attributes developer should not have to leave code to create a task.
        [Task("Should return a Pal type not a System.Type")]
        Type GetTypeInAssembly(Assembly collectibleAssembly, System.Type type);
    }
}
