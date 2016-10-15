using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK
{
    public class Env
    {
        public const String OAPI_HOST = "https://oapi.dingtalk.com";

        public static String CORP_ID { get; set; }
        public static String SECRET { get; set; }

        public static String suiteTicket { get; set; }
        public static String authCode { get; set; }

        public static String CREATE_SUITE_KEY { get; set; }
        public static String SUITE_KEY { get; set; }
        public static String SUITE_SECRET { get; set; }
        public static String TOKEN { get; set; }
        public static String ENCODING_AES_KEY { get; set; }

        public static string suite_access_token = "";//套件token
        public static string permanent_code = "";//永久授权码
        public static string auth_corpid = "";//企业CORP_ID

    }
}
