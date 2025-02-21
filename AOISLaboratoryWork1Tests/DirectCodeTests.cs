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
        for (int i = -10000; i <= 10000; i++)
        {
            Assert.AreEqual(DirectCode.ConvertDirectCodeToInteger(DirectCode.ConvertIntegerToDirectCode(i)), i);
        }
    }

    [TestMethod]
    public void MultiplicationTest()
    {
        Assert.AreEqual(DirectCode.Multiplication("10001010", "10001010"), "01100100");
        
        for (int i = -100; i <= 100; i++)
        {
            for (int j = -100; j <= 100; j++)
            {
                Assert.AreEqual(DirectCode.ConvertDirectCodeToInteger(DirectCode.Multiplication(i, j)), i * j);
            }
        }
    }

    [TestMethod]
    public void FindDigitsNumberTest()
    {
        Assert.AreEqual(DirectCode.FindDigitsNumber(100), 3);
        Assert.AreEqual(DirectCode.FindDigitsNumber(1), 1);
        Assert.AreEqual(DirectCode.FindDigitsNumber(567), 3);
        Assert.AreEqual(DirectCode.FindDigitsNumber(4444), 4);
    }

    [TestMethod]
    public void DivisionTest()
    {
        double result = DirectCode.Division(1101, 10);
    }
}