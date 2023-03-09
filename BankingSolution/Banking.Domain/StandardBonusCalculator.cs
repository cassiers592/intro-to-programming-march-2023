namespace Banking.Domain;

public class StandardBonusCalculator
{

    public decimal CalculateBankAccountDepositBonusFor(decimal accountCurrentBalance, decimal amountOfDeposit)
    {
        return accountCurrentBalance >= 5000M ? amountOfDeposit * 0.10M : 0;
    }
}