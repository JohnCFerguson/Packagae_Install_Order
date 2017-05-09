using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PackageInstallOrder.Test
{
    [TestClass]
    public class PackageInstallOrderTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            PackageInstallOrder packageInstallOrder = new PackageInstallOrder();

            string[] packages = { "KittenService: CamelCaser", "CamelCaser: " };

            string expectedResult = "CamelCaser, KittenService";

            string result = packageInstallOrder.GetPackageOrder(packages);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
