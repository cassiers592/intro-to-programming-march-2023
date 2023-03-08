

namespace Banking.Domain;

// inheritance creates "is a" relationship
// gold bank account is a bank account
public class GoldBankAccount : BankAccount
{
    public override void Deposit(decimal amountToDeposit)
    {
        base.Deposit(amountToDeposit * 1.10M);
    }
}
