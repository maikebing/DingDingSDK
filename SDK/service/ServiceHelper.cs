using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.service
{
    public class ServiceHelper
    {
        public static String getSuiteToken(String suite_key, String suite_secret, String suite_ticket)
        {
            String url = Env.OAPI_HOST + "/service/get_suite_token";
            BsonDocument json = new BsonDocument();
            json["suite_key"]=suite_key;
            json["suite_secret"]= suite_secret;
            json["suite_ticket"]= suite_ticket;
            BsonDocument reponseJson = null;
            String suiteAccessToken = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
                suiteAccessToken = reponseJson["suite_access_token"].ToString();
            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return suiteAccessToken;
        }

        public static String getPermanentCode(String tmp_auth_cod, String suiteAccessToken)
        {
            String url = Env.OAPI_HOST + "/service/get_permanent_code?suite_access_token=" + suiteAccessToken;
            BsonDocument json = new BsonDocument();
            json["tmp_auth_code"]= tmp_auth_cod;
            BsonDocument reponseJson = null;
            String permanentCode = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
                permanentCode = reponseJson["permanent_code"].ToString();
                Env.auth_corpid = reponseJson["corpid"].ToString();
            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return permanentCode;
        }

        public static String getCorpToken(String auth_corpid, String permanent_code, String suiteAccessToken)
        {
            String url = Env.OAPI_HOST + "/service/get_corp_token?suite_access_token=" + suiteAccessToken;
            BsonDocument json = new BsonDocument();
            json["auth_corpid"]=auth_corpid;
            json["permanent_code"]= permanent_code;
            BsonDocument reponseJson = null;
            String corpToken = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
                corpToken = reponseJson["access_token"].ToString();

            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return corpToken;
        }

        public static BsonDocument getAuthInfo(String suiteAccessToken, String suite_key, String auth_corpid, String permanent_code)
        {
            String url = Env.OAPI_HOST + "/service/get_auth_info?suite_access_token=" + suiteAccessToken;
            BsonDocument json = new BsonDocument();
            json["suite_key"]= suite_key;
            json["auth_corpid"]= auth_corpid;
            json["permanent_code"]= permanent_code;

            BsonDocument reponseJson = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return reponseJson;
        }

        public static BsonDocument getAgent(String suiteAccessToken, String suite_key, String auth_corpid, String permanent_code, String agentid)
        {
            String url = Env.OAPI_HOST + "/service/get_agent?suite_access_token=" + suiteAccessToken;
            BsonDocument json = new BsonDocument();
            json["suite_key"]=suite_key;
            json["auth_corpid"]=auth_corpid;
            json["permanent_code"]=permanent_code;
            json["agentid"]=agentid;//agentid可以通过getAuthInfo返回的json中得到

            BsonDocument reponseJson = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return reponseJson;
        }


        public static BsonDocument getActivateSuite(String suiteAccessToken, String suite_key, String auth_corpid, String permanent_code)
        {
            String url = Env.OAPI_HOST + "/service/activate_suite?suite_access_token=" + suiteAccessToken;
            BsonDocument json = new BsonDocument();
            json["suite_key"]=suite_key;
            json["auth_corpid"]=auth_corpid;
            json["permanent_code"]=permanent_code;

            BsonDocument reponseJson = null;
            try
            {
                reponseJson = HttpHelper.httpPost(url, json);
            }
            catch (OApiException e)
            {
                //e.printStackTrace();
            }
            return reponseJson;
        }
    }
}
