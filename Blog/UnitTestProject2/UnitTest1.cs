using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Blog.Bussiness;
using Blog.Key;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pass = "1234";
            var dnm1 = Methods.Encrypt(pass,Keys.AesKey());
            var dnm2 = Methods.Decrypt(dnm1, Keys.AesKey());

            Assert.AreEqual(pass,dnm2);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var pass = "1234";
            var dnm1 = Methods.Encrypt(pass, Keys.AesKey());
            var dnm2 = Methods.Decrypt(dnm1, Keys.AesKey());

            Assert.AreEqual(pass, dnm2);
        }
    }
}
