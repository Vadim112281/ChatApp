namespace ChatApp.Shared.Errors;

public class ErrorItem
{
    public ErrorItem(string code, string message)
    {
        Code = code;
        Message = message;
    }
    
    public string Code { get; set; }
    public string Message { get; set; }
    
    public static ErrorItem Create(string code, string message) => new(code, message);
    
    
}