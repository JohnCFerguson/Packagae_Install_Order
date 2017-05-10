using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PackageInstallOrder.Properties;

namespace PackageInstallOrder.Test
{
    [TestClass]
    public class PackageInstallOrderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string[] packages = { "KittenService: CamelCaser", "CamelCaser: " };

            string expectedResult = "CamelCaser, KittenService";

            string result = packageInstaller.GetPackageOrder(packages);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
