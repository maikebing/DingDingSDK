using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DingDingSDK.utils.aes
{
    /**
 * 钉钉开放平台加解密异常类
 */
    public class DingTalkEncryptException : Exception
    {
        /**成功**/
        public static readonly int SUCCESS = 0;
        /**加密明文文本非法**/
        public readonly static int ENCRYPTION_PLAINTEXT_ILLEGAL = 900001;
        /**加密时间戳参数非法**/
        public readonly static int ENCRYPTION_TIMESTAMP_ILLEGAL = 900002;
        /**加密随机字符串参数非法**/
        public readonly static int ENCRYPTION_NONCE_ILLEGAL = 900003;
        /**不合法的aeskey**/
        public readonly static int AES_KEY_ILLEGAL = 900004;
        /**签名不匹配**/
        public readonly static int SIGNATURE_NOT_MATCH = 900005;
        /**计算签名错误**/
        public readonly static int COMPUTE_SIGNATURE_ERROR = 900006;
        /**计算加密文字错误**/
        public readonly static int COMPUTE_ENCRYPT_TEXT_ERROR = 900007;
        /**计算解密文字错误**/
        public readonly static int COMPUTE_DECRYPT_TEXT_ERROR = 900008;
        /**计算解密文字长度不匹配**/
        public readonly static int COMPUTE_DECRYPT_TEXT_LENGTH_ERROR = 900009;
        /**计算解密文字corpid不匹配**/
        public readonly static int COMPUTE_DECRYPT_TEXT_CORPID_ERROR = 900010;

        private static Dictionary<int, String> msgMap = new Dictionary<int, String>();
        static DingTalkEncryptException()
        {
            msgMap[SUCCESS] = "成功";
            msgMap[ENCRYPTION_PLAINTEXT_ILLEGAL] = "加密明文文本非法";
            msgMap[ENCRYPTION_TIMESTAMP_ILLEGAL] = "加密时间戳参数非法";
            msgMap[ENCRYPTION_NONCE_ILLEGAL] = "加密随机字符串参数非法";
            msgMap[SIGNATURE_NOT_MATCH] = "签名不匹配";
            msgMap[COMPUTE_SIGNATURE_ERROR] = "签名计算失败";
            msgMap[AES_KEY_ILLEGAL] = "不合法的aes key";
            msgMap[COMPUTE_ENCRYPT_TEXT_ERROR] = "计算加密文字错误";
            msgMap[COMPUTE_DECRYPT_TEXT_ERROR] = "计算解密文字错误";
            msgMap[COMPUTE_DECRYPT_TEXT_LENGTH_ERROR] = "计算解密文字长度不匹配";
            msgMap[COMPUTE_DECRYPT_TEXT_CORPID_ERROR] = "计算解密文字corpid不匹配";
        }

    private int code;
    public DingTalkEncryptException(int exceptionCode):base(msgMap[exceptionCode])
    {
        this.code = exceptionCode;
    }
}
}
