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
    }
}