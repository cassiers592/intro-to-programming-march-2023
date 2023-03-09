
using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

namespace Banking.UnitTests;

public class BankAccountUsesBonusCalculator
{
    [Fact()]
    public void IntegratesWithBonusCalculator()
    {
        var bankAccount = new BankAccount(new StubbedBonusCalculator());

        bankAccount.Deposit(212.83M);

        Assert.Equal(5000M + 212.83M + 12M, bankAccount.GetBalance());
    }

    [Fact]
    public void IntegratesWithBonusCalculatorWithStubbedObject()
    {
        // Given
        var stubbedBonusCalculator = new Mock<ICalculateBonuses>(); // programmable object that looked like it can calculate bonuses
        var bankAccount = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = bankAccount.GetBalance();
        var amountOfDeposit = 212.83M;

        stubbedBonusCalculator.Setup(x => x.CalculateBankAccountDepositBonusFor(openingBalance, amountOfDeposit)).Returns(12M);

        // When
        bankAccount.Deposit(amountOfDeposit);

        // Then
        Assert.Equal(openingBalance + amountOfDeposit + 12M, bankAccount.GetBalance());
    }
}
