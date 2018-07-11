using System.Collections.Generic;
using System.Reflection.Emit;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Typal.Definitions
{
    public abstract class ConvertedTypeDefinition : ConvertedType, ConvertedTypeDefinition_I
    {
        ///// <summary>
        ///// Gets or sets the base type associated with the type entry.
        ///// </summary>
        //public new BoundTypeMask_I BaseType { get; set; }

        

        

        public TypeBuilder TypeBuilder { get; set; }

        public bool IsBaked { get; set; }

        /// <summary>
        /// Gets or sets whether the type has been built.  It has been built if a type builder has been assigned.
        /// </summary>
        public bool IsBuilt { get; set; }

        

        public override TypeKind TypeKind => base.TypeKind | TypeKind.App | TypeKind.Definition;

        public System.Type UnderlyingType { get; set; }

        public TypeReference SourceTypeReference { get; set; }

        public ModuleDefinition SourceModuleDefinition { get; set; }





        /// <summary>
        /// Gets or sets the methods that reference this type.
        /// </summary>
        //public TypeEntryMethods Methods { get; set; } = new TypeEntryMethods();

        //public TypeEntryProperties Properties { get; set; } = new TypeEntryProperties();



        public Dictionary<string, ConvertedParameterTypeDefinitionClassifier_I> TypeParametersEntries { get; set; } =             new Dictionary<string, ConvertedParameterTypeDefinitionClassifier_I>();

        

        
        public GenericInstanceType GenericTypeInstance { get; set; }

        
    }
}
