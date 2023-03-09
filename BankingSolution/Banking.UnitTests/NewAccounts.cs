using Banking.Domain;
using Banking.UnitTests.TestDoubles;
using Moq;

namespace Banking.UnitTests;

public class NewAccounts
{
    [Fact]
    public void NewAccountHasCorrectOpeiningBalance()
    {
        // Given
        BankAccount account = new BankAccount(new Mock<ICalculateBonuses>().Object);

        // When
        decimal balance = account.GetBalance();

        // Then
        Assert.Equal(5000, balance);
    }
}
