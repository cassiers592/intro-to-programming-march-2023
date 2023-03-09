using Banking.Domain;

namespace Banking.UnitTests.BonusCalculations;

public class AdvancedBonusCalculatorTests
{
    // Deposits that meet the criteria get a bonus
    // Deposits that do not meet the criteria do not get a bonus
    //[Theory]
    //public void DepositsGetBonusBasedOnBalance(decimal balance, decimal amount, decimal expectedBonus, DateTimeOffset when)
    //{
    //    var bonusCalculator = new AdvancedBonusCalculator();

    //    decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(balance, amount);

    //    Assert.Equal(expectedBonus, bonus);
    //}

    [Fact]
    public void DepositsGetBonusBasedOnBalance()
    {
        // Given
        var bonusCalculator = new AdvancedBonusCalculator();
        // When
        decimal bonus = bonusCalculator.CalculateBankAccountDepositBonusFor(1000M, 10);
        // Then
        Assert.Equal(.0M, bonus);
    }
}
