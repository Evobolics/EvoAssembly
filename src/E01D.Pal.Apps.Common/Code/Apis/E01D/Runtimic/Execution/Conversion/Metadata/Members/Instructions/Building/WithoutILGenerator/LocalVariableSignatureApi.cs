using System;
using System.Reflection.Emit;
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
        public bool GetLocalSignature(ILConversion conversion, ConvertedRoutine routine)
        {
            var bodyEmitState = routine.EmitState.Body;

            if (bodyEmitState.SignatureHelper == null)
            {
                bodyEmitState.SignatureHelper = SignatureHelper.GetLocalVarSigHelper(routine.DeclaringType.Module.ModuleBuilder);
            }

            var localVariables = routine.Body.LocalVariables;

            if (localVariables != null)
            {
                for (int i = bodyEmitState.CurrentLocalVariable; i < localVariables.Length; bodyEmitState.CurrentLocalVariable = ++i)
                {
                    var localVariable = localVariables[i];

                    if (localVariable.CustomModifiers != null && localVariable.CustomModifiers.Count > 0)
                    {
                        throw new Exception("Currently do not support emitted custom modifiers in local variables");
                    }

                    bodyEmitState.SignatureHelper.AddArgument(localVariable.UnderlyingType, localVariable.IsPinned);
                }
            }

            bodyEmitState.LocalSignature = bodyEmitState.SignatureHelper.GetSignature();

            return true;

            //var e01dLocalSignature = Signatures.GetLocalSignature(conversion, convertedConstructor);

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
