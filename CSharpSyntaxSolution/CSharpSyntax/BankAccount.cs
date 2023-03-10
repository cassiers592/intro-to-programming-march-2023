
namespace CSharpSyntax;

public class BankAccount
{
    private string _accountNumber = string.Empty;
    private string _firstName = string.Empty;
    public string LastName { get; private set; } = string.Empty;

    internal BankAccount(string accountNumber)
    {
        _accountNumber = accountNumber;
    }

    public string GetAccountNumber()
    {
        return _accountNumber;
    }

    //public string GetFirstName()
    //{
    //    return _firstName;
    //}

    //public void SetFirstName (string firstName)
    //{
    //    _firstName = firstName;
    //}

    // Properties
    public string FirstName
    {
        get { return _firstName; }
        set { _firstName = value; }
    }
}

// Class that just does some work for me
// Services
public class AccountManager
{
    public BankAccount GetAccountByID(string accountNumber)
    {
        // go find in the database
        var account = new BankAccount(accountNumber);
        account.FirstName = "Jeff";
        return account;
    }
}

public enum TransactionType { Deposit, Withdrawl, Fee}

// In order to compare you have to implement IEquatable
//public class BankTransaction
//{
//    public required TransactionType TransactionType { get; init; }
//    public required decimal Amount { get; init; }
//    public string Note { get; init; } = string.Empty;
//}

// records automatically implement IEquatable
public record BankTransaction
{
    public required TransactionType TransactionType { get; init; }
    public required decimal Amount { get; init; }
    public string Note { get; init; } = string.Empty;
}

public record Song(string Title, string Artist, string Album);
public record Song2
{
    public string Title { get; init; } = string.Empty;
    public string Artist { get; init; } = string.Empty;
    public string Album { get; init; } = string.Empty;
}
