using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PackageInstallOrder
{
    public class PackageInstaller
    {
        public string VerifyPackageDependency(string[] input)
        {
            string packageDependencyOrder = "";
            int packageCount = 0;
            int numPackages = input.Length;

            //check for packages without dependencies
            for (int i = 0; i < input.Length; i++)
            {
                char[] tempCharArr = input[i].ToCharArray();

                //if a dependency does not exist, add it to the dependency order string
                if (getDependency(input[i]).Equals("No dependency"))
                {
                    packageDependencyOrder += addNoDependencies(input[i]);

                    packageCount++;
                }
            }

            //check for packages with dependencies
            for (int i = 0; i < input.Length; i++)
            {
                char[] tempCharArr = input[i].ToCharArray();

                Debug.WriteLine("input " + i + " contains dependency: " + containsDependency(packageDependencyOrder, getDependency(input[i])));
                Debug.WriteLine("input " + i + " dependency is: " + getDependency(input[i]));
                Debug.WriteLine("packgedependencyorder contains dependency: " + packageDependencyOrder.Contains(addWithDependencies(input[i])));

                //if the dependency order string contains the dependency for the current package AND does not already contain the current package, add it to the string
                //reset to zero to ensure all packages are checked 
                if (containsDependency(packageDependencyOrder, getDependency(input[i])) && !packageDependencyOrder.Contains(addWithDependencies(input[i])))
                {
                    //Debug.WriteLine(containsDependency(packageDependencyOrder, getDependency(input[i])));
                    //Debug.WriteLine("Adding " + addWithDependencies(input[i]) + " to dependency order string");

                    packageDependencyOrder += addWithDependencies(input[i]);

                    i = 0;
                    packageCount++;
                }
            }

            //if a dependency loop is present, not all of the packages would be added to the order string, if the number of packes added to the string does not equal the number of packages, inform that there is an invalid input in the packages

            //Debug.WriteLine("package count is: " + packageCount + " number of packages is: " + numPackages);
            if (packageCount != numPackages)
            {
                packageDependencyOrder = "Invalid Input Packages: Package contains a cycle";
            }

            if (!packageDependencyOrder.Equals("Invalid Input Packages: Package contains a cycle"))
            {
                packageDependencyOrder = packageDependencyOrder.Substring(0, packageDependencyOrder.Length - 2);
            }


            return packageDependencyOrder;
        }

        private string addNoDependencies(string tempPackage)
        {
            string noDependency = "";

            //Debug.WriteLine("Temp Char Arr Length: " + tempCharArr.Length);
            int j = 0;
            while (tempPackage[j] != ':')
            {
                j++;
            }
            j++;
            //Debug.WriteLine(j + 2);

            //checks if there is a dependency present, if not add, it will add the
            if (j + 2 > tempPackage.Length)
            {
                //Debug.WriteLine("J + 2 > " + tempCharArr.Length);
                j = 0;
                while (tempPackage[j] != ':')
                {
                    noDependency += tempPackage[j];
                    j++;
                }
                noDependency += ", ";
            }

            return noDependency;
        }

        private string addWithDependencies(string tempPackage)
        {
            string package = "";

            int j = 0;
            while (tempPackage[j] != ':')
            {
                package += tempPackage[j];
                j++;
            }

            package += ", ";

            return package;
        }

        private string getDependency(string tempPackage)
        {
            string dependency = "";

            //Debug.WriteLine("getting dependency for: " + tempPackage);

            int j = 0;
            while (tempPackage[j] != ':')
            {
                j++;
            }
            j++;

            if (j + 1 < tempPackage.Length)
            {
                j++;
                //Debug.WriteLine("Dependency starts with " + tempPackage[j]);
                while (j < tempPackage.Length)
                {
                    dependency += tempPackage[j];
                    j++;
                }
            }
            else
            {
                dependency = "No dependency";
            }

            //Debug.WriteLine(dependency);

            return dependency;
        }

        private bool containsDependency(string dependencyOrder, string dependency)
        {
            bool contains;

            if (dependencyOrder.Contains(dependency))
            {
                contains = true;
            }
            else
            {
                contains = false;
            }

            return contains;
        }
    }
}
