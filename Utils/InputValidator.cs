namespace utils
{
    public static class InputValidator
    {
        public static bool IsSecretCode(string input)
        {
            return input.Length == 8 && input.All(c => char.IsLetterOrDigit(c));
        }
    }

}
