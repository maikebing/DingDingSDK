using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK
{
    public class OApiResultException: OApiException
    {
        public static readonly int ERR_RESULT_RESOLUTION = -2;

        public OApiResultException(String field):base(ERR_RESULT_RESOLUTION, "Cannot resolve field " + field + " from oapi resonpse")
        {
         //   super(ERR_RESULT_RESOLUTION, "Cannot resolve field " + field + " from oapi resonpse");
        }

    }
}
