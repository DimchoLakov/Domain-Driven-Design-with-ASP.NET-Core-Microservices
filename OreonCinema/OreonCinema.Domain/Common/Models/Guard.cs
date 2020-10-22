namespace OreonCinema.Domain.Common.Models
{
    using System;
    using System.Text.RegularExpressions;

    public static class Guard
    {
        private const int MaxUrlLength = 2048;

        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null or empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (url.Length <= MaxUrlLength && 
                Uri.IsWellFormedUriString(url, UriKind.Absolute))
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        public static void AgainstDateOverlap<TException>(DateTime startDate, DateTime endDate, string startDateName = "Value", string endDateName = "Value")
            where TException : BaseDomainException, new()
        {
            if (startDate < endDate)
            {
                return;
            }

            ThrowException<TException>($"{startDateName} must not be after {endDateName}.");
        }

        public static void AgainstDateOutOfRange<TException>(DateTime actualDateTime, DateTime minDateTime, DateTime maxDateTime, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (actualDateTime > minDateTime &&
                actualDateTime < maxDateTime)
            {
                return;
            }

            ThrowException<TException>($"{name} must be in range \"{minDateTime}\" and \"{maxDateTime}\".");
        }

        public static void ForRegex<TException>(string value, string pattern, string name = "Value")
            where TException : BaseDomainException, new()
        {
            var regex = new Regex(pattern);
            Match match = regex.Match(value);

            if (match.Success)
            {
                return;
            }

            ThrowException<TException>($"{name} does not match regex pattern \"{pattern}\".");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Error = message
            };

            throw exception;
        }
    }
}
