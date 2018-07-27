using System.Collections.Generic;
using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions
{
    /// <summary>
    /// Note interfaces do not have constructors so that property is not listed here.  But the good news that is that constructors are routines, so any
    /// algorithm that is acting on routines can get constructors and methods at the same time.  
    /// </summary>
    public abstract class ConvertedReferenceTypeDefinition: 
        ConvertedReferenceOrValueTypeDefinition, 
        ConvertedReferenceTypeDefinitionMask_I, 
        ConvertedTypeWithMethods_I
    {
        public ConvertedTypeDefinitionMethods Methods { get; set; } = new ConvertedTypeDefinitionMethods();

        public List<ConvertedRoutineMask_I> Routines { get; set; } = new List<ConvertedRoutineMask_I>();

        public ConvertedRoutinesEmitState RoutinesEmitState { get; set; }

        public override TypeKind TypeKind => base.TypeKind | TypeKind.Reference;

        SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

    }
}
