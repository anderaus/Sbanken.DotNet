using System;

namespace Sbanken.DotNet.Helpers
{
    public static class Ensure
    {
        public static void NotNull(object value, string name)
        {
            if (value == null)
            {
                throw new ArgumentNullException(name);
            }
        }

        public static void NotNullOrEmpty(string value, string name)
        {
            NotNull(value, name);

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("String cannot be empty", name);
            }
        }

        internal static void EqualOrGreaterThan(decimal minimum, decimal value, string name)
        {
            if (value < minimum)
            {
                throw new ArgumentOutOfRangeException(name, nameof(name));
            }
        }
    }
}