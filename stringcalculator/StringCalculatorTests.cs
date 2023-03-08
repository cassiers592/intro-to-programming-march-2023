
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("4", 4)]
    [InlineData("5", 5)]
    [InlineData("1234", 1234)]
    public void SingleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2,3", 5)]
    [InlineData("4,5", 9)]
    [InlineData("12,340", 352)]
    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2,3,4,5", 14)]
    [InlineData("12,340,1", 353)]
    public void ManyDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("2\n3,4\n5", 14)]
    [InlineData("12\n340\n1", 353)]
    public void NewLineSplitter(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//x\n12\n340x1", 353)]
    public void DifferentDelimiters(string numbers, int expected)
    {
        var calculator = new StringCalculator();

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }
}