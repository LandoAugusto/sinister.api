using System.Runtime.CompilerServices;

namespace SinisterApi.Infra.Logger.Interfaces
{
    public interface ILogWriter
    {
        void SetCorrelationId(Guid correlationId);

        void Info(
            string message,
            object data = default,
            Exception ex = default,
            [CallerMemberName] string source = "");

        void Warn(
            string message,
            object data = default,
            Exception ex = default,
            [CallerMemberName] string source = "");

        void Error(
            string message,
            object data = default,
            Exception ex = default,
            [CallerMemberName] string source = "");

        void Fatal(
            string message,
            object data = default,
            Exception ex = default,
            [CallerMemberName] string source = "");
    }
}
