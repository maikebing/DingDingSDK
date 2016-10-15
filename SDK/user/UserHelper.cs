using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.user
{
    public class UserHelper
    {
        //创建成员
        public static void createUser(String accessToken, User user)
        {
            String url = Env.OAPI_HOST + "/user/create?" +
                "access_token=" + accessToken;
            HttpHelper.httpPost(url, user);
        }


        //更新成员
        public static void updateUser(String accessToken, User user)
        {
            String url = Env.OAPI_HOST + "/user/update?" +
                "access_token=" + accessToken;
            HttpHelper.httpPost(url, user);
        }


        //删除成员
        public static void deleteUser(String accessToken, String userid)
        {
            String url = Env.OAPI_HOST + "/user/delete?" +
                "access_token=" + accessToken + "&userid=" + userid;
            HttpHelper.httpGet(url);
        }


        //获取成员
        public static User getUser(String accessToken, String userid)
        {
            String url = Env.OAPI_HOST + "/user/get?" +
                "access_token=" + accessToken + "&userid=" + userid;
            BsonDocument json = HttpHelper.httpGet(url);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<User>(json.ToString());
            //return JSON.parseObject(json.ToString(), User.class);
        }


        //批量删除成员
        public static void batchDeleteUser(String accessToken, List<String> useridlist)
        {
            String url = Env.OAPI_HOST + "/user/batchdelete?" +
                    "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["useridlist"] = new BsonArray(useridlist);
            HttpHelper.httpPost(url, args);
        }


        //获取部门成员
        public static List<User> getDepartmentUser(String accessToken, long department_id)
        {
            String url = Env.OAPI_HOST + "/user/simplelist?" +
                    "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("userlist"))
            {
                List<User> list = new List<User>();
                BsonArray arr = response["userlist"].AsBsonArray;
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new OApiResultException("userlist");
            }
        }


        //获取部门成员（详情）
        public static List<User> getUserDetails(String accessToken, long department_id)
        {
            String url = Env.OAPI_HOST + "/user/list?" +
                        "access_token=" + accessToken + "&department_id=" + department_id;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("userlist"))
            {
                BsonArray arr = response["userlist"].AsBsonArray;
                List<User> list = new List<User>();
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<User>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new OApiResultException("userlist");
            }
        }
        public static BsonDocument getUserInfo(String accessToken, String code)
        {

            String url = Env.OAPI_HOST + "/user/getuserinfo?" + "access_token=" + accessToken + "&code=" + code;
            BsonDocument response = HttpHelper.httpGet(url);
            return response;
        }
    }
}
