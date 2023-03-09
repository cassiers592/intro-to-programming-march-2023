
using Banking.Domain;
using Banking.UnitTests.TestDoubles;

namespace Banking.UnitTests;

public class BankAccountUsesBonusCalculator
{
    [Fact]
    public void IntegratesBonusCalculator()
    {
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5224.83M, bankAccount.GetBalance());
    }
}
