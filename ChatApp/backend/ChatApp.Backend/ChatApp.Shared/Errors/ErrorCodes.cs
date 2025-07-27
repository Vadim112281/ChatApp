namespace ChatApp.Shared.Errors;

public static class ErrorCodes
{
    public static readonly ErrorItem EmailAlreadyExists =
        new("EmailAlreadyExists", "User with this email already exists");
    
    public static readonly ErrorItem UserNameAlreadyExists = 
        new("UserNameAlreadyExists", "Userwith this username already exists");

    public static readonly ErrorItem UserNotFound =
        new("UserNotFound", "User not found");

    public static readonly ErrorItem InvalidCredentials =
        new("InvalidCredentials", "Invalid credentials");

    public static  ErrorItem Unexpected (string message) =>
        new("Unexpected", message);
}