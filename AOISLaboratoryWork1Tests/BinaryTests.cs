using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

public class BinaryTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BinaryFromUnsignedIntTest()
    {
        Assert.Equals(Binary.FromUnsignedInt(7), "111");
    }
}