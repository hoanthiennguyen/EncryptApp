﻿using System.IO;

namespace EncryptApp
{
    class EncryptUtil
    {
        public string filePath, password;
        public void Decrypt()
        {

            byte[] content = File.ReadAllBytes(filePath);

            for (int i = 0; i < content.Length; i++)
            {
                int indexInPwd = i % password.Length;
                int sum = (content[i] - password[indexInPwd]) % 256;
                content[i] = (byte)sum;
            }
            File.WriteAllBytes(filePath, content);
        }
        public void Encrypt()
        {

            byte[] content = File.ReadAllBytes(filePath);
            for (int i = 0; i < content.Length; i++)
            {
                int indexInPwd = i % password.Length;
                int sum = (content[i] + password[indexInPwd]) % 256;
                content[i] = (byte)sum;
            }
            File.WriteAllBytes(filePath, content);
        }
       
    }
}
