using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversionResult
    {
     //   /// <summary>
     //   /// Gets or sets the assemblies that are emitted.
     //   /// </summary>
     //   public List<AssemblyBuilder> Assemblies { get; set; } = new List<AssemblyBuilder>();

     //   public Dictionary<string, SemanticTypeMask_I> Types { get; set; } = new Dictionary<string, SemanticTypeMask_I>();
	    //public Assembly[] Outputs { get; set; }
	    public ILConversionOutput Output { get; set; }
    }
}
