using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UtilSecurity
{
    public class UtilEncriptarDesencriptar
    {
        #region   Protecolo AES
        public string AES_encriptar(string texto)
        {
            string textoEncriptado = "";
            byte[] clearBytes = Encoding.Unicode.GetBytes(texto); // convierte lo que mandas a bytes
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(ObtnerSecretKey(), new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    textoEncriptado = Convert.ToBase64String(ms.ToArray());
                }
            }


            return textoEncriptado;
        }
        public string AES_Desencriptar(string texto)
        {

            string textoEncriptado = "";
            return textoEncriptado;


        }
        #endregion Fin Protecolo AES
        #region Inicion json
        private static string ObtnerSecretKey()
        {
            IConfigurationBuilder configurationBuild = new ConfigurationBuilder();
            configurationBuild = configurationBuild.AddJsonFile("appsettings.json");
            IConfiguration configurationFile = configurationBuild.Build();
            // Leemos el archivo de configuración.
            string str = configurationFile.GetSection("SecretKey").Value;
            return str;
        }
        #endregion Final json
    }
}
