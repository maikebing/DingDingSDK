using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace DingDingSDK
{
    public class LogHelper
    {


        public static void AddLog(string mes, Type t)
        {
            log4net.LogManager.GetLogger(t).Info(mes);
        }

        public static void AddLog2(int index,string mes, Type t)
        {
            //log4net.LogManager.GetLogger(t).Info("index:"+index+":"+mes);
            logList.Add(new LogModel() {  CreateTime=DateTime.Now,  Message= "index:" + index + ":" + mes });
        }
        public static List<LogModel> logList = new List<LogModel>();
        public static List<LogModel> GetLog()
        {
            return logList;
        }
        public static void ClareALLLog()
        {
            logList = new List<LogModel>();
        }
    }
    public class LogModel
    {
        public DateTime CreateTime { get; set; }
        public string Message { get; set; }
    }
}
