namespace utils
{
    public static class InputValidator
    {
        public static bool IsSecretCode(string input)
        {
            return input.Length >=1 && input.Length <15 && input.All(c => char.IsLetterOrDigit(c));
        }
    }

}
