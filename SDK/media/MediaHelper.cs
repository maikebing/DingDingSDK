using DingDingSDK.utils;
using MongoDB.Bson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.media
{
    public class MediaHelper
    {
        public static readonly String TYPE_IMAGE = "image";
        public static readonly String TYPE_VOICE = "voice";
        public static readonly String TYPE_VIDEO = "video";
        public static readonly String TYPE_FILE = "file";

    
        public class MediaUploadResult
        {
            public int errcode { get; set; }
            public string errmsg { get; set; }
            public string type
            {
                get; set;
            }
            public string media_id
            {
                get; set;
            }
            public string created_at
            {
                get; set;
            }
        }
    


        public static MediaUploadResult upload(String accessToken, String type, FileInfo file)
        {
            String url = Env.OAPI_HOST + "/media/upload?" +
                "access_token=" + accessToken + "&type=" + type;
            BsonDocument response = HttpHelper.uploadMedia(url, file);
            if (!response.Contains("type") || !response.Contains("media_id") ||
                    response.Contains("created_at"))
            {
                response.Set("created_at", response.GetValue("created_at").AsInt64.ToString());

                return Newtonsoft.Json.JsonConvert.DeserializeObject<MediaUploadResult>(response.ToString() );
            }
            else
            {
                throw new OApiResultException("type or media_id or create_at");
            }
        }


        public static void download(String accessToken, String mediaId, String fileDir)
        {
            String url = Env.OAPI_HOST + "/media/get?" +
                        "access_token=" + accessToken + "&media_id=" + mediaId;
            BsonDocument response = HttpHelper.downloadMedia(url, fileDir);
            //System.out.println(response);
        }
    }
}
