using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public static class GuidHelper
    {

        public static string GetRandomPasswordUsingGUID(int length)
        {
            //string guidResult = System.Guid.NewGuid().ToString();
            //guidResult = guidResult.Replace("-", string.Empty);
            //if (length <= 0 || length > guidResult.Length)
            //    throw new ArgumentException("Length must be between 1 and " + guidResult.Length);
            //return guidResult.Substring(0, length);
            return "12345";
        }
    }
}
