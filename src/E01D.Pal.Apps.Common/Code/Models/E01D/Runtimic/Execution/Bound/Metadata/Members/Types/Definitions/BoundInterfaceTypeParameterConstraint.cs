namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundInterfaceTypeParameterConstraint : BoundGenericParameterTypeDefinitionConstraint
    {
        public BoundTypeMask_I Interface { get; set; }
        public override BoundTypeMask_I SemanticType => Interface;
    }
}
