namespace OrdenesDeinversion.Helper
{
    public static class StringFormatHelper
    {
        public static string Sanitize(this string s) => System.Web.HttpUtility.HtmlEncode(s.Replace("\r", string.Empty).Replace("\n", string.Empty));
    }
}
