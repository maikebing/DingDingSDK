using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    public class ImageMessage : Message
    {
        public String media_id;

        public ImageMessage(String mediaId) : base()
        {
            media_id = mediaId;
        }
        public override String type()
        {
            return "image";
        }
    }
}
