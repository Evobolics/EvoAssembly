	using System;
	using System.Reflection;
	using System.Reflection.Emit;
	using Mono.Cecil;
	using Root.Code.Containers.E01D.Runtimic;
	using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members;
	using Root.Code.Models.E01D.Runtimic.Execution.Bound.Metadata.Members.Types.Definitions;
	using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Building.NonGenericInstances
{
	public class Phase2MemberBuildApi<TContainer> : ConversionApiNode<TContainer>, Phase2MemberBuildApi_I<TContainer>
		where TContainer : RuntimicContainer_I<TContainer>
	{
		/// <summary>
		/// Adds builds all of the members and adds them to the type.
		/// </summary>
		/// <param name="conversion"></param>
		/// <param name="converted"></param>
		public void Build(ILConversion conversion, ConvertedTypeDefinition_I converted)
		{
			// DESIGN NOTE:
			// Add all members to the type.

			

			Members.TypeParameters.Building.EnsureTypeParametersIfAny(conversion, converted);

			Types.Ensuring.Gathering.EnsureBaseType(conversion, converted);
				
			Types.Ensuring.Gathering.EnsureInterfaces(conversion, converted);

			// FIX: needs to take generic arguments into account
			Types.Ensuring.Gathering.GetNestedTypes(conversion, converted);

			Fields.Building.NonGeneric.BuildFields(conversion, converted);

			Routines.Building.BuildRoutines(conversion, converted);

			Properties.Building.BuildsProperties(conversion, converted);

			Events.Building.BuildEvents(conversion, converted);

			CustomAttributes.BuildCustomAttributes(conversion, converted);

			// DESIGN NOTE:
			// Do not place the building of instructions within this phase.  The instructions can need
			// generic instances of the class being built.  The generic instances need the methods that orginate from
			// this phase.  But they cannot get them till this phase is complete, and they can add their own members.
			//Instructions.Building.BuildInstructions(conversion, converted);







		}

		
	}
}
