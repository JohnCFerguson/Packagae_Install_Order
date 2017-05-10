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

            string expectedResult = "CamelCaser, KittenService";

            string[] input = { "KittenService: CamelCaser", "CamelCaser: " };

            string result = packageInstaller.VerifyPackageDependency(input);

            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void TestMethod2()
        {
            PackageInstaller packageInstaller = new PackageInstaller();
            string expectedResult = "KittenService, Ice, Cyberportal, Leetmeme, CamelCaser, Fraudstream";

            string[] input =
            {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: Leetmeme",
                "Ice: "
            };

            string result = packageInstaller.VerifyPackageDependency(input);

            Assert.AreEqual(expectedResult, result);

        }

        [TestMethod]
        public void TestMethod3()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string expectedResult = "Invalid Input Packages: Package contains a cycle";

            string[] input =
            {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: ",
                "Ice: Leetmeme"
            };

            string result = packageInstaller.VerifyPackageDependency(input);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
