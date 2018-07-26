using System.Reflection;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using ExceptionHandler = System.Reflection.Emit.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithoutILGenerator
{
    public class ExceptionHandlingApi<TContainer> : ConversionApiNode<TContainer>, ExceptionHandlingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public ExceptionHandler[] GetExceptionHandlerList(ILConversion conversion, ConvertedRoutine convertedRoutine)
        {
            var methodDefinition = (MethodDefinition)convertedRoutine.MethodReference;



            var regions = methodDefinition.Body.ExceptionHandlers;
            var handlers = new ExceptionHandler[regions.Count];
            int i = 0;
            foreach (var info in regions)
            {
                int catchToken = 0;

                if (info.HandlerType == ExceptionHandlerType.Catch)
                {
                    var boundType = Execution.Types.Ensuring.EnsureBound(conversion.Model, info.CatchType);

                    catchToken = Execution.Types.GetToken(boundType);
                }

                handlers[i++] = new ExceptionHandler(
                    tryOffset: (int)info.TryStart.Offset,
                    tryLength: (int)info.TryEnd.Offset - (int)info.TryStart.Offset,
                    filterOffset: (int)info.FilterStart.Offset,
                    handlerOffset: (int)info.HandlerStart.Offset,
                    handlerLength: (int)info.HandlerEnd.Offset - (int)info.HandlerStart.Offset,
                    kind: (ExceptionHandlingClauseOptions)info.HandlerType,
                    exceptionTypeToken: catchToken);
            }

            return handlers;
        }
    }
}
