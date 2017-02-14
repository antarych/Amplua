using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using Journalist;


namespace Common
{
    public class Password
    {
        public Password(string pass)
        {
            if (IsStringCorrectPassword(pass))
            {
                var md5Hasher = MD5.Create();

                var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(pass));

                var sBuilder = new StringBuilder();

                for (var i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                Value = sBuilder.ToString();
            }
            else
            {
                throw new ArgumentException("Password does not satisfy security requirements");
            }
        }

        public Password()
        {
        }

        public virtual string Value { get; set; }

        public static bool IsStringCorrectPassword(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, "^.{8,18}$");
        }
    }
}
