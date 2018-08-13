using System.Collections.Generic;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Modeling;
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

        public ConversionMetadataModel MetadataModel { get; set; } = new ConversionMetadataModel();

        /// <summary>
        /// Gets or sets the result of conversion.
        /// </summary>
        public ILConversionResult Result { get; set; } = new ILConversionResult();

        public RuntimicSystemModel RuntimicSystem { get; set; }



        public BoundModuleMask_I TypeSetModule { get; set; }
        public bool ConvertibleTypesIdentified { get; set; }
	    public Dictionary<string, UnifiedAssemblyNode> ReferencedAssemblies { get; set; }
    }
}
