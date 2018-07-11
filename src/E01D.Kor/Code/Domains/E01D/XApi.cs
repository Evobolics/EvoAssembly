using Root.Code.Apis.E01D;

namespace Root.Code.Domains.E01D
{
    public static class XKor
    {
        public static KorApi Api { get; set; } = new KorApi();

        public static DebugApi_I Debug => Api.Debug;
    }
}
