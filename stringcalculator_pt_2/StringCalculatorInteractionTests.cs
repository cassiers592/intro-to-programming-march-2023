
namespace StringCalculator;

public class StringCalculatorInteractionTests
{
    [Fact]
    public void ResultsAreLogged()
    {
        // Given
        var calculator = new StringCalculator();

        // When
        calculator.Add("1,2,3");

        // Then
        // Did the calculator call the Write method on the logger with the value "6"
    }
}
