using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class MakingWithdrawls
{
    [Theory]
    [InlineData(1)]
    [InlineData(1020.22)]
    [InlineData(5000)]
    public void MakingAWithdrawlDecreasesBalance(decimal amountToWithdraw)
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
