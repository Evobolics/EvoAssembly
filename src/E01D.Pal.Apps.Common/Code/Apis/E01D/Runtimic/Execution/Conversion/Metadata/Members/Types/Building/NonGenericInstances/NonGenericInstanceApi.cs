using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
    public class NonGenericInstanceApi<TContainer> : ConversionApiNode<TContainer>, NonGenericInstanceApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public Phase0PreSearchBuildApi_I<TContainer> Phase0PreSearch { get; set; }

		Phase0PreSearchBuildApiMask_I NonGenericInstanceApiMask_I.Phase0PreSearch => Phase0PreSearch;

		public Phase1InitialBuildApi_I<TContainer> Phase1Initial { get; set; }

		Phase1InitialBuildApiMask_I NonGenericInstanceApiMask_I.Phase1Initial => Phase1Initial;

		public Phase2MemberBuildApi_I<TContainer> Phase2Members { get; set; }

		Phase2MemberBuildApiMask_I NonGenericInstanceApiMask_I.Phase2Members => Phase2Members;

	    public Phase3InstructionBuildApi_I<TContainer> Phase3Instructions { get; set; }

		Phase3InstructionBuildApiMask_I NonGenericInstanceApiMask_I.Phase3Instructions => Phase3Instructions;
	}
}
