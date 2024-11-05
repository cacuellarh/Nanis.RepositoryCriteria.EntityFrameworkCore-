using System.Runtime.Serialization;

namespace Nanis.Shared.Exceptions
{
    public class CriteriaPropertiesAreNullException : ArgumentNullException
    {
        public CriteriaPropertiesAreNullException()
            : base("No criteria were applied. At least one property or condition must be set to evaluate the criteria. " +
                   "Please ensure that at least one filtering criterion or sort condition is defined before executing the query.")
        {
        }

        public CriteriaPropertiesAreNullException(string? paramName)
            : base(paramName, "No criteria were applied. At least one property or condition must be set to evaluate the criteria. " +
                              "Please ensure that at least one filtering criterion or sort condition is defined before executing the query.")
        {
        }

        public CriteriaPropertiesAreNullException(string? message, Exception? innerException)
            : base(message, innerException)
        {
        }

        public CriteriaPropertiesAreNullException(string? paramName, string? message)
            : base(paramName, message)
        {
        }

        protected CriteriaPropertiesAreNullException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}