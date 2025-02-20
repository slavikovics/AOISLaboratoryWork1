using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

[TestClass]
public sealed class DirectCodeTests
{
    [TestMethod]
    public void ConvertIntegerToDirectCodeTest()
    {
        Assert.AreEqual(DirectCode.ConvertIntegerToDirectCode(45), "0101101");
        Assert.AreEqual(DirectCode.ConvertIntegerToDirectCode(127), "01111111");
        Assert.AreEqual(DirectCode.ConvertIntegerToDirectCode(1024), "010000000000");
        Assert.AreEqual(DirectCode.ConvertIntegerToDirectCode(950), "01110110110");
    }

    [TestMethod]
    public void ConvertDirectCodeToIntegerTest()
    {
        
    }
}