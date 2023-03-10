
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
        var calculator = new StringCalculator(mockedLogger.Object, new Mock<IWebService>().Object);

        // When
        calculator.Add(numbers);

        // Then
        // Did the calculator call the Write method on the logger with the value "6"
        mockedLogger.Verify(m => m.Write(expected), Times.Once);
    }

    [Theory]
    [InlineData("1", "Logging Failed")]
    [InlineData("1,2", "Logging Failed")]
    [InlineData("2", "Boom!")]
    public void WebServiceIsNotifiedIfLoggerFails(string numbers, string expectedMessage)
    {
        // Scenario: When the logger fails, the web service is called
        // Given 
        var stubbedLogger = new Mock<ILogger>();
        stubbedLogger.Setup(logger => logger.Write(It.IsAny<string>())).Throws<LoggingException>(() =>
            new LoggingException(expectedMessage));
        var mockedWebService = new Mock<IWebService>();
        var calculator = new StringCalculator(stubbedLogger.Object, mockedWebService.Object);

        // When 
        calculator.Add(numbers);

        // Then 
        mockedWebService.Verify(w => w.LoggingFailed(expectedMessage), Times.Once);
    }
}
