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
            string packageDependencyOrder = ""; //Will hold package order string to return
            string currPackage; //will hold current package in loops
            string dependency; //will hold current package dependency in loops

            int packageCount = 0; //Counts number of packages added to the packageDependencyOrder string, to ensure all packages are added
            int numPackages = input.Length; //length of string[] passed in, will be used to check against number of packages added to packageDependencyOrder string

            //check for packages without dependencies
            for (int i = 0; i < input.Length; i++)
            {
                currPackage = getCurrentPackage(input[i]);
                dependency = getDependency(input[i]);

                //if a dependency does not exist, add it to the dependency order string
                if (dependency.Equals("No dependency"))
                {
                    packageDependencyOrder += currPackage + ", ";

                    packageCount++;
                }
            }

            //check for packages with dependencies
            for (int i = 0; i < input.Length; i++)
            {
                currPackage = getCurrentPackage(input[i]);
                dependency = getDependency(input[i]);

                //Debug.WriteLine("input " + i + " contains dependency: " + packageDependencyOrder.Contains(dependency));
                //Debug.WriteLine("input " + i + " dependency is: " + dependency);
                //Debug.WriteLine("packgedependencyorder contains dependency: " + packageDependencyOrder.Contains(currPackage));

                //if the dependency order string contains the dependency for the current package AND does not already contain the current package, add it to the string
                //reset i to zero to ensure all packages are checked 
                if (packageDependencyOrder.Contains(dependency) && !packageDependencyOrder.Contains(currPackage))
                {
                    //Debug.WriteLine(containsDependency(packageDependencyOrder, getDependency(input[i])));
                    //Debug.WriteLine("Adding " + addWithDependencies(input[i]) + " to dependency order string");
                    packageDependencyOrder += currPackage + ", ";

                    i = 0;
                    packageCount++;
                }

                //Debug.WriteLine(packageDependencyOrder);
            }

            //if a dependency loop is present, not all of the packages would be added to the order string, if the number of packes added to the string does not equal the number of packages, throw new PackageRejectedException
            //Debug.WriteLine("package count is: " + packageCount + " number of packages is: " + numPackages);
            if (packageCount != numPackages)
            {
                //Debug.WriteLine("Throwing new exception");
                packageDependencyOrder = "Invalid Package Input";
                throw new PackageRejectedException(packageDependencyOrder);
            }

            if (!packageDependencyOrder.Equals("Invalid Package Input"))
            {
                packageDependencyOrder = packageDependencyOrder.Substring(0, packageDependencyOrder.Length - 2);
            }


            Console.WriteLine(packageDependencyOrder);

            return packageDependencyOrder;
        }

        //called if there is a dependency, program should already have checked if dependency was in string, if it was this will add the package to the string
        private string getCurrentPackage(string tempPackage)
        {
            string package = "";

            int j = 0;
            while (tempPackage[j] != ':')
            {
                package += tempPackage[j];
                j++;
            }

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
    }
}
