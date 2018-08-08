namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Modules
{
    public interface ModuleApiMask_I
    {
        AdditionApiMask_I Addition { get; }

        BuildingApiMask_I Building { get; }

        CreationApiMask_I Creation { get; }

	    
	    

        EnsuringApiMask_I Ensuring { get; }

        GettingApiMask_I Getting { get; }


        //BoundModuleNode Ensure(ExecutionEnsureContext context, BoundAssemblyNode boundAssembly, StructuralModuleNode module);
    }
}
