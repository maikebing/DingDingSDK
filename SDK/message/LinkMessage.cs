using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class LinkMessage : Message
    {
        public String messageUrl;
        public String picUrl;
        public String title;
        public String text;

        public LinkMessage(String messageUrl, String picUrl, String title, String text) : base()
        {
            this.messageUrl = messageUrl;
            this.picUrl = picUrl;
            this.title = title;
            this.text = text;
        }
        public override String type()
        {
            return "link";
        }
    }
}
