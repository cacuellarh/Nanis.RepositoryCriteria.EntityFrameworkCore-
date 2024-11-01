using System.Runtime.Serialization;

namespace Nanis.Repository.Exception
{
    public class EntityNullException : ArgumentNullException
    {
        public EntityNullException() :base("The entity entered cannot be null")
        {
        }

        public EntityNullException(string? paramName) : base(paramName)
        {
        }

        public EntityNullException(string? message, System.Exception? innerException) : base(message, innerException)
        {
        }

        public EntityNullException(string? paramName, string? message) : base(paramName, message)
        {
        }

        protected EntityNullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
