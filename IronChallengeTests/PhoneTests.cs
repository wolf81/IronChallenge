using IronChallenge;

namespace IronChallengeTests;

[TestClass]
public class PhoneTests
{
    [TestMethod]
    [ExpectedException(typeof(FormatException), "Input string required")]
    public void TestEmptyInputExceptionThrown()
    {
        Phone.OldPhonePad(string.Empty);
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException), "Input string should be terminated by a hash (#)")]
    public void TestInvalidInputExceptionThrown()
    {
        Phone.OldPhonePad("1221");
    }

    [TestMethod]
    [ExpectedException(typeof(FormatException), "Input string contains invalid characters")]
    public void TestInvalidCharactersExceptionThrown()
    {
        Phone.OldPhonePad("ab132#");
    }

    [TestMethod]
    public void TestKeyNextLetter()
    {
        Assert.IsTrue(Phone.OldPhonePad("33#").Equals("E"));
    }

    [TestMethod]
    public void TestBackspace()
    {
        Assert.IsTrue(Phone.OldPhonePad("227*#").Equals("B"));
    }

    [TestMethod]
    public void TestBackspaceMulti()
    {
        Assert.IsTrue(Phone.OldPhonePad("227*227**11#").Equals("B'"));
    }

    [TestMethod]
    public void TestHello()
    {
        Assert.IsTrue(Phone.OldPhonePad("4433555 555666#").Equals("HELLO"));
    }

    [TestMethod]
    public void TestTuring()
    {
        Assert.IsTrue(Phone.OldPhonePad("8 88777444666*664#").Equals("TURING"));
    }
}
