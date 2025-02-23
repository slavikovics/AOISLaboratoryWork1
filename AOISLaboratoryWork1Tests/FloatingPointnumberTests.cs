using AOISLaboratoryWork1;

namespace AOISLaboratoryWork1Tests;

[TestClass]
public class FloatingPointnumberTests
{
    [TestMethod]
    public void FloatingPointNumberConvertTest()
    {
        FloatingPointNumber floatingPointNumber = new(85.125);
        Assert.AreEqual(floatingPointNumber.ToString(), "01000010101010100100000000000000");
        floatingPointNumber = new(11.724728);
        Assert.AreEqual(floatingPointNumber.ToString(), "01000001001110111001100001111100");
        floatingPointNumber = new(99.645283675);
        Assert.AreEqual(floatingPointNumber.ToString(), "01000010110001110100101001100011");
        floatingPointNumber = new(435675.9393325423);
        Assert.AreEqual(floatingPointNumber.ToString(), "01001000110101001011101101111110");
        floatingPointNumber = new(0.0000724728);
        Assert.AreEqual(floatingPointNumber.ToString(), "00111000100101111111110010001001");
        floatingPointNumber = new(-85.125);
        Assert.AreEqual(floatingPointNumber.ToString(), "11000010101010100100000000000000");
    }
}