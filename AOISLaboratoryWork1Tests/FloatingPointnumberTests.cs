using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

[TestClass]
public class FloatingPointnumberTests
{
    [TestMethod]
    public void FloatingPointNumberConvertTest()
    {
        FloatingPointNumber floatingPointNumber = new(85.125);
        //Assert.AreEqual(floatingPointNumber.ToString(), "00111111100000000000000000000000");
        floatingPointNumber = new(11.724728);
        Assert.AreEqual(floatingPointNumber.ToString(), "00111111100000000000000000000000");
    }
}