﻿using System;
using System.Collections.Generic;
using System.Linq;
using Root.Code.Containers.E01D.Runtimic;
using Root.Code.Libs.Mono.Cecil;
using Root.Code.Libs.Mono.Cecil.Cil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.IL;
using ExceptionHandler = Root.Code.Libs.Mono.Cecil.Cil.ExceptionHandler;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Instructions.Building.WithILGenerator
{
    public class ExceptionHandlingApi<TContainer> : ConversionApiNode<TContainer>, ExceptionHandlingApi_I<TContainer>
        where TContainer : RuntimicContainer_I<TContainer>
    {
        public void Preprocess(ILConversion conversion, ConvertedRoutine routine)
        {
	        if (routine.IsExceptionHandlingInfoPreprocessed) return;

	        routine.IsExceptionHandlingInfoPreprocessed = true;

			routine.ExceptionHandlingInfo = new ExceptionHandlingInfo();

	        var handlingInfo = routine.ExceptionHandlingInfo;

		   var methodDefinition = (MethodDefinition)routine.MethodReference;

			var methodDefinitionBody = methodDefinition.Body;

            if (!methodDefinitionBody.HasExceptionHandlers) return;

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
                                // The first instruction that is included in the try catch block
                                TryStartOffset = exceptionBlock.TryStart.Offset,
                                // Gets the first instruction of the catch statement
                                TryEndOffset = exceptionBlock.TryEnd.Offset,
                                // Gets the first instruction that is outside of the catch statement
                                HandlerEndOffset = exceptionBlock.HandlerEnd.Offset,
                                FilterStartOffset = exceptionBlock.FilterStart?.Offset ?? -1,
                                HandlerEntries = new Dictionary<int, List<ExceptionHandler>>()
                            };

                            handlingInfo.TryCatchEntries.Add(tryCatchBlock);

                            handlingInfo.ExceptionBlocks.Add(tryCatchBlock);
                            
                            System.Diagnostics.Debug.WriteLine($"Try-Catch:  BEGIN @ {exceptionBlock.TryStart.Offset.ToString("X2")}");

                            AddEvent(conversion, ExceptionBlockEventKind.Begin, handlingInfo, exceptionBlock.TryStart.Offset, tryCatchBlock);
                        }

                        if (!tryCatchBlock.HandlerEntries.TryGetValue(exceptionBlock.HandlerStart.Offset, out List<ExceptionHandler> list))
                        {
                            list = new List<ExceptionHandler>();

                            tryCatchBlock.HandlerEntries.Add(exceptionBlock.HandlerStart.Offset, list);
                        }

                        list.Add(exceptionBlock);

                        System.Diagnostics.Debug.WriteLine($"Try-Catch:  CATCH @ {exceptionBlock.HandlerStart.Offset.ToString("X2")}");
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

                System.Diagnostics.Debug.WriteLine($"Try-Catch:  END CATCH @ {lastHandlerEntry.HandlerEnd.Offset.ToString("X2")}");

                AddEvent(conversion, ExceptionBlockEventKind.EndBlock, handlingInfo, lastHandlerEntry.HandlerEnd.Offset, tryCatchBlock);
            }

            
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

        public void ProcessInstruction(ILConversion conversion, ConvertedRoutine routine, Instruction instruction)
        {
	        var info = routine.ExceptionHandlingInfo;

	        var ilGenerator = routine.IlGenerator;

			var methodReference = routine.MethodReference;

	        if (!methodReference.IsDefinition) return;

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
                        System.Diagnostics.Debug.WriteLine($"try     @ {instruction.Offset.ToString("X2")}");
                        
                        ilGenerator.BeginExceptionBlock();
                        break;
                    }
                    case ExceptionBlockEventKind.Catch:
                    {
                        System.Diagnostics.Debug.WriteLine($"catch   @ {instruction.Offset.ToString("X2")}");
                            var typeReference = eventEntry.ExceptionHandler.CatchType;

                        var declaringType = Execution.Types.Ensuring.EnsureToType(conversion, typeReference);

                        ilGenerator.BeginCatchBlock(declaringType);

                        break;
                    }

                    case ExceptionBlockEventKind.Finally:
                    {
                        System.Diagnostics.Debug.WriteLine($"finally @ {instruction.Offset.ToString("X2")}");
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
                        System.Diagnostics.Debug.WriteLine($"end     @ {instruction.Offset.ToString("X2")}");
                        ilGenerator.EndExceptionBlock();
                        break;
                    }
                }
            }
        }
    }
}
