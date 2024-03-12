using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace NDPSo.Utils
{
    class EncryptionHelper
    {
        private static readonly string secur = "aFg2jKl1mNpQr3u5x8z2Cv4ExHp4v7y0";

        public static string Base64UrlEncode(byte[] bytes)
        {
            return Convert.ToBase64String(bytes)
                .Replace('+', '-')
                .Replace('/', '_')
                .Replace("=", "");
        }

        public static byte[] Base64UrlDecode(string input)
        {
            int padding = input.Length % 4;
            if (padding > 0)
            {
                input += new string('=', 4 - padding);
            }

            input = input.Replace('-', '+').Replace('_', '/');
            return Convert.FromBase64String(input);
        }

        public static string Encrypt(string plainText)
        {
            byte[] encryptedBytes = EncryptFunction(plainText);

            return Base64UrlEncode(encryptedBytes);
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Base64UrlDecode(cipherText);

            string decryptedText = DecryptFunction(cipherBytes);

            return decryptedText;
        }
        public static byte[] EncryptFunction(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(secur);
                aesAlg.IV = aesAlg.Key.Take(16).ToArray();

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }

                    return msEncrypt.ToArray();
                }
            }
        }

        public static string DecryptFunction(byte[] cipherBytes)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(secur);
                aesAlg.IV = aesAlg.Key.Take(16).ToArray();

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        public static string EncryptedXml(string pathXML)
        {
            string xmlContent = File.ReadAllText(pathXML);

            byte[] keyBytes = Encoding.UTF8.GetBytes(secur);
            byte[] iv = new byte[16];

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt, Encoding.UTF8))
                        {
                            using (StringReader sr = new StringReader(xmlContent))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    byte[] encryptedLineBytes = encryptor.TransformFinalBlock(Encoding.UTF8.GetBytes(line), 0, line.Length);
                                    string encryptedLine = Convert.ToBase64String(encryptedLineBytes);
                                    swEncrypt.WriteLine(encryptedLine);
                                }
                            }
                        }
                    }

                    return Convert.ToBase64String(msEncrypt.ToArray());
                }
            }
        }

        public static string DecryptedXml(string pathXML)
        {
            string xmlContent = File.ReadAllText(pathXML);
            byte[] keyBytes = Encoding.UTF8.GetBytes(secur);
            byte[] iv = new byte[16]; // Vector khởi đầu, có thể tạo một vector ngẫu nhiên

            // Tạo đối tượng AES
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = keyBytes;
                aesAlg.IV = iv;

                // Tạo bộ giải mã
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(xmlContent)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            StringBuilder decryptedContent = new StringBuilder();
                            while (!srDecrypt.EndOfStream)
                            {
                                string encryptedLine = srDecrypt.ReadLine();
                                string decryptedLine = Encoding.UTF8.GetString(Convert.FromBase64String(encryptedLine));
                                decryptedContent.AppendLine(decryptedLine);
                            }

                            return decryptedContent.ToString();
                        }
                    }
                }
            }
        }

    }
}
