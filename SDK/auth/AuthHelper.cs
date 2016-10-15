using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.auth
{
    public class AuthHelper
    {
        public static String getAccessToken()
        {
            String url = Env.OAPI_HOST + "/gettoken?" +
                "corpid=" + Env.CORP_ID + "&corpsecret=" + Env.SECRET;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("access_token")) {
                return response["access_token"].ToString();
            }
            else {
                throw new OApiResultException("access_token");
            }
        }

        public static String getJsapiTicket(String accessToken)
        {
            String url = Env.OAPI_HOST + "/get_jsapi_ticket?" + 
				"type=jsapi" + "&access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
		if (response.Contains("ticket")) {
                return response["ticket"].ToString();
            }
		else {
                throw new OApiResultException("ticket");
            }
        }

        public static String sign(String ticket, String nonceStr, long timeStamp, String url)
        {
            String plain = "jsapi_ticket=" + ticket + "&noncestr=" + nonceStr +
	            "&timestamp=" + timeStamp.ToString() + "&url=" + url;
		try {

                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                var encoder = System.Text.UTF8Encoding.UTF8;
                byte[] combined = encoder.GetBytes(plain);
                byte[] digest = hash.ComputeHash(combined);
                return bytesToHex(digest);

                //MessageDigest sha1 = MessageDigest.getInstance("SHA-1");
                //sha1.reset();
                //sha1.update(plain.getBytes("UTF-8"));
                //return bytesToHex(sha1.digest());
            } catch (Exception e) {
                throw new OApiResultException(e.ToString());
            } 
        }

        private static String bytesToHex(byte[] hash)
        {
            string str;
            string str2 = "";
            long num2 = hash.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                string str3 = Convert.ToByte(hash[i]).ToString("x");
                if (str3.Length == 1)
                {
                    str3 = "0" + str3;
                }
                str2 = str2 + str3;
            }
            str = str2;
            return str;
            //Formatter formatter = new Formatter();
            //for (byte b : hash)
            //{
            //    formatter.format("%02x", b);
            //}
            //String result = formatter.toString();
            //formatter.close();
            //return result;
        }

        public static String getConfig(String urlString, String queryString)
        {

            String queryStringEncode = null;
            String url;
            if (queryString != null)
            {
                queryStringEncode = System.Web.HttpUtility.UrlDecode(queryString);
                url = urlString + "?" + queryStringEncode;
            }
            else
            {
                url = urlString;
            }
            //System.out.println(url);
            String nonceStr = "abcdefg";
            long timeStamp = Convert.ToInt64(DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds) / 1000;
            String signedUrl = url;
            String accessToken = null;
            String ticket = null;
            String signature = null;
            try
            {
                accessToken = AuthHelper.getAccessToken();
                ticket = AuthHelper.getJsapiTicket(accessToken);
                signature = AuthHelper.sign(ticket, nonceStr, timeStamp, signedUrl);
            }
            catch (OApiException e)
            {
                // TODO Auto-generated catch block
                //e.printStackTrace();
            }
            return "{signature:'" + signature + "',nonceStr:'" + nonceStr + "',timeStamp:'" + timeStamp + "',corpId:'" + Env.CORP_ID + "'}";
        }
    }
}
