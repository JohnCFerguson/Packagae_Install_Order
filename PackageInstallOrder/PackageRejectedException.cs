using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageInstallOrder
{
    public class PackageRejectedException : Exception
    {
        public PackageRejectedException()
        {
        }

        public PackageRejectedException(string message) 
            : base(message)
        {
            Console.WriteLine(message);
        }

        public PackageRejectedException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
