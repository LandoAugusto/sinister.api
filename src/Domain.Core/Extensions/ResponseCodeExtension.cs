using Domain.Core.Constants;

namespace Domain.Core.Extensions
{
    public static class ResponseCodeExtension
    {
        public static string ToResponseCodeFormat(this int responseCode) =>
            responseCode.ToString().PadLeft(2, '0');

        public static string ToResponseCodeString(this int responseCodeInt) =>
            responseCodeInt.ToString().PadLeft(2, '0');

        public static int ToResponseCodeInt(this string responseCodeString) =>
            int.TryParse(responseCodeString, out var responseCodeInt)
                ? responseCodeInt
                : ResponseCodes.NotApplicable;
    }
}