using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public class LocalVariableSignatureApi<TContainer> : ConversionApiNode<TContainer>, LocalVariableSignatureApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        /// <summary>
        /// Gets an array of bytes that contain the serialized local variable structure (.locals structure) of a routine.
        /// </summary>
        /// <param name="conversion"></param>
        /// /// <param name="routine"></param>
        /// <returns></returns>
        public byte[] GetLocalSignature(ILConversion conversion, ConvertedRoutine routine)
        {
            var sigHelper = SignatureHelper.GetLocalVarSigHelper(routine.DeclaringType.Module.ModuleBuilder);

            var localVariables = routine.Body.LocalVariables;

            for (int i = 0; i < localVariables.Count; i++)
            {
                var localVariable = localVariables[i];

                if (localVariable.CustomModifiers != null && localVariable.CustomModifiers.Count > 0)
                {
                    throw new Exception("Currently do not support emitted custom modifiers in local variables");
                }
                else
                {
                    sigHelper.AddArgument(localVariable.UnderlyingType, localVariable.IsPinned);
                }
            }

            var sigHelperResult = sigHelper.GetSignature();

            return sigHelperResult;


            //foreach (var local in routine.Body.LocalVariables)
            //{
            //var type = ResolveType(local.Type);
            //if (local.IsReference)
            //{
            //	type = type.MakeByRefType();
            //}

            //if (local.CustomModifiers.Any())
            //{
            //	if (local.IsPinned)
            //	{
            //		throw new NotSupportedException("Ref.Emit limitation");
            //	}

            //	Type[] reqMods, optMods;
            //	ResolveCustomModifiers(local.CustomModifiers, out reqMods, out optMods);
            //	sigHelper.AddArgument(type, reqMods, optMods);
            //}
            //else
            //{
            //	sigHelper.AddArgument(type, local.IsPinned);
            //}

            //localCount++;
            //}
        }
    }
}
