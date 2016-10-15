using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK
{
    public class OApiException: Exception
    {
        public OApiException(int errCode, String errMsg):base("error code: " + errCode + ", error message: " + errMsg)
        {
            //super("error code: " + errCode + ", error message: " + errMsg);
        }
    }
}
