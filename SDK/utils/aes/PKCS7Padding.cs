using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.utils.aes
{
    /*
 * PKCS7算法的加密填充
 */
    public class PKCS7Padding
    {
        //private readonly static Charset CHARSET = Charset.forName("utf-8");
        private readonly static int BLOCK_SIZE = 32;

        /**
         * 填充mode字节
         * @param count
         * @return
         */
        public static byte[] getPaddingBytes(int count)
        {
            int amountToPad = BLOCK_SIZE - (count % BLOCK_SIZE);
            if (amountToPad == 0)
            {
                amountToPad = BLOCK_SIZE;
            }
            char padChr = chr(amountToPad);
            String tmp = string.Empty; ;
            for (int index = 0; index < amountToPad; index++)
            {
                tmp += padChr;
            }
            return System.Text.Encoding.UTF8.GetBytes(tmp);
        }

        /**
         * 移除mode填充字节
         * @param decrypted
         * @return
         */
        public static byte[] removePaddingBytes(byte[] decrypted)
        {
            int pad = (int)decrypted[decrypted.Length - 1];
            if (pad < 1 || pad > BLOCK_SIZE)
            {
                pad = 0;
            }
            //Array.Copy()
            var output = new byte[decrypted.Length - pad];
            Array.Copy(decrypted,output, decrypted.Length - pad);
            return output;
        }

        private static char chr(int a)
        {
            byte target = (byte)(a & 0xFF);
            return (char)target;
        }

    }
}
