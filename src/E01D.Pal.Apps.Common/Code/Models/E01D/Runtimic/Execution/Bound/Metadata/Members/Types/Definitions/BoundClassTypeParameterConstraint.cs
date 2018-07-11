namespace Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions
{
    public class BoundClassTypeParameterConstraint : BoundGenericParameterTypeDefinitionConstraint
    {
        public BoundTypeMask_I Class { get; set; }
        public override BoundTypeMask_I SemanticType => Class;
    }
}
