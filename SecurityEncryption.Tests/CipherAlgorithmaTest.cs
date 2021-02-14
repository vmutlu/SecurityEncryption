using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SecurityEncryption.Tests
{
    public class CipherAlgorithmaTest
    {

        [SetUp]
        public void Setup()
        { }

        [Test]
        public void DesCipher_Encryption_Test()
        {
            var encryption = DesCipher.Encryption("VeyselMUTLU");
            var descryption = DesCipher.Descryption(encryption);

            Assert.AreEqual("VeyselMUTLU", descryption);
        }

    }
}
