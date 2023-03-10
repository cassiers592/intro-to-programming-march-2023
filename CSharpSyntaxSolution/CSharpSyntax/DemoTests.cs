namespace CSharpSyntax;
// with the semicolon everythin in this file is in that namespace

// test classes have to be public
public class DemoTests
{
    [Fact] // Attribute (Decorator) (like @Fact in JS)
    public void Test1()
    {
        // Given
        // set up
            int a = 10, b = 20;
            int answer;
        // When
        // the actual test - do something
            answer = a + b;
        // Then
            // observe the result - did it work as expected
            Assert.Equal(30, answer);
    }

    [Theory]
    [InlineData(10, 20, 30)]
    [InlineData(2, 2, 4)]
    [InlineData(10, 2, 12)]
    public void CanAddAnyTwoIntegers(int a, int b, int expected)
    {
        int answer = a + b;
        Assert.Equal(expected, answer);
    }

    [Fact]
    public void CustomerTest()
    {
        Customer bob = new Customer();

        Assert.Equal(5000, bob.GetCurrentAvailableCredit());
        bob.IncreaseAvailableCredit(50);
        Assert.Equal(5050, bob.GetCurrentAvailableCredit());
    }
}