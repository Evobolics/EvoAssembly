using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Modeling.Conversion;
using Root.Code.Models.E01D.Runtimic.Unified;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion
{
    public class ILConversion
    {
        public ILConversion()
        {
            
        }
        

        public ILConversionConfiguration Configuration { get; set; } = new ILConversionConfiguration();

        /// <summary>
        /// Contains the type that are being converted if only select number of types are being converted.
        /// </summary>
        public ILConversionInput Input { get; set; }

        /// <summary>
        /// Gets or sets the semantic model associated with this il conversion.
        /// </summary>
        public ILConversionRuntimicModel Model { get; set; } = new ILConversionRuntimicModel();

        /// <summary>
        /// Gets or sets the result of conversion.
        /// </summary>
        public ILConversionResult Result { get; set; } = new ILConversionResult();

        /// <summary>
        /// Contains the list of assemblies that can be converted.
        /// </summary>
        public Dictionary<string, string> ConvertibleAssemblies { get; set; } = new Dictionary<string, string>();

        public BoundModuleMask_I TypeSetModule { get; set; }
        public bool ConvertibleTypesIdentified { get; set; }
	    public Dictionary<string, UnifiedAssemblyNode> ReferencedAssemblies { get; set; }
    }
}
