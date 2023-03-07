
namespace CSharpSyntax;

public class Customer
{
    private decimal _availableCredit = 5000;
    /// <summary>
    /// Use this method to get the current available credit
    /// </summary>
    /// <returns>what the customer's credit is right now</returns>
    public decimal GetCurrentAvailableCredit()
    {
        return _availableCredit;
    }

    /// <summary>
    /// Use this method to increase the credit limit
    /// </summary>
    /// <param name="amount">The amount to add to the current credit limit</param>
    public void IncreaseAvailableCredit(decimal amount)
    {
        _availableCredit += amount;
    }
}
