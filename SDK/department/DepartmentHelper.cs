using DingDingSDK.utils;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.department
{
    public class DepartmentHelper
    {
        public static long createDepartment(String accessToken, String name,
            String parentId, String order)
        {
            String url = Env.OAPI_HOST + "/department/create?" +
                "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["name"] = name;
            args["parentid"] = parentId;
            args["order"] = order;
            BsonDocument response = HttpHelper.httpPost(url, args);
            if (response.Contains("id"))
            {
                return response["id"].ToInt64();
            }
            else
            {
                throw new OApiResultException("id");
            }
        }


        public static List<Department> listDepartments(String accessToken)
        {
            String url = Env.OAPI_HOST + "/department/list?" +
                "access_token=" + accessToken;
            BsonDocument response = HttpHelper.httpGet(url);
            if (response.Contains("department"))
            {
                BsonArray arr = response["department"].AsBsonArray;
                List<Department> list = new List<Department>();
                for (int i = 0; i < arr.Count; i++)
                {
                    list.Add(Newtonsoft.Json.JsonConvert.DeserializeObject<Department>(arr[i].ToString()));
                }
                return list;
            }
            else
            {
                throw new OApiResultException("department");
            }
        }


        public static void deleteDepartment(String accessToken, long id)
        {
            String url = Env.OAPI_HOST + "/department/delete?" +
                        "access_token=" + accessToken + "&id=" + id;
            HttpHelper.httpGet(url);
        }


        public static void updateDepartment(String accessToken, String name,
                String parentId, String order, long id)
        {
            String url = Env.OAPI_HOST + "/department/update?" +
                        "access_token=" + accessToken;
            BsonDocument args = new BsonDocument();
            args["name"] = name;
            args["parentid"] = parentId;
            args["order"] = order;
            args["id"] = id;
            HttpHelper.httpPost(url, args);
        }
    }
}
