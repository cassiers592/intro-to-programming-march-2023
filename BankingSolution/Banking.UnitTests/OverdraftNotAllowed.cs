using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
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
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        // Then
        Assert.Throws<OverdraftException>(() =>
        {
            account.Withdraw(openingBalance + 0.01M);
        });
    }
}
