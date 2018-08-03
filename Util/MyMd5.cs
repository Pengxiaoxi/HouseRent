using System.Security.Cryptography;
using System.Text;

namespace Util
{
    public class MyMd5
    {
        //对传递过来的字符串进行MD5运算
        public static string GetMd5String(string str)
        {
            MD5 md5 = MD5.Create();
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
            byte[] md5Buffer = md5.ComputeHash(buffer);
            StringBuilder mm = new StringBuilder();

            foreach (byte b in md5Buffer)
            {
                mm.Append(b.ToString("x2"));
            }
            return mm.ToString();

        }
    }
}
