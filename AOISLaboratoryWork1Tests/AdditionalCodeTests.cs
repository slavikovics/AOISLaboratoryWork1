using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

[TestClass]
public sealed class AdditionalCodeTests
{
    [TestMethod]
    public void ConvertIntegerToAdditionalCodeTest()
    {
        Assert.AreEqual(AdditionalCode.ConvertIntegerToAdditionalCode(123), "01111011");
        Assert.AreEqual(AdditionalCode.ConvertIntegerToAdditionalCode(-123), "10000101");
        Assert.AreEqual(AdditionalCode.ConvertIntegerToAdditionalCode(4563), "01000111010011");
        Assert.AreEqual(AdditionalCode.ConvertIntegerToAdditionalCode(-4563), "1110111000101101");
    }
}