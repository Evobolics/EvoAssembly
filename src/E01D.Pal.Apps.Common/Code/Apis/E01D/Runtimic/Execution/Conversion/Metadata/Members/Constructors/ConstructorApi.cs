using System;
using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors.Getting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata;
using Root.Code.Exts.E01D.Runtimic.Infrastructure.Metadata.Members;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Constructors
{
    public class ConstructorApi<TContainer> : ConversionApiNode<TContainer>, ConstructorApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I ConstructorApiMask_I.Building => Building;

	    public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I ConstructorApiMask_I.Getting => Getting;



		

	    

		


	}
}
