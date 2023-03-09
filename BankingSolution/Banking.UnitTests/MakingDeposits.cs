using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class MakingDeposits
{
    [Theory]
    [InlineData(100)]
    [InlineData(1.25)]
    public void DepositIncreasesTheBalance(decimal amountToDeposit)
    {
        // Given
        var account = new BankAccount(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();

        // When
        account.Deposit(amountToDeposit);

        // Then
        Assert.Equal(openingBalance + amountToDeposit, account.GetBalance()); 
    }
}
