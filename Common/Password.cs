﻿using System;
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

        protected Password()
        {
        }

        public string Value { get; protected set; }

        public static Password FromPlainString(string value)
        {
            Require.NotEmpty(value, nameof(value));
            return new Password(value);
        }

        protected bool Equals(Password other)
        {
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Password)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public static bool IsStringCorrectPassword(string passwordToCheck)
        {
            return Regex.IsMatch(passwordToCheck, "^.{8,18}$");
        }
    }
}
