using System;

namespace BusinessImplementationZone.Extenders
{
    public static class StringExtenders
    {
        public static bool SimplePalindromeCheck(this string input)
        {
            if (input == null)
                return false;

            input = input.ToLower();
            for (int i = 0; i < Math.Ceiling(((double)input.Length)/2); i++)
            {
                if (input[i] != input[(input.Length-1) - i])
                    return false;
            }
            return true;
        }
    }
}
