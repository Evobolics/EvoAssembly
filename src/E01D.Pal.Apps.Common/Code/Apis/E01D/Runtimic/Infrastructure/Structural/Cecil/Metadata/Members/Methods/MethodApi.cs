using System;
using Mono.Cecil;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Building;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods.Getting;

namespace Root.Code.Apis.E01D.Runtimic.Infrastructure.Structural.Cecil.Metadata.Members.Methods
{
	public class MethodApi<TContainer> : RuntimeApiNode<TContainer>, MethodApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		public BuildingApi_I<TContainer> Building { get; set; }


		BuildingApiMask_I MethodApiMask_I.Building => Building;

		public EnsuringApi_I<TContainer> Ensuring { get; set; }
		

		EnsuringApiMask_I MethodApiMask_I.Ensuring => Ensuring;

		public GettingApi_I<TContainer> Getting { get; set; }


		GettingApiMask_I MethodApiMask_I.Getting => Getting;


		public bool ContainsMethodGenericParameters(MethodReference methodReference)
		{
			if (methodReference.GenericParameters.Count < 1) return false;

			for (int i = 0; i < methodReference.GenericParameters.Count; i++)
			{
				var genericParameter = methodReference.GenericParameters[i];

				if (genericParameter.DeclaringMethod != null) return true;
			}

			return false;
		}

		public bool ContainsClassGenericParameters(MethodReference methodReference)
		{
			throw new Exception("Wrong");
			//if (methodReference.GenericParameters.Count < 1) return false;

			//for (int i = 0; i < methodReference.GenericParameters.Count; i++)
			//{
			//	var genericParameter = methodReference.GenericParameters[i];

			//	if (genericParameter.DeclaringType != null) return true;
			//}

			//return false;
		}

	}
}
