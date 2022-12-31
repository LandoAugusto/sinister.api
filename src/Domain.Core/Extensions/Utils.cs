using System.Text.RegularExpressions;

namespace Domain.Core.Extensions
{
    public static class Utils
    {
        public static string Format(this string format, params object[] args) =>
            string.Format(format, args);


        public static bool IsAny<T>(this IEnumerable<T> data)
        {
            return data != null && data.Any();
        }

        public static string OnlyNumerical(this string value)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(value, "");
        }

    }
}
