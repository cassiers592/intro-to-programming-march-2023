namespace StringCalculator;

public class LoggingException : Exception
{
    public LoggingException() { }
    public LoggingException(string message): base(message)
    {

    }
}