﻿using Mono.Cecil;
using Root.Code.Models.E01D.Runtimic.Execution.Conversion;

namespace Root.Code.Apis.E01D.Runtimic.Execution.Conversion.Metadata.Members.Types
{
    public interface TypeScanningApiMask_I
    {

        void EnsureType(ILConversion conversion, TypeReference typeReference);



    }
}