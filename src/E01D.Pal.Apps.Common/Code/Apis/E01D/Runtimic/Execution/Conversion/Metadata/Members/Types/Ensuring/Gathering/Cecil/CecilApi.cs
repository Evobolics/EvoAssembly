using System;
using System.Collections.Generic;
using Mono.Cecil;
using Mono.Cecil.Rocks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Metadata.Members.Typal.Definitions;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Emitting.Conversion.Metadata.Members.Typal.Ensuring.Cecil
{
    public class CecilApi<TContainer> : ConversionApiNode<TContainer>, CecilApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public GatheringApi<TContainer> Gathering { get; set; }

        public AssignmentApi<TContainer> Assignment { get; set; }

        AssignmentApiMask_I CecilApiMask_I.Assignment => Assignment;

        GatheringApiMask_I CecilApiMask_I.Gathering => Gathering;

        
    }

    
}
