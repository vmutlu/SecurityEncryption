using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SecurityEncryption.Tests
{
    public class AesCipherAlgorithmaTest
    {
        [SetUp]
        public void Setup()
        { }

        [Test]
        public void AesCipher_Encryption_Test()
        {
            var encryption = AesCipher.AESEncrypt("VeyselMUTLU");
            var descryption = AesCipher.AESDecrypt(encryption);

            Assert.AreEqual("VeyselMUTLU", descryption);
        }
    }
}
