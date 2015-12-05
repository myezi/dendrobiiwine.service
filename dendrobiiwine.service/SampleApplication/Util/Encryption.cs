using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace SampleApplication.Util
{
    public class Encryption
    {
        public static string Encrypt(string encryptString)
        {
            if (string.IsNullOrEmpty(encryptString)) { throw new ArgumentNullException("encryptString"); }
            return AESEncrypt(encryptString, PublicKey);
        }

        public static string Decrypt(string decryptString)
        {
            if (string.IsNullOrEmpty(decryptString)) { throw new ArgumentNullException("decryptString"); }
            return AESDecrypt(decryptString, PublicKey);
        }

        //系统标准密钥
        private static string publicKey;
        internal static string PublicKey
        {
            //目前算法前12位有效
            get { return publicKey ?? "webeziChina2"; }
            set {
                if (publicKey == null) 
                    publicKey = value;
                else
                    throw new InvalidOperationException("Public Key of Encryption cannot be overwritten after fist assignment.");
            }
        }

        //AES算法的基本字符串
        private readonly static byte[] btIV = Convert.FromBase64String("Rkb4jvUy/ye7Cd7k89QQgQ==");

        /// <summary>
        /// AES 加密(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="EncryptString">待加密密文</param>
        /// <param name="EncryptKey">加密密钥</param>
        /// <returns></returns>
        private static string AESEncrypt(string EncryptString, string EncryptKey)
        {
            if (string.IsNullOrEmpty(EncryptString)) { throw new ArgumentNullException("EncryptString"); }
            if (string.IsNullOrEmpty(EncryptKey)) { throw new ArgumentNullException("EncryptKey"); }

            string  strEncrypt = "";
            Rijndael m_AESProvider = Rijndael.Create();

            try
            {
                byte[] m_btEncryptString = Encoding.UTF8.GetBytes(EncryptString);
                MemoryStream stream = new MemoryStream();
                CryptoStream csstream = new CryptoStream(stream, m_AESProvider.CreateEncryptor(Encoding.UTF8.GetBytes(EncryptKey), btIV), CryptoStreamMode.Write);
                csstream.Write(m_btEncryptString, 0, m_btEncryptString.Length);
                csstream.FlushFinalBlock();
                strEncrypt = Convert.ToBase64String(stream.ToArray());
                stream.Close(); 
                csstream.Close(); 
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }

            return strEncrypt;
        }
        /// <summary>
        /// AES 解密(高级加密标准，是下一代的加密算法标准，速度快，安全级别高，目前 AES 标准的一个实现是 Rijndael 算法)
        /// </summary>
        /// <param name="DecryptString">待解密密文</param>
        /// <param name="DecryptKey">解密密钥</param>
        /// <returns></returns>
        private static string AESDecrypt(string DecryptString, string DecryptKey)
        {
            if (string.IsNullOrEmpty(DecryptString)) { throw new ArgumentNullException("DecryptString"); }
            if (string.IsNullOrEmpty(DecryptKey)) { throw new ArgumentNullException("DecryptKey"); }

            string strDecrypt = "";
            Rijndael m_AESProvider = Rijndael.Create();

            try
            {
                byte[] m_btDecryptString = Convert.FromBase64String(DecryptString);
                MemoryStream stream = new MemoryStream();
                CryptoStream csstream = new CryptoStream(stream, m_AESProvider.CreateDecryptor(Encoding.UTF8.GetBytes(DecryptKey), btIV), CryptoStreamMode.Write);
                csstream.Write(m_btDecryptString, 0, m_btDecryptString.Length);
                csstream.FlushFinalBlock();
                strDecrypt = Encoding.UTF8.GetString(stream.ToArray());
                stream.Close(); 
                csstream.Close(); 
            }
            catch (IOException ex) { throw ex; }
            catch (CryptographicException ex) { throw ex; }
            catch (ArgumentException ex) { throw ex; }
            catch (Exception ex) { throw ex; }
            finally { m_AESProvider.Clear(); }

            return strDecrypt;
        }


    }
}
