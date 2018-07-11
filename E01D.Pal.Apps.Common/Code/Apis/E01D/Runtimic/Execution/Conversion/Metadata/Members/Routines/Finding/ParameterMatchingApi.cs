using Mono.Cecil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Routines.Finding
{
    public class ParameterMatchingApi<TContainer> : ConversionApiNode<TContainer>, ParameterMatchingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public bool VerifyParameters(ILConversion conversion, MethodReference currentMethod, MethodReference targetMethod)
        {
            var currentParameters = currentMethod.Parameters;

            var targetParameters = targetMethod.Parameters;

            if (currentParameters.Count != targetParameters.Count) return false;

            for (int i = 0; i < currentParameters.Count; i++)
            {
                var currentParameter = currentParameters[i];

                var targetParameter = targetParameters[i];

                var currentParameterType = currentParameter.ParameterType;

                var targetParameterType = targetParameter.ParameterType;

                if (!Routines.Finding.TypeMatching.VerifyTypeMatch(conversion, currentParameterType, targetParameterType, null)) return false;

                if (currentParameter.IsIn != targetParameter.IsIn ||
                    currentParameter.IsOut != targetParameter.IsOut ||
                    currentParameterType.IsByReference != targetParameterType.IsByReference)
                {
                    return false;
                }


            }



            return true;
        }

    }
}
