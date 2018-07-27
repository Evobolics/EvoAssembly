using System.Collections.Generic;
using System.Reflection.Emit;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    public abstract class ConvertedTypeDefinition : ConvertedType, ConvertedTypeDefinition_I
    {
        

	    private System.Type _UnderlyingType;

	    public Dictionary<int, SemanticArrayTypeDefinitionMask_I> Arrays { get; set; } =
		    new Dictionary<int, SemanticArrayTypeDefinitionMask_I>();

		public BoundTypeDefinitionMask_I BaseType { get; set; }

        SemanticTypeDefinitionMask_I SemanticTypeDefinitionMask_I.BaseType => BaseType;

	    

		

		

		

		public ConvertedModuleMask_I Module { get; set; }

		SemanticModuleMask_I SemanticTypeDefinitionMask_I.Module => Module;

	    BoundModuleMask_I BoundTypeDefinitionMask_I.Module => Module;
	    public Dictionary<string, SemanticTypeMask_I> NestedTypes { get; set; } = new Dictionary<string, SemanticTypeMask_I>();

	    public PackingSize PackingSize { get; set; }

		public TypeReference SourceTypeReference { get; set; }

	    


		public TypeBuilder TypeBuilder { get; set; }

		public override TypeKind TypeKind => base.TypeKind | TypeKind.App | TypeKind.Definition;

	    // ReSharper disable once ConvertToAutoProperty
	    public System.Type UnderlyingType
	    {
		    get { return _UnderlyingType; }
		    set { _UnderlyingType = value; }
	    }

		



	    


	    





		/// <summary>
		/// Gets or sets the methods that reference this type.
		/// </summary>
		//public TypeEntryMethods Methods { get; set; } = new TypeEntryMethods();

		//public TypeEntryProperties Properties { get; set; } = new TypeEntryProperties();



		public Dictionary<string, ConvertedParameterTypeDefinitionClassifier_I> TypeParametersEntries { get; set; } =             new Dictionary<string, ConvertedParameterTypeDefinitionClassifier_I>();

        

        
        public GenericInstanceType GenericTypeInstance { get; set; }
        

        
    }
}
