
namespace CSharpSyntax;

public class WorkingWithMethods
{
    [Fact]
    public void WorkingWithStuff()
    {
        var o1 = new Stuff();
        o1.DoIt();

        var o2 = new Stuff();
        o2.DoIt();

        Assert.Equal(19, o1.GetX());
        Assert.Equal(19, o2.GetX());

        o2.DoIt();
        o2.DoIt();

        Assert.Equal(19, o1.GetX());
        Assert.Equal(17, o2.GetX());
    }
}
