using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK
{
    public class OApiException: Exception
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public OApiException(int errCode, String errMsg):base("error code: " + errCode + ", error message: " + errMsg)
        {
            ErrCode = errCode;
            ErrMsg = errMsg;
            //super("error code: " + errCode + ", error message: " + errMsg);
        }

        public void printStackTrace()
        {
            Console.WriteLine(string.Format("errCode=%d errMsg=%s", ErrCode, ErrMsg));
        }
    }
}
