using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Movie_Ticket_Management.DataAccess
{
    public class MovieTableInfos
    {
        public Int64 MovieID { get; set; }
        public string MovieName { get; set; }
        public string HeroName { get; set; }
        public string HeroinName { get; set; }
        public string DirectorName { get; set; }
        public string StoryWriterName { get; set; }
        public string Genre { get; set; }
        public decimal Cost { get; set; }
        public decimal Rating { get; set; }
        public decimal Duration { get; set; }
        public int ImageSize { get; set; }
        public string ImageData { get; set; }
        private static readonly byte[] salt = Encoding.ASCII.GetBytes("EncrytpingMovieTableInfosinCryptography");
        private static readonly byte[] iv = Encoding.ASCII.GetBytes("16byteEncodedMsg");
        public static string Encrypt(long movieId)
        {
            byte[] plain_text_bytes = BitConverter.GetBytes(movieId);
            byte[] key_bytes = new Rfc2898DeriveBytes("MovieEncrypt", salt, 1000).GetBytes(32);
            using (Aes aes_alg = Aes.Create())
            {
                aes_alg.Key = key_bytes;
                aes_alg.IV = iv;
                ICryptoTransform encryptor = aes_alg.CreateEncryptor(aes_alg.Key, aes_alg.IV);
                using (MemoryStream ms_encrypt = new MemoryStream())
                {
                    using (CryptoStream cs_encrypt = new CryptoStream(ms_encrypt, encryptor, CryptoStreamMode.Write))
                    {
                        cs_encrypt.Write(plain_text_bytes, 0, plain_text_bytes.Length);
                        cs_encrypt.FlushFinalBlock();
                    }
                    return Convert.ToBase64String(ms_encrypt.ToArray());
                }
            }
        }

        public static long Decrypt(string encryptedMovieId)
        {
            byte[] cipher_text_bytes = Convert.FromBase64String(encryptedMovieId);
            byte[] key_bytes = new Rfc2898DeriveBytes("MovieEncrypt", salt, 1000).GetBytes(32);
            using (Aes aes_alg = Aes.Create())
            {
                aes_alg.Key = key_bytes;
                aes_alg.IV = iv;
                ICryptoTransform decryptor = aes_alg.CreateDecryptor(aes_alg.Key, aes_alg.IV);
                using (MemoryStream ms_decrypt = new MemoryStream(cipher_text_bytes))
                {
                    using (CryptoStream cs_decrypt = new CryptoStream(ms_decrypt, decryptor, CryptoStreamMode.Read))
                    {
                        byte[] plain_text_bytes = new byte[cipher_text_bytes.Length];
                        int bytes_read = cs_decrypt.Read(plain_text_bytes, 0, plain_text_bytes.Length);
                        return BitConverter.ToInt64(plain_text_bytes, 0);
                    }
                }
            }
        }
    }
    public struct HomePageDataInfoFields
    {
        public const int MovieID = 0;
        public const int MovieName = 1;
        public const int Hero = 2;
        public const int Heroin = 3;
        public const int Director = 4;
        public const int Story = 5;
        public const int Genre = 6;
        public const int Cost = 7;
        public const int Rating = 8;
        public const int Duration = 9;
        public const int ImageSize = 10;
        public const int ImageData = 11;
    }
    public class MovieSeatSatus
    {
        public Int64 SeatStatusID { get; set; }
        public Int64 MovieID { get; set; }
        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }
        public string s4 { get; set; }
        public string s5 { get; set; }
        public string s6 { get; set; }
        public string s7 { get; set; }
        public string s8 { get; set; }
        public string s9 { get; set; }
        public string s10 { get; set; }
        public string s11 { get; set; }
        public string s12 { get; set; }
        public string s13 { get; set; }
        public string s14 { get; set; }
        public string s15 { get; set; }
        public string s16 { get; set; }
        public string s17 { get; set; }
        public string s18 { get; set; }
        public string s19 { get; set; }
        public string s20 { get; set; }
        public string s21 { get; set; }
        public string s22 { get; set; }
        public string s23 { get; set; }
        public string s24 { get; set; }
        public string s25 { get; set; }
        public string s26 { get; set; }
        public string s27 { get; set; }
        public string s28 { get; set; }
        public string s29 { get; set; }
        public string s30 { get; set; }
        public DateTime MovieDateTime { get; set; }
    }
    public struct MovieSeatSatusDataInfoFields
    {
        public const int SeatStatusID = 0;
        public const int MovieID = 1;
        public const int s1 = 2;
        public const int s2 = 3;
        public const int s3 = 4;
        public const int s4 = 5;
        public const int s5 = 6;
        public const int s6 = 7;
        public const int s7 = 8;
        public const int s8 = 9;
        public const int s9 = 10;
        public const int s10 = 11;
        public const int s11 = 12;
        public const int s12 = 13;
        public const int s13 = 14;
        public const int s14 = 15;
        public const int s15 = 16;
        public const int s16 = 17;
        public const int s17 = 18;
        public const int s18 = 19;
        public const int s19 = 20;
        public const int s20 = 21;
        public const int s21 = 22;
        public const int s22 = 23;
        public const int s23 = 24;
        public const int s24 = 25;
        public const int s25 = 26;
        public const int s26 = 27;
        public const int s27 = 28;
        public const int s28 = 29;
        public const int s29 = 30;
        public const int s30 = 31;
        public const int MovieDateTime = 32;
    }
}