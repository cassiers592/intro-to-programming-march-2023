
using Banking.Domain;

namespace Banking.UnitTests;

public class GoldCustomerDeposits
{
    [Fact]
    public void GoldCustomerGetsABonusOnDeposits()
    {
        var account = new GoldBankAccount();
        var amountToDeposit = 100M;
        var openingBalance = account.GetBalance();

        account.Deposit(amountToDeposit);

        Assert.Equal(amountToDeposit + 10M + openingBalance, account.GetBalance());
    }
}
