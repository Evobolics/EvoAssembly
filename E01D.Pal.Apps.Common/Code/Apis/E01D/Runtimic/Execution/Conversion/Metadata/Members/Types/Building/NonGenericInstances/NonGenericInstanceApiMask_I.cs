namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
    public interface NonGenericInstanceApiMask_I
    {
		Phase0PreSearchBuildApiMask_I Phase0PreSearch { get; }

	    Phase1InitialBuildApiMask_I Phase1Initial { get; }

	    Phase2MemberBuildApiMask_I Phase2Members { get; }

	    Phase3InstructionBuildApiMask_I Phase3Instructions { get; }
	}
}
