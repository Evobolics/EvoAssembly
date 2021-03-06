﻿using Root.Code.Enums.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundInterfaceTypeDefinition : BoundReferenceTypeDefinition, InterfaceType_I, BoundInterfaceTypeMask_I, BoundTypeDefinitionWithMethods_I

	{
        




        public override TypeKind TypeKind => base.TypeKind | TypeKind.Interface | TypeKind.SupportsInterfaceTypeList;

        /// <summary>
        /// Gets or sets the element entry, the foundation entry, if this interface is declared as a generic specification that contains
        /// type paramters from another type definition.  
        /// </summary>
        public BoundInterfaceTypeDefinition ElementEntry { get; set; }

        public TypeDefinition ParentTypeEntry { get; set; }
        public GenericInstanceType GenericInstanceType { get; set; }

        public SemanticTypeDefinitionInterfaces Interfaces { get; set; } = new SemanticTypeDefinitionInterfaces();

        SemanticTypeDefinitionInterfacesMask_I SemanticTypeWithInterfaceTypeListMask_I.Interfaces => Interfaces;

		public BoundTypeDefinitionMethods Methods { get; set; } = new BoundTypeDefinitionMethods();

		SemanticTypeMethodsMask_I SemanticTypeWithMethodsMask_I.Methods => this.Methods;

	}
}
