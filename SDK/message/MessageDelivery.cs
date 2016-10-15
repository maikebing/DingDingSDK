using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class MessageDelivery
    {
        public String msgtype
        {
            get; set;
        }
        public Message message
        {
            get; set;
        }

        public MessageDelivery withMessage(Message msg)
        {
            this.msgtype = msg.type();
            this.message = msg;
            return this;
        }

        public virtual BsonDocument toJsonObject()
        {
            BsonDocument json = new BsonDocument();
            json["msgtype"]= this.msgtype;
            json[this.msgtype] = BsonDocument.Parse(Newtonsoft.Json.JsonConvert.SerializeObject(this.message));// JSON.toJSON(this.message);
            return json;
        }
    }
}
