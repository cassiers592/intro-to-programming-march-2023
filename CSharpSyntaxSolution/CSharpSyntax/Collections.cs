﻿
namespace CSharpSyntax;

public class Collections
{
    [Fact]
    public void UsingAGenericList()
    {
        //generics change there form based on a type parameter
        // "Parametric Polymorphism"
        var favoriteNumbers = new List<int>();
        favoriteNumbers.Add(592);
        favoriteNumbers.Add(967);
        favoriteNumbers.Add(31105);

        Assert.Equal(592, favoriteNumbers[0]);

        Assert.Equal(3, favoriteNumbers.Count());
        Assert.Throws<ArgumentOutOfRangeException>(() => favoriteNumbers[4]);
        Assert.Contains(31105, favoriteNumbers);
    }

    [Fact]
    public void ListInitializers()
    {
        var favoriteNumbers = new List<int>
        {
            592,
            967,
            31105
        };

        Assert.Equal(3, favoriteNumbers.Count());
    }

    [Fact]
    public void EnumeratingAList()
    {
        var favoriteNumbers = new List<int>
        {
            592,
            967,
            31105
        };

        int total = 0;
        for(var x = 0; x < favoriteNumbers.Count; x++)
        {
            total += favoriteNumbers[x];
        }

        int sum = 0;
        foreach(var num in favoriteNumbers)
        {
            sum += num;
        }

        Assert.Equal(total, sum);
    }

    [Fact]
    public void DoingThingsWithPeople()
    {
        var bob = new Employee();
        bob.Name = "Robert";
        bob.Salary = 82_000M;

        var jeff = new Contractor()
        {
            Name = "Jeffry",
            HourlyRate = 28.85M
        };

        var workers = new List<Worker>
        {
            bob,
            jeff
        };
        foreach(var person in workers)
        {
            person.GetPay();
        }
    }
}

public abstract class Worker
{
    public string Name { get; set; } = string.Empty;
    public abstract decimal GetPay();
}
public class Employee : Worker
{
    public decimal Salary { get; set; }

    public override decimal GetPay()
    {
        return Salary;
    }
}

public class Contractor : Worker
{
    public decimal HourlyRate { get; set; }

    public override decimal GetPay()
    {
        return HourlyRate;
    }
}