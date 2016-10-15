using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class MessageHelper
    {
        public class Receipt
        {
            public String invaliduser
            {
                get; set;
            }
            public String invalidparty
            {
                get; set;
            }
        }


        public static Receipt send(String accessToken, LightAppMessageDelivery delivery)
        {
            String url = Env.OAPI_HOST + "/message/send?" +
                "access_token=" + accessToken;

            BsonDocument response = HttpHelper.httpPost(url, delivery.toJsonObject());
            if (response.Contains("invaliduser") || response.Contains("invalidparty"))
            {
                Receipt receipt = new Receipt();
                receipt.invaliduser = response.GetValue("invaliduser", "").ToString();
                receipt.invalidparty = response.GetValue("invalidparty", "").ToString();
                return receipt;
            }
            else
            {
                throw new OApiResultException("invaliduser or invalidparty");
            }
        }


        public static String send(String accessToken, ConversationMessageDelivery delivery)
        {
            String url = Env.OAPI_HOST + "/message/send_to_conversation?" +
                "access_token=" + accessToken;

            BsonDocument response = HttpHelper.httpPost(url, delivery.toJsonObject());
            if (response.Contains("receiver"))
            {
                return response["receiver"].ToString();
            }
            else
            {
                throw new OApiResultException("receiver");
            }
        }
    }
}
