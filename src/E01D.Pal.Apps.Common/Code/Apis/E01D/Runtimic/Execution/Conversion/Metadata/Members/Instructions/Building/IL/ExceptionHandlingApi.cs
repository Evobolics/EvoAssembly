using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL;
using ExceptionHandler = Mono.Cecil.Cil.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.IL
{
    public class ExceptionHandlingApi<TContainer> : ConversionApiNode<TContainer>, ExceptionHandlingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public ExceptionHandlingInfo Preprocess(ILConversion conversion, MethodBody methodDefinitionBody)
        {
            var handlingInfo = new ExceptionHandlingInfo();

            if (!methodDefinitionBody.HasExceptionHandlers) return null;

            foreach (var exceptionBlock in methodDefinitionBody.ExceptionHandlers)
            {
                switch (exceptionBlock.HandlerType)
                {
                    case ExceptionHandlerType.Filter:
                    {
                        var filterBlock = new FilterBlock()
                        {
                            TryStartOffset = exceptionBlock.TryStart.Offset,
                            TryEndOffset = exceptionBlock.TryEnd.Offset,
                            HandlerEndOffset = exceptionBlock.HandlerEnd.Offset,
                            FilterStartOffset = exceptionBlock.FilterStart?.Offset ?? -1,
                            ExceptionHandler = exceptionBlock
                        };

                        handlingInfo.ExceptionBlocks.Add(filterBlock);

                        AddEvent(conversion, ExceptionBlockEventKind.Begin, handlingInfo, exceptionBlock.TryStart.Offset, filterBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.Finally, handlingInfo, exceptionBlock.HandlerStart.Offset, filterBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.EndBlock, handlingInfo, exceptionBlock.HandlerEnd.Offset, filterBlock);

                        break;
                    }
                    case ExceptionHandlerType.Fault:
                    {
                        var faultBlock = new FaultBlock()
                        {
                            TryStartOffset = exceptionBlock.TryStart.Offset,
                            TryEndOffset = exceptionBlock.TryEnd.Offset,
                            HandlerEndOffset = exceptionBlock.HandlerEnd.Offset,
                            FilterStartOffset = exceptionBlock.FilterStart?.Offset ?? -1,
                            ExceptionHandler = exceptionBlock
                        };

                        handlingInfo.ExceptionBlocks.Add(faultBlock);

                        AddEvent(conversion, ExceptionBlockEventKind.Begin, handlingInfo, exceptionBlock.TryStart.Offset, faultBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.Finally, handlingInfo, exceptionBlock.HandlerStart.Offset, faultBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.EndBlock, handlingInfo, exceptionBlock.HandlerEnd.Offset, faultBlock);

                        break;
                    }
                    case ExceptionHandlerType.Finally:
                    {
                        var finallyBlock = new TryFinallyBlock()
                        {
                            TryStartOffset = exceptionBlock.TryStart.Offset,
                            TryEndOffset = exceptionBlock.TryEnd.Offset,
                            HandlerEndOffset = exceptionBlock.HandlerEnd.Offset,
                            FilterStartOffset = exceptionBlock.FilterStart?.Offset ?? -1,
                            ExceptionHandler = exceptionBlock
                        };

                        handlingInfo.ExceptionBlocks.Add(finallyBlock);

                        AddEvent(conversion, ExceptionBlockEventKind.Begin, handlingInfo, exceptionBlock.TryStart.Offset, finallyBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.Finally, handlingInfo, exceptionBlock.HandlerStart.Offset, finallyBlock);
                        AddEvent(conversion, ExceptionBlockEventKind.EndBlock, handlingInfo, exceptionBlock.HandlerEnd.Offset, finallyBlock);

                        break;
                    }
                    case ExceptionHandlerType.Catch:
                    {
                        TryCatchBlock tryCatchBlock = null;

                        for (int i = 0; i < handlingInfo.TryCatchEntries.Count; i++)
                        {
                            var x = handlingInfo.TryCatchEntries[i];

                            if (x.TryStartOffset == exceptionBlock.TryStart.Offset && x.TryEndOffset == exceptionBlock.TryEnd.Offset)
                            {
                                tryCatchBlock = x;
                            }
                        }

                        if (tryCatchBlock == null)
                        {
                            tryCatchBlock = new TryCatchBlock()
                            {
                                TryStartOffset = exceptionBlock.TryStart.Offset,
                                TryEndOffset = exceptionBlock.TryEnd.Offset,
                                HandlerEndOffset = exceptionBlock.HandlerEnd.Offset,
                                FilterStartOffset = exceptionBlock.FilterStart?.Offset ?? -1,
                                HandlerEntries = new Dictionary<int, List<ExceptionHandler>>()
                            };

                            handlingInfo.TryCatchEntries.Add(tryCatchBlock);

                            handlingInfo.ExceptionBlocks.Add(tryCatchBlock);

                            AddEvent(conversion, ExceptionBlockEventKind.Begin, handlingInfo, exceptionBlock.TryStart.Offset, tryCatchBlock);
                        }

                        if (!tryCatchBlock.HandlerEntries.TryGetValue(exceptionBlock.HandlerStart.Offset, out List<ExceptionHandler> list))
                        {
                            list = new List<ExceptionHandler>();

                            tryCatchBlock.HandlerEntries.Add(exceptionBlock.HandlerStart.Offset, list);
                        }

                        list.Add(exceptionBlock);

                        AddEvent(conversion, ExceptionBlockEventKind.Catch, handlingInfo, exceptionBlock.HandlerStart.Offset, tryCatchBlock, exceptionBlock);

                        break;
                    }
                    default:
                    {
                        throw new NotSupportedException();
                    }

                }
            }

            for (int i = 0; i < handlingInfo.TryCatchEntries.Count; i++)
            {
                var tryCatchBlock = handlingInfo.TryCatchEntries[i];

                ExceptionHandler lastHandlerEntry = null;

                var handlerEntriesListList = tryCatchBlock.HandlerEntries.Values.ToList();

                for (int j = 0; j < handlerEntriesListList.Count; j++)
                {
                    var currentHandlerEntryList = handlerEntriesListList[j];

                    for (int k = 0; k < currentHandlerEntryList.Count; k++)
                    {
                        var currentHandlerEntry = currentHandlerEntryList[k];

                        if (lastHandlerEntry == null)
                        {
                            lastHandlerEntry = currentHandlerEntry;
                        }
                        else if (currentHandlerEntry.HandlerEnd.Offset > lastHandlerEntry.HandlerEnd.Offset)
                        {
                            lastHandlerEntry = currentHandlerEntry;
                        }
                    }
                }

                if (lastHandlerEntry == null) continue;

                AddEvent(conversion, ExceptionBlockEventKind.EndBlock, handlingInfo, lastHandlerEntry.HandlerEnd.Offset, tryCatchBlock);
            }

            return handlingInfo;
        }

        public void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind, ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock, ExceptionHandler exceptionHandler)
        {
            var entry = new ExceptionBlockEventEntry()
            {
                ExceptionBlock = exceptionBlock,
                Kind = eventKind,
                Offset = offset,
                ExceptionHandler = exceptionHandler
            };

            if (!handlingInfo.Events.TryGetValue(offset, out List<ExceptionBlockEventEntry> eventList))
            {
                eventList = new List<ExceptionBlockEventEntry>();

                handlingInfo.Events.Add(offset, eventList);
            }

            eventList.Add(entry);
        }

        public void AddEvent(ILConversion conversion, ExceptionBlockEventKind eventKind, ExceptionHandlingInfo handlingInfo, int offset, ExceptionBlock exceptionBlock)
        {
            AddEvent(conversion, eventKind, handlingInfo, offset, exceptionBlock, null);
        }

        public void ProcessInstruction(ILConversion conversion, ConvertedRoutine entry, ExceptionHandlingInfo info, Instruction instruction, ILGenerator ilGenerator)
        {
	        var methodReference = entry.MethodReference;

	        if (methodReference.IsDefinition) return;

	        var methodDefintion = (MethodDefinition) methodReference;


			if (!methodDefintion.Body.HasExceptionHandlers) return;

            if (!info.Events.TryGetValue(instruction.Offset, out List<ExceptionBlockEventEntry> events))
            {
                return;
            }

            foreach (var eventEntry in events)
            {
                switch (eventEntry.Kind)
                {
                    case ExceptionBlockEventKind.Begin:
                    {
                        ilGenerator.BeginExceptionBlock();
                        break;
                    }
                    case ExceptionBlockEventKind.Catch:
                    {
                        var typeReference = eventEntry.ExceptionHandler.CatchType;

                        var declaringType = Execution.Types.Ensuring.EnsureToType(conversion, typeReference);

                        ilGenerator.BeginCatchBlock(declaringType);

                        break;
                    }

                    case ExceptionBlockEventKind.Finally:
                    {
                        ilGenerator.BeginFinallyBlock();
                        break;
                    }

                    case ExceptionBlockEventKind.Fault:
                    {
                        ilGenerator.BeginFaultBlock();
                        break;
                    }
                    case ExceptionBlockEventKind.Filter:
                    {
                        ilGenerator.BeginExceptFilterBlock();
                        break;
                    }
                    case ExceptionBlockEventKind.EndBlock:
                    {
                        ilGenerator.EndExceptionBlock();
                        break;
                    }
                }
            }
        }
    }
}
