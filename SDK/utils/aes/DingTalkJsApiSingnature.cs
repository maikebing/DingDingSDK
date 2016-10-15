using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.utils.aes
{
    /**
 * 钉钉jsapi签名工具类
 */
    public class DingTalkJsApiSingnature
    {
        /**
    * 获取jsapi签名
    * @param url
    * @param nonce
    * @param timeStamp
    * @param jsTicket
    * @return
    * @throws DingTalkEncryptException
    */
        public static String getJsApiSingnature(String url, String nonce, long timeStamp, String jsTicket) 
        {
            String plainTex = "jsapi_ticket=" + jsTicket +"&noncestr=" + nonce +"&timestamp=" + timeStamp + "&url=" + url;
            String signature = "";
        try{
                System.Security.Cryptography.SHA1 hash = System.Security.Cryptography.SHA1.Create();
                var encoder = System.Text.UTF8Encoding.UTF8;
                byte[] combined = encoder.GetBytes(plainTex);
                byte[] digest = hash.ComputeHash(combined);

                //MessageDigest crypt = MessageDigest.getInstance("SHA-1");
                //crypt.reset();
                //crypt.update(plainTex.getBytes("UTF-8"));
                signature = byteToHex(digest);
                return signature;
            }catch (Exception e){
                throw new DingTalkEncryptException(DingTalkEncryptException.COMPUTE_SIGNATURE_ERROR);
            }
        }

        private static String byteToHex(byte[] hash)
        {
            string str;
            string str2 = "";
            long num2 = hash.Length - 1;
            for (int i = 0; i <= num2; i++)
            {
                string str3 = Convert.ToByte(hash[i]).ToString("x");
                if (str3.Length == 1)
                {
                    str3 = "0" + str3;
                }
                str2 = str2 + str3;
            }
            str = str2;
            return str;
            //Formatter formatter = new Formatter();
            //for (byte b : hash)
            //{
            //    formatter.format("%02x", b);
            //}
            //String result = formatter.toString();
            //formatter.close();
            //return result;
        }


        public static void main(String[] args) 
        {
            // signature:810e6657e9f411e6491b3e97dfaf7660e89eb874,serverSign:0e781e79966d6f27e2b6456b83d5cee0ebaeb81b
            String url="http://10.62.53.138:3000/jsapi";
            String nonce="abcdefgh";
            long timeStamp = 1437027269927L;
            String tikcet="zHoQdGJuH0ZDebwo7sLqLzHGUueLmkWCC4RycYgkuvDu3eoROgN5qhwnQLgfzwEXtuR9SDzh6BdhyVngzAjrxV";
            //System.err.println(getJsApiSingnature(url,nonce,timeStamp,tikcet));
        }
    }
}
