using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace DingDingSDK.utils.aes
{
    /**
 * 加解密工具类
 */
    public class Utils
    {
        /**
     *
     * @return
     */
        public static String getRandomStr(int count)
        {
            String baset = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                int number = random.Next(baset.Length);
                sb.Append(baset[number]);
            }
            return sb.ToString();
        }


        /*
         * int转byte数组,高位在前
         */
        public static byte[] int2Bytes(int count)
        {
            byte[] byteArr = new byte[4];
            byteArr[3] = (byte)(count & 0xFF);
            byteArr[2] = (byte)(count >> 8 & 0xFF);
            byteArr[1] = (byte)(count >> 16 & 0xFF);
            byteArr[0] = (byte)(count >> 24 & 0xFF);
            return byteArr;
        }

        /**
         * 高位在前bytes数组转int
         * @param byteArr
         * @return
         */
        public static int bytes2int(byte[] byteArr)
        {
            int count = 0;
            for (int i = 0; i < 4; i++)
            {
                count <<= 8;
                count |= byteArr[i] & 0xff;
            }
            return count;
        }
    }
}
