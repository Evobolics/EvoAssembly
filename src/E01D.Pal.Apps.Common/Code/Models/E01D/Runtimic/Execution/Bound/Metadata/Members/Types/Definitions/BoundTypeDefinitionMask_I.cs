using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public interface BoundTypeDefinitionMask_I: ExecutionTypeDefinitionMask_I, BoundTypeWithBaseTypeMask_I
    {

		/// <summary>
	    /// Gets or sets whether the type has been built.  If it is a bound type, it means all of the members have been added. If it is a 
	    /// converted type, it means all of its members have been built out, instrucitons created, and type builder has had its create type method called.
	    /// </summary>
	    //bool IsBuilt { get; }

		

		
	    new BoundModuleMask_I Module { get;  }


	}
}
