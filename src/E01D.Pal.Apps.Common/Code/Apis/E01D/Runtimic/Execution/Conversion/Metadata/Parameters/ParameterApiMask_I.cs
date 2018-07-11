using System;
using System.Collections.Generic;
using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Infrastructure.Semantic.Metadata.Members.Typal;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Parameters
{
    public interface  ParameterApiMask_I
    {
        Type[] GetSystemParameterTypes(ILConversion conversion, SemanticTypeMask_I[] methodEntryParameterTypes);


        Type[] GetSystemParameterTypes(ILConversion conversion, MethodReference methodReference);

        Type[] GetSystemParameterTypes(ILConversion conversion, List<SemanticRoutineParameterMask_I> parameters);

        Type[] GetSystemParameterTypes(ILConversion conversion,
            Mono.Collections.Generic.Collection<ParameterDefinition> parameters);

        Type[] GetSystemParameterTypes(ILConversion conversion,
            Mono.Collections.Generic.Collection<TypeReference> collection);
    }
}
