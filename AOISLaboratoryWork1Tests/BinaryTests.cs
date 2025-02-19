using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

[TestClass]
public sealed class BinaryTests
{
    [TestMethod]
    public void BinaryFromUnsignedIntTest()
    {
        Assert.AreEqual("111", Binary.FromUnsignedInt(7));
        Assert.AreEqual("10011100", Binary.FromUnsignedInt(156));
        Assert.AreEqual("10000000000", Binary.FromUnsignedInt(1024));
        Assert.AreEqual("111011110", Binary.FromUnsignedInt(478));
        Assert.AreEqual("111000", Binary.FromUnsignedInt(56));
    }
}