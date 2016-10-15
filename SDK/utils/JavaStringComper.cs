using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DingDingSDK.utils
{
    public class JavaStringComper : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            return x[0] - y[0];
            throw new NotImplementedException();
        }
    }
}
