using System;
using System.Security.Cryptography;

namespace Movie_Ticket_Management.DataAccess
{
    public class UserAccountInfos
    {
        public Int64 UserID { get; set; }
        public string UserName { get; set; }
        public string EncryptedPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public bool IsUserAdmin { get; set; }
        public int? ImageSize { get; set; }
        public string ImageData { get; set; }
        public static String Encrypt(String Password)
        {
            if (Password == null)
            {
                throw new ArgumentNullException();
            }
            HashAlgorithm hash_algorithm = new SHA256CryptoServiceProvider();
            // Convert the original string to array of Bytes
            byte[] password_as_bytes = System.Text.Encoding.UTF8.GetBytes(Password);
            // Compute the Hash, returns an array of Bytes
            byte[] hashed_password_as_bytes = hash_algorithm.ComputeHash(password_as_bytes);
            // need to free up some resources
            hash_algorithm.Clear();
            // Return a base 64 encoded string of the Hash value
            return Convert.ToBase64String(hashed_password_as_bytes);
        }
    }
    public struct UserAccountDataInfoFields
    {
        public const int UserID = 0;
        public const int UserName = 1;
        public const int EncryptedPassword = 2;
        public const int FirstName = 3;
        public const int LastName = 4;
        public const int ContactNumber = 5;
        public const int EmailAddress = 6;
        public const int IsUserAdmin = 7;
        public const int ImageSize = 8;
        public const int ImageData = 9;
    }

}