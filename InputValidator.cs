namespace GeoCodingApp.Utilities
{
    public static class InputValidator
    {
        public static bool IsValidLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return false;

            if (location.Length < 2)
                return false;

            return true;
        }
    }
}