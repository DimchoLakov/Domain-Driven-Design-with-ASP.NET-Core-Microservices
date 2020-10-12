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
    }
}
