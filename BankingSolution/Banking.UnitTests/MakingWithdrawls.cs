using Banking.Domain;

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
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        // When
        account.Withdraw(amountToWithdraw);

        // Then
        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }
}
