
using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations;

public class BasicBonusCalculatorTests
{
    // Deposits that meet the criteria get a bonus
    // Deposits that do not meet the criteria do not get a bonus
    [Theory]
    [InlineData(5000, 100, 10)]
    [InlineData(5000, 200, 20)]
    [InlineData(4999.99, 100, 0)]
    public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus)
    {
        var bonusCalculator = new StandardBonusCalculator();

        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

        Assert.Equal(expectedBonus, bonus);
    }
}
