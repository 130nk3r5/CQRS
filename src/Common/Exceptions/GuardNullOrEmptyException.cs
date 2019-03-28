using System;

namespace Common.Exceptions
{
    public class GuardNullOrEmptyException : Exception
    {
        public GuardNullOrEmptyException(string argumentName)
            : base($"The provided argument {argumentName} is not allowed to be null or empty")
        {

        }
    }
}
