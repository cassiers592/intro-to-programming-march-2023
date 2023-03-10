
namespace StringCalculator;

public class StringCalculatorTests
{
    private readonly StringCalculator _calculator;

    public StringCalculatorTests()
    {
        _calculator = new StringCalculator();
    }

    [Fact]
    public void EmptyStringReturnsZero()
    {
        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("42", 42)]
    public void SingleNumber(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    [InlineData("108\n1", 109)]
    [InlineData("1\n2,3", 6)]
    public void AllTheRest(string numbers, int expected)
    {
        var result = _calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}
