using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class ConversationMessageDelivery: MessageDelivery
    {
        public String sender
        {
            get; set; }
        public String cid
        {
            get; set;
        }
        public String agentid
        {
            get; set;
        }

        public ConversationMessageDelivery(String sender, String cid,
                String agentId)
        {
            this.sender = sender;
            this.cid = cid;
            this.agentid = agentId;
        }

        public override BsonDocument toJsonObject()
        {
            BsonDocument json = base.toJsonObject();
            json["sender"] = this.sender;
            json["cid"] = this.cid;
            json["agentid"]=this.agentid;
            return json;
        }
    }
}
