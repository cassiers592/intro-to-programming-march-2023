
namespace StringCalculator;

public class StringCalculator
{

    public int Add(string numbers)
    {
        if (numbers == "") return 0;
        //var delimeter = ',';
        var delimeters = new List<char> { ',', '\n' };
        if (numbers.StartsWith("//"))
        {
            //delimeter = numbers[2];
            delimeters.Add(numbers[2]);
            numbers = numbers.Substring(4);
        }
        //numbers = numbers.Replace('\n', delimeter);
        var sum = 0;
        //var numberList = numbers.Split(delimeter);
        var numberList = numbers.Split(delimeters.ToArray());

        foreach (var number in numberList)
        {
            sum += int.Parse(number);
        }
        return sum; 

        // OR
        //return numberList.Select(int.Parse).Sum();
    }
}
