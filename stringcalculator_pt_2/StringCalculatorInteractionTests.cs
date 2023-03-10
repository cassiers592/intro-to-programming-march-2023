
namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Theory]
    [InlineData("1,2,3", "6")]
    [InlineData("42", "42")]
    [InlineData("", "0")]
    public void ResultsAreLogged(string numbers, string expected)
    {
        // Given
        var mockedLogger = new Mock<ILogger>(); // "Spy"
        var calculator = new StringCalculator(mockedLogger.Object);

        // When
        calculator.Add(numbers);

        // Then
        // Did the calculator call the Write method on the logger with the value "6"
        mockedLogger.Verify(m => m.Write(expected), Times.Once);
    }
}
