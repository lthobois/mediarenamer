using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace MediaRenamer.Common
{
    class MD5
    {
        public static String createHash(String Value)
        {
            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = Encoding.ASCII.GetBytes(Value);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }
    }
}
