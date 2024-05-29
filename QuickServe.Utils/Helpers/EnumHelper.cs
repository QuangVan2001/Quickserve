namespace QuickServe.Utils.Helpers
{
    public static class EnumHelper
    {
        public static bool IsEnumValid<T>(string value)
        {
            return Enum.TryParse(typeof(T), value, true, out _);
        }
    }
}
