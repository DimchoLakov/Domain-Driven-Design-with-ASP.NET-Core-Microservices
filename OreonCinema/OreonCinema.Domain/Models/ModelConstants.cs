namespace OreonCinema.Domain
{
    public class ModelConstants
    {
        public class Common
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 20;
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MaxUrlLength = 2048;
            public const int Zero = 0;
        }

        public class Address
        {
            public const int MinAddressLineLength = 2;
            public const int MaxAddressLineLength = 64;
            public const int MinTownLength = 2;
            public const int MaxTownLength = 64;
            public const int MinPostCodeLength = 4;
            public const int MaxPostCodeLength = 64;
            public const int MinCountryLength = 4;
            public const int MaxCountryLength = 64;
        }

        public class Movie
        {
            public const int MinTitleLength = 1;
            public const int MaxTitleLength = 128;
            public const int MinRating = 1;
            public const int MaxRating = 5;
            public const int MinReleaseYear = 1930;
            public const int MinReleaseMonth = 1;
            public const int MinReleaseDay = 1;
            public const int MaxReleaseYear = 3000;
            public const int MaxReleaseMonth = 1;
            public const int MaxReleaseDay = 1;
        }

        public class Cinema
        {
            public const int MinNameLength = 2;
            public const int MaxNameLength = 128;
            public const string PhoneRegexPattern = @"^(\+)?([ 0-9]){6,16}$";
        }

        public class Payment
        {
            public const decimal MinAmount = 0.01m;
            public const decimal MaxAmount = 100m;
        }

        public class Seat
        {
            public const string RowLetterRegexPattern = "[A-Z]{1}";
            public const int MinRowNumber = 1;
            public const int MaxRowNumber = 30;
        }
    }
}
