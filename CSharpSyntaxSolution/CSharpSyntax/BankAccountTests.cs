
namespace CSharpSyntax;

public class BankAccountTests
{
    [Fact]
    public void GettingMyAccount()
    {
        var service = new AccountManager();
        var myAccount = service.GetAccountByID("93939");

        Assert.Equal("93939", myAccount.GetAccountNumber());

        Assert.Equal("Jeff", myAccount.FirstName);

        myAccount.FirstName = "Jeffry";

        Assert.Equal("Jeffry", myAccount.FirstName);

    }

    [Fact]
    public void WorkingWithTransactions()
    {
        var transaction = new BankTransaction
        {
            TransactionType = TransactionType.Deposit,
            Amount = 5000
        };

        // send it to the bank

        var transaction2 = new BankTransaction
        {
            TransactionType = TransactionType.Deposit,
            Amount = 5000
        };

        Assert.Equal(transaction, transaction2);

        var transaction3 = transaction with { Amount = 1000, Note = transaction.Note + "Work" };
    }

    [Fact]
    public void SongExample()
    {
        var song1 = new Song("ABCs", "Unknown", "Unknown");
        var song2 = new Song2
        {
            Title = "Twinkle Twinkle",
            Artist = "Unknown",
            Album = "Unknown"
        };
    }
}
