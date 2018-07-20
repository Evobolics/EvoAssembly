using System.Reflection;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Building;
using Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods.Getting;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Methods
{
	public class MethodApi<TContainer> : ConversionApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer: RuntimicContainer_I<TContainer>
    {
        public BuildingApi_I<TContainer> Building { get; set; }

        BuildingApiMask_I MethodApiMask_I.Building => Building;

        public GettingApi_I<TContainer> Getting { get; set; }

	    GettingApiMask_I MethodApiMask_I.Getting => Getting;

        public TypeParameterApi_I<TContainer> TypeParameters { get; set; }

        TypeParameterApiMask_I MethodApiMask_I.TypeParameters => TypeParameters;


        public TypeScanningApi_I<TContainer> TypeScanning { get; set; }

        TypeScanningApiMask_I MethodApiMask_I.TypeScanning => TypeScanning;

	    

        



        public CallingConventions GetCallingConventions(MethodReference methodReference)
        {
            

            CallingConventions callingConventions = default(CallingConventions);

	        if (methodReference.HasThis)
	        {
				callingConventions |= CallingConventions.HasThis;
			}

            if ((methodReference.CallingConvention & MethodCallingConvention.C) == MethodCallingConvention.C)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.Default) == MethodCallingConvention.Default)
            {
                callingConventions |= CallingConventions.Standard;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.FastCall) == MethodCallingConvention.FastCall)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.Generic) == MethodCallingConvention.Generic)
            {

            }

            if ((methodReference.CallingConvention & MethodCallingConvention.StdCall) == MethodCallingConvention.StdCall)
            {
                callingConventions |= CallingConventions.Standard;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.ThisCall) == MethodCallingConvention.ThisCall)
            {
                callingConventions |= CallingConventions.HasThis;
            }

            if ((methodReference.CallingConvention & MethodCallingConvention.VarArg) == MethodCallingConvention.VarArg)
            {
                callingConventions |= CallingConventions.VarArgs;
            }

            return callingConventions;

        }

		

	}
}
