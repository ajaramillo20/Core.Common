using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Common.Util.Helper.Autenticacion
{
    public static class CryptographyHelper
    {

        /// <summary>
        /// Metodo para encriptar Texto
        /// </summary>
        /// <param name="text">Recibe texto sin encriptar</param>
        /// <param name="secretKey">Clave secreta</param>
        /// <returns></returns>
        public static string EncryptString(string text, string secretKey)
        {
            byte[] arreglo = UTF8Encoding.UTF8.GetBytes(text);
            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(secretKey));
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;

            ICryptoTransform convertir = tripledes.CreateEncryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }

        /// <summary>
        /// Metodo para desencriptar MD5
        /// </summary>
        /// <param name="encryptText">Texto encriptado</param>
        /// <param name="secretKey">Clave secreta</param>
        /// <returns></returns>
        public static string DecryptString(string encryptText, string secretKey)
        {
            byte[] arreglo = Convert.FromBase64String(encryptText);
            MD5 md5 = MD5.Create();
            TripleDES tripledes = TripleDES.Create();

            tripledes.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(secretKey));
            tripledes.Mode = CipherMode.ECB;
            tripledes.Padding = PaddingMode.PKCS7;
            ICryptoTransform convertir = tripledes.CreateDecryptor();
            byte[] resultado = convertir.TransformFinalBlock(arreglo, 0, arreglo.Length);
            tripledes.Clear();

            return UTF8Encoding.UTF8.GetString(resultado);
        }

    }
}
