using System.Runtime.Serialization;

namespace Nanis.Shared.Exceptions
{
    public class CriteriaNullException : ArgumentNullException
    {
        public int? ErrorCode { get; }
        public string? Context { get; }
        public CriteriaNullException()
        {
        }

        public CriteriaNullException(string? paramName)
            : base(paramName, "The criteria object cannot be null. Please define a criteria before applying a logical operator.")
        {
        }

        public CriteriaNullException(string? paramName, int? errorCode, string? context)
            : base($"The criteria '{paramName}' parameter cannot be null. Please define a criteria before applying a logical operator.")
        {
            ErrorCode = errorCode;
            Context = context;
        }

        public CriteriaNullException(string? message, System.Exception? innerException) : base(message, innerException)
        {

        }

        public CriteriaNullException(string? paramName, string? message) : base(paramName, message)
        {
        }

        protected CriteriaNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
