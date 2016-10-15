using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.user
{
    public class User
    {
        public String userid;
        public String name;
        public bool active;
        public String avatar;
        public List<long> department;
        public String position;
        public String mobile;
        public String email;
        public String openId;
        public int status;
        public BsonDocument extattr;

        public User()
        {
        }

        public User(String userid, String name)
        {
            this.userid = userid;
            this.name = name;
        }
        public override string ToString()
        {
            //List<User> users;
            return "User[userid:" + userid + ", name:" + name + ", active:" + active + ", "
                    + "avatar:" + avatar + ", department:" + department +
                    ", position:" + position + ", mobile:" + mobile + ", email:" + email +
                    ", openId:" + openId + ", status:" + status + ", extattr:" + extattr;
        }
    }
}
