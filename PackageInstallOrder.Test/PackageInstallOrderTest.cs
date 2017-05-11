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
        [ExpectedException(typeof(PackageRejectedException), "An invalid package was inappropriately allowed")]
        public void TestMethod3()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string[] input =
            {
                "KittenService: ",
                "Leetmeme: Cyberportal",
                "Cyberportal: Ice",
                "CamelCaser: KittenService",
                "Fraudstream: ",
                "Ice: Leetmeme"
            };

            packageInstaller.VerifyPackageDependency(input);
        }

        [TestMethod]
        [ExpectedException(typeof(PackageRejectedException), "An invalid package was inappropriately allowed")]
        public void TestMethod4()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string[] input =
            {
                "KittenService: Leetmeme",
                "Leetmeme: KittenService",
            };

            packageInstaller.VerifyPackageDependency(input);
        }

        [TestMethod]
        [ExpectedException(typeof(PackageRejectedException), "An invalid package was inappropriately allowed")]
        public void TestMethod5()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string[] input =
            {
                "Leetmeme: Cyberportal",
                "KittenService: ",
                "Ice: Leetmeme",
                "CamelCaser: KittenService",
                "Fraudstream: ",
                "Cyberportal: Ice"

            };

            packageInstaller.VerifyPackageDependency(input);
        }

        [TestMethod]
        [ExpectedException(typeof(PackageRejectedException), "An invalid package was inappropriately allowed")]
        public void TestMethod6()
        {
            PackageInstaller packageInstaller = new PackageInstaller();

            string[] input =
            {
                "Leetmeme: Cyberportal",
                "KittenService: Ice ",
                "Ice: Leetmeme",
                "CandyPanda: CranberryPie",
                "CamelCaser: KittenService",
                "Fraudstream: CyberPortal",
                "CranberryPie: Leetmeme",
                "Cyberportal: Ice",
                "AppleSauce: CherryPie",
                "Holdup: DontStop",
                "Computer: GraphicsCard",
                "GraphicsCard: HoldUp",
                "DontStop: AppleSauce",
                "CherryPie: CranberryPie",

            };

            packageInstaller.VerifyPackageDependency(input);
        }

        [TestMethod]
        public void TestMethod7()
        {

        }
    }
}
