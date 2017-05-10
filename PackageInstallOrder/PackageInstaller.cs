using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstallOrder
{
    public class PackageInstaller
    {
        public string GetPackageOrder(string[] packages)
        {
            string installOrder = "";

            for(int i = 0; i < packages.Length; i++)
            {
                char[] tmpPackage = packages[i].ToCharArray();
                string tmpString = "";

                int j = 0;
                while (!tmpPackage[j].Equals(' '))
                {
                    j++;
                }
                j++;
                while (j < tmpPackage.Length)
                {
                    tmpString += tmpPackage[j];
                    j++;
                }
                installOrder += tmpString;
            }

            return installOrder;
        }
    }
}
