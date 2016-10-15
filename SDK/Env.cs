using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK
{
    public class Env
    {
        public const String OAPI_HOST = "https://oapi.dingtalk.com";

        public const String CORP_ID = "136001";
        public const String SECRET = "6ATEWBfiaTUZBFG5djt2JN-XtLoDcLYPXQ9TES658eM2CWZEoqrFuxGGDMcAQXMd";

        public static String suiteTicket;
        public static String authCode;

        public const String CREATE_SUITE_KEY = "suitenr0azwp8exmqqsau";
        public const String SUITE_KEY = "suitenr0azwp8exmqqsau";
        public const String SUITE_SECRET = "6ATEWBfiaTUZBFG5djt2JN-XtLoDcLYPXQ9TES658eM2CWZEoqrFuxGGDMcAQXMd";
        public const String TOKEN = "freefnc";
        public const String ENCODING_AES_KEY = "bsvhcqfd6lrd52rlj9t9n6gdui97d3x7b05k3ztam05";

        public static string suite_access_token = "";//套件token
        public static string permanent_code = "";//永久授权码
        public static string auth_corpid = "";//企业CORP_ID

    }
}
