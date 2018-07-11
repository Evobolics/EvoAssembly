using System;

namespace Root.Code.Apis.E01D
{
    public class DebugApi:DebugApi_I
    {
        public void Assert(bool condition)
        {
            if (!condition) throw new Exception("Assert failed.");
        }
    }
}
