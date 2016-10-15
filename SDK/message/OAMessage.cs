using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.message
{
    /** 
  { 
    "message_url": "http://dingtalk.com", 
    "head": {
        "bgcolor": "FFCC0000"
    }, 
    "body": {
        "title": "标题", 
        "form": [
            {
                "key": "姓名", 
                "value": "张三"
            }, 
            {
                "key": "年龄", 
                "value": "30"
            }
        ], 
        "rich": {
            "num": "15.6", 
            "unit": "元"
        }, 
        "content": "大段文本", 
        "image": "@lADOAAGXIszazQKA", 
        "file_count": "3", 
        "author": "李四"
    }
 */
    public class OAMessage: Message
    {
        public String message_url;
        public Head head;
        public Body body;
        
        public override String type()
        {
            return "oa";
        }

        //content
        public  class Head
        {
            public String bgcolor;
        }

        public  class Body
        {
            public String title { get; set; }
            public List<Form> form { get; set; }
            public Rich rich { get; set; }
            public String content { get; set; }
            public String image { get; set; }
            public String file_found { get; set; }
            public String author { get; set; }

            public  class Form
            {
                public String key { get; set; }
                public String value { get; set; }
            }

            public  class Rich
            {
                public String num { get; set; }
                public String unit { get; set; }
            }
        }
    }
}
