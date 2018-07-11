using Root.Code.Containers.E01D.Runtimic;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Building.NonGenericInstances
{
    public class NonGenericInstanceApi<TContainer> : BindingApiNode<TContainer>, NonGenericInstanceApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
		public Phase0PreSearchBuildApi_I<TContainer> Phase0PreSearch { get; set; }

		Phase0PreSearchBuildApiMask_I NonGenericInstanceApiMask_I.Phase0PreSearch => Phase0PreSearch;

		public Phase1InitialBuildApi_I<TContainer> Phase1Initial { get; set; }

		Phase1InitialBuildApiMask_I NonGenericInstanceApiMask_I.Phase1Initial => Phase1Initial;

		public Phase2DependencyBuildApi_I<TContainer> Phase2Dependency { get; set; }

		Phase2DependencyBuildApiMask_I NonGenericInstanceApiMask_I.Phase2Dependency => Phase2Dependency;
	}
}
