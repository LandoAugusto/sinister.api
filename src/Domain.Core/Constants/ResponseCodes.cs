using Domain.Core.Extensions;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace Domain.Core.Constants
{
    [ExcludeFromCodeCoverage]
    public static class ResponseCodes
    {
        public const int Success = 00;
        public const int NotApplicable = -1;
        public const int ErrorTryAgain = 01;
        public const int ServiceUnavailable = 02;
        public const int TechnicalFailure = 03;
        public const int InconsistentData = 04;
        public const int InsuranceCompanyNotFoundActive = 05;

        public static string GetDescriptorTo(int responseCode) => responseCode switch
        {
            ErrorTryAgain => "Error Try Again",
            TechnicalFailure => "Technical Failure.",
            InconsistentData => "Inconsistent data.",
            ServiceUnavailable => "Service Unavailable",
            InsuranceCompanyNotFoundActive => "Insurance company not found / active",
            _ => responseCode.ToString(),
        };

        public static HttpStatusCode GetHttpStatusCodeTo(int responseCode) => responseCode switch
        {
            ErrorTryAgain => HttpStatusCode.InternalServerError,
            TechnicalFailure => HttpStatusCode.InternalServerError,
            InconsistentData => HttpStatusCode.BadRequest,
            ServiceUnavailable => HttpStatusCode.ServiceUnavailable,
            InsuranceCompanyNotFoundActive => HttpStatusCode.UnprocessableEntity,
            _ => HttpStatusCode.BadRequest,
        };

        public static int FromTransactionsApiHttpStatusCode(
            int httpStatusCode,
            string errorCode = default) =>
            httpStatusCode switch
            {
                (int)HttpStatusCode.OK
                    or (int)HttpStatusCode.Created => Success,
                (int)HttpStatusCode.BadRequest
                    or (int)HttpStatusCode.Unauthorized
                    or (int)HttpStatusCode.InternalServerError => TechnicalFailure,
                (int)HttpStatusCode.ServiceUnavailable
                    or (int)HttpStatusCode.BadGateway => ServiceUnavailable,
                (int)HttpStatusCode.Conflict
                    or (int)HttpStatusCode.RequestTimeout => ErrorTryAgain,
                (int)HttpStatusCode.UnprocessableEntity
                    when errorCode != default => errorCode.ToResponseCodeInt(),
                _ => NotApplicable
            };
    }
}
