namespace Microservice.Food.Extensions;

public static class ValidationExtensions
{
    public static bool IsValidEmail(this string email)
    {
        var index = email.IndexOf('@');

        return
            index > 0 &&
            index != email.Length - 1 &&
            index == email.LastIndexOf('@');
    }
}