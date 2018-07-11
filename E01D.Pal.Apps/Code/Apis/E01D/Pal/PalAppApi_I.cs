namespace Root.Code.Apis.E01D.Pal
{
    public interface PalAppApi_I: PalApi_I
    {

        PalReflectionApi_I Reflection { get; }

        //new PalReflectionActivationApi_I Activation { get; }
        PalAssemblyApi_I Assemblies { get;  }
    }
}
