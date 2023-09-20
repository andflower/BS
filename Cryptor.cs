using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BS
{
    public class Cryptor
    {
        public class Hash
        {
            public enum HashType { MD5, SHA256, SHA384, SHA512 }

            /// <summary>
            /// MD5 암호화
            /// </summary>
            /// <param name="text">암호화 할 평문</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
            public static string EncryptMD5(string text, Encoding encoding)
            {
                var md5 = System.Security.Cryptography.MD5.Create();
                byte[] data = md5.ComputeHash(encoding.GetBytes(text));

                var sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }

            /// <summary>
            /// SHA256 암호화
            /// </summary>
            /// <param name="text">암호화 할 평문</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
            public static string EncryptSHA256(string text, Encoding encoding)
            {
                var sha = new System.Security.Cryptography.SHA256Managed();
                byte[] data = sha.ComputeHash(encoding.GetBytes(text));

                var sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }

            /// <summary>
            /// SHA384 암호화
            /// </summary>
            /// <param name="text">암호화 할 평문</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
            public static string EncryptSHA384(string text, Encoding encoding)
            {
                var sha = new System.Security.Cryptography.SHA384Managed();
                byte[] data = sha.ComputeHash(encoding.GetBytes(text));

                var sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }

            /// <summary>
            /// SHA512 암호화
            /// </summary>
            /// <param name="text">암호화 할 평문</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
            public static string EncryptSHA512(string text, Encoding encoding)
            {
                var sha = new System.Security.Cryptography.SHA512Managed();
                byte[] data = sha.ComputeHash(encoding.GetBytes(text));

                var sb = new StringBuilder();
                foreach (byte b in data)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }

            /// <summary>
            /// 평문화 Hash 암호화 문자열 비교
            /// </summary>
            /// <param name="text">평문</param>
            /// <param name="oldHash">Hash 암호화 문자열</param>
            /// <param name="type">MD5, SHA256, SHA384, SHA512</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>평문을 지정된 인코딩으로 암호화한 후 비교 결과 True/False</returns>
            public static bool IsTextEqulsHash(string text, string oldHash, HashType type, Encoding encoding)
            {
                string newHash = null;
                switch (type)
                {
                    case HashType.MD5:
                        newHash = EncryptMD5(text, encoding);
                        break;
                    case HashType.SHA256:
                        newHash = EncryptSHA256(text, encoding);
                        break;
                    case HashType.SHA384:
                        newHash = EncryptSHA384(text, encoding);
                        break;
                    case HashType.SHA512:
                        newHash = EncryptSHA512(text, encoding);
                        break;
                    default:
                        return false;
                }
                var comparer = StringComparer.OrdinalIgnoreCase;
                return comparer.Compare(newHash, oldHash) == 0;
            }
        }

        public class AES
        {
            /// <summary>
            /// AES256 암호화
            /// </summary>
            /// <param name="text">평문</param>
            /// <param name="key">암호화할 키 값</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 암호화한 문자열</returns>
            public static string Encrypt(string text, string key, Encoding encoding)
            {
                try
                {
                    byte[] textData = encoding.GetBytes(text);
                    byte[] salt = Encoding.ASCII.GetBytes(key.Length.ToString());
                    var secretKey = new PasswordDeriveBytes(key, salt);

                    var aes = new RijndaelManaged();
                    ICryptoTransform encryptor = aes.CreateEncryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        cs.Write(textData, 0, textData.Length);
                        cs.FlushFinalBlock();
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
                catch (Exception e)
                {
                    return "Encrypt error : " + e.Message;
                }
            }

            /// <summary>
            /// AES256 복호화
            /// </summary>
            /// <param name="encryptText">암호화된 문자열</param>
            /// <param name="key">복호화할 키 값</param>
            /// <param name="encoding">System.Text.Encoding</param>
            /// <returns>지정된 인코딩으로 복호화한 문자열</returns>
            public static string Decrypt(string encryptText, string key, Encoding encoding)
            {
                try
                {
                    byte[] encryptData = Convert.FromBase64String(encryptText);
                    byte[] salt = Encoding.ASCII.GetBytes(key.Length.ToString());
                    var secretKey = new PasswordDeriveBytes(key, salt);

                    var aes = new RijndaelManaged();
                    ICryptoTransform decryptor = aes.CreateDecryptor(secretKey.GetBytes(32), secretKey.GetBytes(16));

                    using (var ms = new MemoryStream())
                    using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                    {
                        byte[] result = new byte[encryptData.Length];
                        int decryptedCount = cs.Read(result, 0, result.Length);
                        return encoding.GetString(result, 0, decryptedCount);
                    }
                }
                catch (Exception e)
                {
                    return "Decrypt error : " + e.Message;
                }
            }
        }

        private class FuncTest
        {
            private bool Compare(string text, BS.Cryptor.Hash.HashType type)
            {
                string hash = "";
                switch (type)
                {
                    case Hash.HashType.MD5:
                        hash = Hash.EncryptMD5(text, Encoding.Unicode);
                        break;
                    case Hash.HashType.SHA256:
                        hash = Hash.EncryptSHA256(text, Encoding.Unicode);
                        break;
                    case Hash.HashType.SHA384:
                        hash = Hash.EncryptSHA384(text, Encoding.Unicode);
                        break;
                    case Hash.HashType.SHA512:
                        hash = Hash.EncryptSHA512(text, Encoding.Unicode);
                        break;
                    default:
                        break;
                }
                bool isHashMatch = Hash.IsTextEqulsHash(text, hash, type, Encoding.Unicode);
                return isHashMatch;
            }

            private bool AES_Enc_Dec(string text, string key)
            {
                string encrypted = AES.Encrypt(text, key, Encoding.Unicode);
                string decrypted = AES.Decrypt(encrypted, key, Encoding.Unicode);
                bool isHashMatch = text.Equals(decrypted);
                return isHashMatch;
            }
        }
    }
}
