using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Blog.Bussiness;
using Blog.Bussiness.Methods;


namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var pass = "1234";
            var dnm1 = Crypts.Encrypt(pass);
            var dnm2 = Crypts.Decrypt(dnm1);
            

            Assert.AreEqual(pass,dnm2);
        }
    }
}
