namespace Excellence.Randomizers.Constants
{
    /// <summary>
    /// The messages.
    /// </summary>
    public static class Messages
    {
        public const string ConfigurationWithIndex = "Configuration[{0}]";
        public static readonly string NewLineWithIndent = $"{Environment.NewLine}    ";

        /// <summary>
        /// The error messages.
        /// </summary>
        public static class Errors
        {
            public const string Null = "{0} cannot be null.";
            public const string LessThanZero = "{0} cannot be less than 0.";
            public const string GreaterThan = "{0} cannot be greater than {1}.";
            public const string NoEnoughItems = "{0} cannot be empty when {1} is greater than 0.";
            public const string NoEnoughUniqueItems = "{0} should contain at least {1} unique entries.";
        }
    }
}
