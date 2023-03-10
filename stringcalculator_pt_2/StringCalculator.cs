
namespace StringCalculator;

public class StringCalculator
{
    private readonly ILogger _logger;

    public StringCalculator(ILogger logger)
    {
        _logger = logger;
    }

    public int Add(string numbers)
    {
        // fewer number if "elements", low "cyclomatic complexity'
        int total = numbers == "" ? 0 : numbers.Split(',', '\n')
            .Select(int.Parse)
            .Sum(); 

        _logger.Write(total.ToString());
        return total;
    }
}

public interface ILogger
{
    void Write(string message);
}
