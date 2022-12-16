﻿using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace SinisterApi.Domain.Models
{
    public record ErrorResponseModel : BaseResponse
    {
        [System.Text.Json.Serialization.JsonIgnore]
        [Newtonsoft.Json.JsonIgnore]
        public static int StatusCode { get; private set; }

        public static ErrorResponseModel FromValidation(ValidationResult validationResult)
        {
            var resultError = validationResult.Errors
                .Select(err => err)
                .Distinct()
                .FirstOrDefault();

            StatusCode = StatusCodes.Status400BadRequest;

            return BuildError(resultError.ErrorMessage);
        }

        public static ErrorResponseModel FromBadAuthorization() =>
            BuildError(message: "Invalid token.");

        public static ErrorResponseModel FromSqlException() =>
          BuildError("Invalid data.");

        public static ErrorResponseModel BuildError(string message) => new()
        {
            ResponseDate = DateTime.Now,
            Message = message,
        };
    }
}