using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.eventchange
{
    public class eventChangeHelper
    {
        //注册事件回调接口
        public static String registerEventChange(String accessToken, List<String> callBackTag, String token, String aesKey, String url)
        {
            String signUpUrl = Env.OAPI_HOST + "/call_back/register_call_back?" +
                "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["call_back_tag"] = new BsonArray(callBackTag);
            args["token"] = token;
            args["aes_key"] = aesKey;
            args["url"] = url;

            BsonDocument response = HttpHelper.httpPost(signUpUrl, args);
            if (response.Contains("errcode"))
            {
                return response["errcode"].ToString();
            }
            else
            {
                throw new OApiResultException("errcode");
            }
        }
        //查询事件回调接口
        public static String getEventChange(String accessToken)
        {
            String url = Env.OAPI_HOST + "/call_back/get_call_back?" +
                "access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
            return response.ToString();
        }
        //更新事件回调接口
        public static String updateEventChange(String accessToken, List<String> callBackTag, String token, String aesKey, String url)
        {
            String signUpUrl = Env.OAPI_HOST + "/call_back/update_call_back?" +
                "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["call_back_tag"] = new BsonArray(callBackTag);
            args["token"] = token;
            args["aes_key"] = aesKey;
            args["url"] = url;

            BsonDocument response = HttpHelper.httpPost(signUpUrl, args);
            if (response.Contains("errcode"))
            {
                return response["errcode"].ToString();
            }
            else
            {
                throw new OApiResultException("errcode");
            }
        }
        //删除事件回调接口
        public static String deleteEventChange(String accessToken)
        {
            String url = Env.OAPI_HOST + "/call_back/delete_call_back?" +
                "access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
            return response.ToString();
        }


        public static String getFailedResult(String accessToken)
        {
            String url = Env.OAPI_HOST + "/call_back/get_call_back_failed_result?" +
                "access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
            return response.ToString();
        }
    }
}
