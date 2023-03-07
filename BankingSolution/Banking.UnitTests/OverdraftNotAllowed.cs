using Banking.Domain;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        // When
        try
        {
            account.Withdraw(openingBalance + 0.01M);

        }
        catch (OverdraftException)
        {
            // Ignore this...
        }

        // Then
        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void OverdraftThrowsException()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        // Then
        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(openingBalance + 0.01M);
        });
    }
}
