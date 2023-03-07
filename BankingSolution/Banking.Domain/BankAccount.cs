namespace Banking.Domain;

public class BankAccount
{
    private decimal _balance = 5000;

    public void Deposit(decimal amountToDeposit)
    {
        _balance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _balance;
    }
}