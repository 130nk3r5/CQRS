using System;

namespace Common.Exceptions
{
    public class GuardNullException : Exception
    {
        public GuardNullException(string argumentName)
            : base($"The provided argument {argumentName} is not allowed to be null")
        {

        }
    }
}
