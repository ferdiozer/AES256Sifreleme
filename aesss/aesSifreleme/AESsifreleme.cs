using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;   //blok blok şifreleme yapıldığı için
              // ne kadarlık bloklar halinde şifreleneceği tanımlanıyor
using System.Security.Cryptography;

namespace aesSifreleme
{
   public class AESsifreleme
    {
        private const string AES_IV = @"!&+QWSDF!123126+"; 
        private string aesAnahtar = @"QQsaw!257()%%ert";

        public string AESsifrele(string metin)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;  //blok blok şifreleme yapıldığı için(128 byte)
            aesSaglayici.KeySize = 256;    // ne kadarlık bloklar halinde şifreleneceği tanımlanıyor

            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesSaglayici.Key = Encoding.UTF8.GetBytes(aesAnahtar);  //key to byte
            aesSaglayici.Mode = CipherMode.CBC; //Şifreleme modu ( cbc )
            //Böylece evrensel olarak bütün dosya, resim, metin vs
            //bytelara çevrilerek şifreleme yapılabilir.
            aesSaglayici.Padding = PaddingMode.PKCS7;   

            byte[] kaynak = Encoding.Unicode.GetBytes(metin);   //metin de bytelara çevrilir
            using (ICryptoTransform sifrele = aesSaglayici.CreateEncryptor())
            {   // şifreleme burda gerçekleşiyor
                byte[] hedef = sifrele.TransformFinalBlock(kaynak, 0, kaynak.Length);
                return Convert.ToBase64String(hedef);
            }
        }
        public string AESsifre_Coz(string sifreliMetin)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;   // Standart
            aesSaglayici.KeySize = 256;

            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesSaglayici.Key = Encoding.UTF8.GetBytes(aesAnahtar);
            aesSaglayici.Mode = CipherMode.CBC;
            aesSaglayici.Padding = PaddingMode.PKCS7;

            try
            {
                byte[] kaynak = System.Convert.FromBase64String(sifreliMetin);
                using (ICryptoTransform decrypt = aesSaglayici.CreateDecryptor())
                {
                    byte[] hedef = decrypt.TransformFinalBlock(kaynak, 0, kaynak.Length);
                    return Encoding.Unicode.GetString(hedef);
                }
            }
            catch (Exception ex)
            {
                string hata = ex.Message;
                return "HATA   :"+hata;
                
            }
        }

        private Random random = new Random((int)DateTime.Now.Ticks);
        private string RandomString(int size)                     //   Random Key
        {
            StringBuilder builder = new StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
        }

    }
}
