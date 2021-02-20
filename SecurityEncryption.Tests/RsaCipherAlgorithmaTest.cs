using NUnit.Framework;

namespace SecurityEncryption.Tests
{
    public class RsaCipherAlgorithmaTest
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void RsaCipherCipher_Encryption_Test()
        {
            var rsaKey = RsaCipher.GetKey();
            var encrypt = RsaCipher.Encrypt("VeyselMUTLU", rsaKey["PublicKey"]);

            var decrypt = RsaCipher.Decrypt(encrypt, rsaKey["PrivateKey"]);

            Assert.AreEqual("VeyselMUTLU", decrypt);
        }
    }
}
