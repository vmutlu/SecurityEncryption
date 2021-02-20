using NUnit.Framework;

namespace SecurityEncryption.Tests
{
    public class Md5CipherAlgorithmaTest
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void Md5Cipher_Encryption_Test()
        {
            var encryption = Md5Cipher.Encryption("VeyselMUTLU");

            Assert.AreEqual("8533488b2ce8d362b44ed19f29fe2480", encryption); // Resource https://wmaraci.com/md5-sha1-sifre-olusturucu
        }
    }
}
