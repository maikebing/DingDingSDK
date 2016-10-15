using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class LightAppMessageDelivery : MessageDelivery
    {
        public String touser;
        public String toparty;
        public String agentid;

        public LightAppMessageDelivery(String toUsers, String toParties, String agentId)
        {
            this.touser = toUsers;
            this.toparty = toParties;
            this.agentid = agentId;
        }
        public override BsonDocument toJsonObject()
        {
            BsonDocument json = base.toJsonObject();
            json["touser"] = this.touser;
            json["toparty"] = this.toparty;
            json["agentid"] = this.agentid;

            return json;
        }
    }
}
