using Common.Exceptions;

namespace Common.Guards
{
    public static class Guard
    {
        public static void AgainstNull(object argument, string name)
        {
            if (argument == null)
            {
                throw new GuardNullException(name);
            }
        }

        public static void AgainstNullOrEmpty(string argument, string name)
        {
            if (string.IsNullOrEmpty(argument))
            {
                throw new GuardNullOrEmptyException(name);
            }
        }
    }
}
