using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Blog.Bussiness;
using Blog.Key;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var password = "1234";
            var hash = Methods.AesEncrypt(Keys.AesKey(),password);
            var dehash = Methods.DecryptString(Keys.AesKey(), hash);

            Assert.AreEqual(password,dehash);


        }
    }
}
