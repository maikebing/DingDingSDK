using DingDingSDK;
using DingDingSDK.auth;
using DingDingSDK.department;
using DingDingSDK.media;
using DingDingSDK.message;
using DingDingSDK.user;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DingDingSDK.media.MediaHelper;

namespace DingDingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            
    
            try
            {
              

                //请改写你的配置
                Vars.AGENT_ID = "";
                Env.CORP_ID = "";
                Env.SECRET = "";
                Env.CREATE_SUITE_KEY = "";
                Env.SUITE_KEY = "";
                Env.SUITE_SECRET = "";
                Env.TOKEN = "";
                Env.ENCODING_AES_KEY = "";
                // 获取access token
                string accessToken = AuthHelper.getAccessToken();
                log("成功获取access token: ", accessToken);

                // 获取jsapi ticket
                String ticket = AuthHelper.getJsapiTicket(accessToken);
                log("成功获取jsapi ticket: ", ticket);

                // 获取签名
                String nonceStr = "nonceStr";
                long timeStamp = Convert.ToInt64(DateTime.Now.Subtract(DateTime.Parse("1970-1-1")).TotalMilliseconds);//System.currentTimeMillis();
                String url = "http://www.dingtalk.com";
                String signature = AuthHelper.sign(ticket, nonceStr, timeStamp, url);
                log("成功签名: ", signature);

                //获取部门列表
                List<Department> list = DepartmentHelper.listDepartments(accessToken);
                log("成功获取部门列表", list);

                //创建部门
                String name = "TestDept.16";
                String parentId = "1";
                String order = "1";
                var depttmp = list.Find(dp => dp.name == name);
                if (depttmp != null)
                {
                    DepartmentHelper.deleteDepartment(accessToken, long.Parse(depttmp.id));
                }
                long departmentId = DepartmentHelper.createDepartment(accessToken,
                        name, parentId, order);
                log("成功创建部门", name, " 部门id=", departmentId);


                //更新部门
                DepartmentHelper.updateDepartment(accessToken, name, parentId, order, departmentId);
                log("成功更新部门", " 部门id=", departmentId);
                var usrlist=UserHelper.getDepartmentUser(accessToken, departmentId);
                var userf = usrlist.Find(usr => usr.userid == "id_yuhuan");
                if (userf!=null )
                {
                    UserHelper.deleteUser(accessToken, userf.userid);
                    log("用户删除成功", name, " 用户ID=", userf.userid);
                }
                //创建成员
                User user = new User("id_yuhuan", "name_yuhuan");
                user.email = "yuhuan@abc.com";
                user.mobile = "18645512324";
                user.department = new List<long>();
                user.department.Add(departmentId);
                UserHelper.createUser(accessToken, user);
                log("成功创建成员", "成员信息=", user);

                //上传图片
                FileInfo file = new FileInfo("1111.PNG");
                MediaHelper.MediaUploadResult uploadResult =
                        MediaHelper.upload(accessToken, MediaHelper.TYPE_IMAGE, file);
                log("成功上传图片", uploadResult);

                //下载图片
                String fileDir = "1111.PNG";
                MediaHelper.download(accessToken, uploadResult.media_id, fileDir);
                log("成功下载图片");

                TextMessage textMessage = new TextMessage("TextMessage");
                ImageMessage imageMessage = new ImageMessage(uploadResult.media_id);
                LinkMessage linkMessage = new LinkMessage("http://www.baidu.com", "@lALOACZwe2Rk",
                        "Link Message", "This is a link message");

                //创建oa消息
                OAMessage oaMessage = new OAMessage();
                oaMessage.message_url = "http://www.dingtalk.com";
                OAMessage.Head head = new OAMessage.Head();
                head.bgcolor = "FFCC0000";
                oaMessage.head = head;
                OAMessage.Body body = new OAMessage.Body();
                body.title = "征婚启事";
                OAMessage.Body.Form form1 = new OAMessage.Body.Form();
                form1.key = "姓名";
                form1.value = "刘增产";
                OAMessage.Body.Form form2 = new OAMessage.Body.Form();
                form2.key = "年龄";
                form2.value = "18";
                body.form = new List<OAMessage.Body.Form>();
                body.form.Add(form1);
                body.form.Add(form2);
                OAMessage.Body.Rich rich = new OAMessage.Body.Rich();
                rich.num = "5";
                rich.unit = "毛";
                body.rich = rich;
                body.content = "这是一则严肃的征婚启事。不约。";
                body.image = "";
                body.file_found = "3";
                body.author = "识器";
                oaMessage.body = body;
                
                //发送微应用消息
                String toUsers = Vars.TO_USER;
                String toParties = ""; // Vars.TO_PARTY;
                String agentId = Vars.AGENT_ID;
                foreach (var item in list)
                {
                    toParties += item.id + "|";
                }
                LightAppMessageDelivery lightAppMessageDelivery =
                        new LightAppMessageDelivery(toUsers, toParties, agentId);

                lightAppMessageDelivery.withMessage(textMessage);
                MessageHelper.send(accessToken, lightAppMessageDelivery);
                log("成功发送 微应用文本消息");
                lightAppMessageDelivery.withMessage(imageMessage);
                MessageHelper.send(accessToken, lightAppMessageDelivery);
                log("成功发送 微应用图片消息");
                lightAppMessageDelivery.withMessage(linkMessage);
                MessageHelper.send(accessToken, lightAppMessageDelivery);
                log("成功发送 微应用link消息");
                lightAppMessageDelivery.withMessage(oaMessage);
                MessageHelper.send(accessToken, lightAppMessageDelivery);
                log("成功发送 微应用oa消息");

                //发送会话消息
                String sender = Vars.SENDER;
                String cid = Vars.CID;
                ConversationMessageDelivery conversationMessageDelivery =
                        new ConversationMessageDelivery(sender, cid, agentId);

                conversationMessageDelivery.withMessage(textMessage);
                MessageHelper.send(accessToken, conversationMessageDelivery);
                log("成功发送 会话文本消息");
                conversationMessageDelivery.withMessage(imageMessage);
                MessageHelper.send(accessToken, conversationMessageDelivery);
                log("成功发送 会话图片消息");
                conversationMessageDelivery.withMessage(linkMessage);
                MessageHelper.send(accessToken, conversationMessageDelivery);
                log("成功发送 会话link消息");

                //更新成员
                user.mobile = "18612341234";
                UserHelper.updateUser(accessToken, user);
                log("成功更新成员", "成员信息=", user);

                //获取成员
                UserHelper.getUser(accessToken, user.userid);
                log("成功获取成员", "成员userid=", user.userid);

                //获取部门成员
                List<User> userList = UserHelper.getDepartmentUser(accessToken, departmentId);
                log("成功获取部门成员", "部门成员user=", userList);

                //获取部门成员（详情）
                List<User> userList2 = UserHelper.getUserDetails(accessToken, departmentId);
                log("成功获取部门成员详情", "部门成员详情user=", userList2);

                //批量删除成员
                User user2 = new User("id_yuhuan2", "name_yuhuan2");
                user2.email = "yuhua2n@abc.com";
                user2.mobile = "18611111111";
                user2.department = new List<long>();
                user2.department.Add(departmentId);
                UserHelper.createUser(accessToken, user2);

                List<String> useridlist = new List<String>();
                useridlist.Add(user.userid);
                useridlist.Add(user2.userid);
                UserHelper.batchDeleteUser(accessToken, useridlist);
                log("成功批量删除成员", "成员列表useridlist=", useridlist);

                //删除成员
                User user3 = new User("id_yuhuan3", "name_yuhuan3");
                user3.email = "yuhua2n@abc.com";
                user3.mobile = "18611111111";
                user3.department = new List<long>();
                user3.department.Add(departmentId);
                UserHelper.createUser(accessToken, user3);
                UserHelper.deleteUser(accessToken, user3.userid);
                log("成功删除成员", "成员userid=", user3.userid);

                //删除部门
                DepartmentHelper.deleteDepartment(accessToken, departmentId);
                log("成功删除部门", " 部门id=", departmentId);

            }
            catch (OApiException e)
            {
            
                e.printStackTrace();
            }
        }


        private static void log(params Object[] msgs)
        {
            LogHelper.AddLog(string.Join("\r\n________\r\n", msgs.Select(x => x.ToString()).ToList()), typeof(Program));
            StringBuilder sb = new StringBuilder();
            foreach (var item in msgs)
            {
                sb.Append(sb);
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
