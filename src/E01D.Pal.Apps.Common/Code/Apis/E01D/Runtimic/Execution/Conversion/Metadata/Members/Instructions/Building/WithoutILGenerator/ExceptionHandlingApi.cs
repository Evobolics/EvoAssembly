using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types.Definitions;
using ExceptionHandler = System.Reflection.Emit.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public class ExceptionHandlingApi<TContainer> : ConversionApiNode<TContainer>, ExceptionHandlingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public bool GetExceptionHandlerList(ILConversion conversion, ConvertedRoutine convertedRoutine)
        {
            var methodDefinition = (MethodDefinition)convertedRoutine.MethodReference;


            var moduleBuilder = convertedRoutine.DeclaringType.Module.ModuleBuilder;
            var regions = methodDefinition.Body.ExceptionHandlers;
            var handlers = new ExceptionHandler[regions.Count];
            var bodyEmitState = convertedRoutine.EmitState.Body;

            for (int i = bodyEmitState.CurrentExceptionHandler; i < regions.Count; bodyEmitState.CurrentExceptionHandler = ++i)
            {
                var info = regions[i];

                int catchToken = 0;

                if (info.HandlerType == ExceptionHandlerType.Catch)
                {
                    var boundType = Execution.Types.Ensuring.EnsureBound(conversion, info.CatchType);

                    if ((boundType is ConvertedTypeDefinition_I convertedType)
                        && Types.Building.CheckForPhase3Dependency(convertedType, (ConvertedTypeDefinition_I)convertedRoutine.DeclaringType, true))
                    {
                        return false;
                    }

                    catchToken = moduleBuilder.GetTypeToken(boundType.UnderlyingType).Token;

                    if (catchToken == 0)
                    {
                        
                    }
                }

                handlers[i] = new ExceptionHandler(
                    tryOffset: info.TryStart.Offset,
                    tryLength: info.TryEnd.Offset - info.TryStart.Offset,
                    filterOffset: info.FilterStart?.Offset ?? 0,
                    handlerOffset: info.HandlerStart.Offset,
                    handlerLength: info.HandlerEnd.Offset - info.HandlerStart.Offset,
                    kind: (ExceptionHandlingClauseOptions)info.HandlerType,
                    exceptionTypeToken: catchToken);
            }
          

            convertedRoutine.EmitState.Body.ExceptionHandlers = handlers;

            return true;
        }
    }
}
