using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class TextMessage : Message
    {
        public String content;

        public TextMessage(String content):base()
        {
            this.content = content;
        }
        public override String type()
        {
            return "text";
        }
    }
}
